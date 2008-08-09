using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CasinoOnline.Servidor.MensajeroDeSalida;
using CasinoOnline.Servidor.MensajeroDeEntrada;
using CasinoOnline.Servidor.Utils;
using System.Xml.Linq;

namespace CasinoOnline.Servidor
{
    class Program
    {//..\\config\\
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

			// Inicializo el despachador de respuestas
			Comunicacion.DespachadorRespuestas.ObtenerInstancia().Despachador = new Comunicacion.DespachadorRespuestasArchivo();

			// Inicializo el receptor de pedidos
			Comunicacion.ReceptorPedidos receptor = new Comunicacion.ReceptorPedidos(new Comunicacion.ObtenedorPedidosArchivo());

			Log.Mensaje("Servidor de CasinoOnline inicializado!" + Environment.NewLine + 
				"=============================================");

			// Comienzo la recepcion de pedidos
			Log.Mensaje("Comenzando recepcion de pedidos");
			receptor.ComenzarRecepcion();
		}
    }
}
