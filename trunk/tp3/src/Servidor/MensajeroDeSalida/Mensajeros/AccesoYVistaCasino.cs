using System;
using System.Linq;
using CasinoOnline.Servidor.Modelo;
using CasinoOnline.Servidor.Comunicacion;

namespace CasinoOnline.Servidor.MensajeroDeSalida.Mensajeros
{
	using IdMesa = Int32;
	using IdTerminalVirtual = Int32;
	using Nombre = String;
	using Creditos = Decimal;
	using System.Xml.Linq;
	using CasinoOnline.Servidor.Utils;

	class AccesoYVistaCasino
	{
		#region Singleton
		/// <summary>
		/// La instancia de la clase
		/// </summary>
		private static AccesoYVistaCasino instancia = null;

		/// <summary>
		/// Constructor privado para no permitir crear mas instancias que las necesarias
		/// </summary>
		private AccesoYVistaCasino()
		{
		}

		/// <summary>
		/// Devuelve la instancia de la clase
		/// </summary>
		public static AccesoYVistaCasino ObtenerInstancia()
		{
			if (instancia == null)
			{
				instancia = new AccesoYVistaCasino();
			}
			return instancia;
		}
		#endregion


		#region Manejadores

		/// 
		/// <param name="idt"></param>
		/// <param name="idu"></param>
		/// <param name="descripcion"></param>
		/// <param name="aceptado"></param>
		public void ResponderEntrada(IdTerminalVirtual idt, Nombre usuario, String descripcion, Boolean aceptado)
		{
			// Averiguo el modoAcceso
			string modoAcceso = "";
			string saldo = "";
			if (Modelo.Fachadas.LobbyCasino.ObtenerInstancia().ObservadoresEnCasino().
				Exists(delegate(string nombre) { return nombre == usuario; }))
			{
				modoAcceso = "observador";
			}
			else
			{
				modoAcceso = "jugador";
				saldo = Modelo.Fachadas.AdministradorDeCasino.ObtenerInstancia().
					ObtenerJugadoresConSaldo()[usuario].ToString();
			}

			// Genero el XML de salida
			XElement parametros = new XElement("entradaCasino", new object[]{
				new XAttribute("vTerm", idt),
				new XAttribute("usuario", usuario),
				new XElement("aceptado", aceptado ? "si" : "no"),
				new XElement("modoAcceso", modoAcceso),
				new XElement("saldo", saldo),
				new XElement("descripcion", descripcion)
			});

			// Genero la respuesta
			Respuesta respuesta = new Respuesta("respuestaEntradaCasino", idt, parametros);

			// Envio el XML de salida
			DespachadorRespuestas.ObtenerInstancia().DespacharRespuesta(respuesta);
		}
		/// 
		/// <param name="idt"></param>
		/// <param name="idu"></param>
		/// <param name="descripcion"></param>
		/// <param name="aceptado"></param>
		public void ResponderSalida(IdTerminalVirtual idt, Nombre usuario, String descripcion, Boolean aceptado)
		{
			// Genero el XML de salida
			XElement parametros = new XElement("salidaCasino", new object[]{
				new XAttribute("vTerm", idt),
				new XAttribute("usuario", usuario),
				new XElement("aceptado", aceptado ? "si" : "no"),
				new XElement("descripcion", descripcion)
			});

			// Genero la respuesta
			Respuesta respuesta = new Respuesta("respuestaSalidaCasino", idt, parametros);

			// Envio el XML de salida
			DespachadorRespuestas.ObtenerInstancia().DespacharRespuesta(respuesta);
		}
		/// 
		/// <param name="idt"></param>
		/// <param name="idu"></param>
		public void ResponderEstadoCasino(IdTerminalVirtual idt, Nombre idu, Boolean aceptado)
		{
			throw new NotImplementedException();
		}

		#endregion
	}
}
