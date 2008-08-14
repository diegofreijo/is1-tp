using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Threading;
using CasinoOnline.Servidor.MensajeroDeSalida;
using CasinoOnline.Servidor.MensajeroDeEntrada;
using CasinoOnline.Servidor.Utils;

namespace CasinoOnline.Servidor
{
	using Nombre = String;

    class Program
    {
		public const string archivo_config = "..\\config\\configuracion_casino.xml";
		public const string archivo_lista_jugadores = "..\\config\\lista_jugadores.xml";

        static void Main(string[] args)
        {
			Console.Title = "CasinoOnline - Grupo 05";
			EncenderServidor();
        }

		private static void EncenderServidor()
		{
			Log.Mensaje("Inicializando servidor...");

			// Levanto la configuracion del casino
			XElement config = XElement.Load(archivo_config);
			Modelo.Fachadas.AdministradorDeCasino.ObtenerInstancia().InicializarConfiguracion(config);

			// Levanto la lista de jugadores registrador
			XElement jugadores = XElement.Load(archivo_lista_jugadores);
			Modelo.Fachadas.AdministradorDeCasino.ObtenerInstancia().InicializarJugadoresRegistrados(jugadores);

			// Inicializo las mesas
			Modelo.Fachadas.AdministradorDeCasino.ObtenerInstancia().InicializarMesas(MensajeroDeSalida.NotificadorDeCambiosAClientes.ObtenerInstancia());

			// Inicializo los pozos
			Modelo.Fachadas.AdministradorDeCasino.ObtenerInstancia().InicializarPozos();

			// Inicializo el despachador de respuestas
			Comunicacion.DespachadorRespuestas.ObtenerInstancia().Despachador = new Comunicacion.DespachadorRespuestasArchivo();

			// Inicializo el receptor de pedidos
			Comunicacion.ReceptorPedidos receptor = new Comunicacion.ReceptorPedidos(new Comunicacion.ObtenedorPedidosArchivo());

			Log.Mensaje("Servidor de CasinoOnline inicializado!" + Environment.NewLine + 
				"=============================================");

			// Levanto un thread que escuche la orden de finalizacion del servidor
			WaitCallback callback = new WaitCallback(delegate(object r) { EscucharFinServidor((Comunicacion.ReceptorPedidos)r); });
			ThreadPool.QueueUserWorkItem(callback, receptor);

			// Comienzo la recepcion de pedidos
			Log.Mensaje("<Para finalizar el servidor, presionar ENTER>");
			Log.Mensaje("Comenzando recepcion de pedidos");
			receptor.ComenzarRecepcion();
			
			// Persisto la nueva lista de jugadores
			Log.Mensaje("Persistiendo jugadores...");
			Modelo.Fachadas.AdministradorDeCasino.ObtenerInstancia().PersistirJugadoresRegistrados().Save(archivo_lista_jugadores);

			// Persisto la nueva configuracion
			Log.Mensaje("Persistiendo configuracion...");
			Modelo.Fachadas.AdministradorDeCasino.ObtenerInstancia().PersistirConfiguracion().Save(archivo_config);

			Log.Mensaje("Servidor finalizado, apreta ENTER para cerrar");
			Console.ReadLine();
		}

		/// <summary>
		/// Es el encargado de escuchar si el usuario finalizo el servidor
		/// </summary>
		public static void EscucharFinServidor(Comunicacion.ReceptorPedidos receptor)
		{
			bool puede_cerrar = false;

			while (!puede_cerrar)
			{
				// Con apretar un enter en la consola se cierra el servidor
				Console.ReadLine();

				// Verifico si no quedaban jugadores en el casino
				List<Nombre> jugadores = Modelo.Fachadas.LobbyCasino.ObtenerInstancia().JugadoresEnCasino();
				if (jugadores.Count > 0)
				{
					Log.Error("No se puede cerrar el casino en este momento, todavia estan los siguientes jugadores jugando:" + Environment.NewLine +
						"		" + jugadores.Aggregate((j1, j2) => j1 + ", " + j2));
				}
				else
				{
					puede_cerrar = true;
				}
			}

			// Apago el servidor
			receptor.DetenerRecepcion();
		}
    }
}
