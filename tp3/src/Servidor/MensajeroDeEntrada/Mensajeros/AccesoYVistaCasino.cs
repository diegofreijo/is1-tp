using System;
using System.Xml.Linq;
using CasinoOnline.Servidor;
using CasinoOnline.Servidor.MensajeroDeEntrada;
using CasinoOnline.Servidor.Utils;

namespace CasinoOnline.Servidor.MensajeroDeEntrada.Mensajeros
{
	using Nombre = String;
	using IdTerminalVirtual = Int32;

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

		#region Metodos Manejadores

		public void EntrarCasino(XElement parametros)
		{
			// Recorro el Xml y busco las variables que necesito
			Nombre usuario = parametros.Attribute("usuario").Value;
			String modo = parametros.Element("modoAcceso").Value;
			IdTerminalVirtual id_terminal = IdTerminalVirtual.Parse(parametros.Attribute("vTerm").Value);

			// Invoco al modelo
			bool aceptado = Modelo.Fachadas.LobbyCasino.ObtenerInstancia().EntrarCasino(usuario, modo);

			// Envio la respuesta segun el resultado de la operacion
			MensajeroDeSalida.Mensajeros.AccesoYVistaCasino.ObtenerInstancia().
				ResponderEntrada(id_terminal, usuario, Modelo.Fachadas.LobbyCasino.ObtenerInstancia().DetalleUltimaAccion(), aceptado);
		}
		public void SalirCasino(XElement parametros)
		{
			// Recorro el Xml y busco las variables que necesito
			Nombre usuario = parametros.Attribute("usuario").Value;
			IdTerminalVirtual id_terminal = IdTerminalVirtual.Parse(parametros.Attribute("vTerm").Value);

			// Invoco al modelo
			bool aceptado = Modelo.Fachadas.LobbyCasino.ObtenerInstancia().SalirCasino(usuario);

			// Envio la respuesta segun el resultado de la operacion
			MensajeroDeSalida.Mensajeros.AccesoYVistaCasino.ObtenerInstancia().
				ResponderSalida(id_terminal, usuario, Modelo.Fachadas.LobbyCasino.ObtenerInstancia().DetalleUltimaAccion(), aceptado);
		}
		public void PedirEstadoCasino(XElement parametros)
		{
			// Recorro el Xml y busco las variables que necesito
			Nombre usuario = parametros.Attribute("usuario").Value;
			IdTerminalVirtual id_terminal = IdTerminalVirtual.Parse(parametros.Attribute("vTerm").Value);

			// Invoco al modelo
			bool aceptado = Modelo.Fachadas.LobbyCasino.ObtenerInstancia().PedirEstadoCasino(usuario);

			// Envio la respuesta segun el resultado de la operacion
			MensajeroDeSalida.Mensajeros.AccesoYVistaCasino.ObtenerInstancia().
				ResponderEstadoCasino(id_terminal, usuario, aceptado);
		}

		#endregion
	}
}