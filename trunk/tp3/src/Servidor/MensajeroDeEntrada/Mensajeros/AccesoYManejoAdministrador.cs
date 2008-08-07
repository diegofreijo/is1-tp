using System;
using System.Linq;
using System.Xml.Linq;
using CasinoOnline.Servidor;
using CasinoOnline.Servidor.Utils;

namespace CasinoOnline.Servidor.MensajeroDeEntrada.Mensajeros
{
	using Nombre = String;
	using IdTerminalVirtual = Int32;
	using IdMesa = Int32;

	class AccesoYManejoAdministrador
	{
		#region Singleton
		/// <summary>
		/// La instancia de la clase
		/// </summary>
		private static AccesoYManejoAdministrador instancia = null;

		/// <summary>
		/// Constructor privado para no permitir crear mas instancias que las necesarias
		/// </summary>
		private AccesoYManejoAdministrador()
		{
		}

		/// <summary>
		/// Devuelve la instancia de la clase
		/// </summary>
		public static AccesoYManejoAdministrador ObtenerInstancia()
		{
			if (instancia == null)
			{
				instancia = new AccesoYManejoAdministrador();
			}
			return instancia;
		}
		#endregion

		/// 
		/// <param name="param"></param>
		public void PedidoReporteRankingDeJugadores(XElement parametros)
		{
			// Recorro el Xml y busco las variables que necesito
			String pass = parametros.Attribute("password").Value;
			IdTerminalVirtual id_terminal = IdTerminalVirtual.Parse(parametros.Attribute("vTerm").Value);

			// Invoco al modelo
			bool aceptado = Modelo.Fachadas.AdministradorDeCasino.ObtenerInstancia().PuedePedirReporteRankingDeJugadores(pass);

			// Envio la respuesta segun el resultado de la operacion
			MensajeroDeSalida.Mensajeros.AccesoYManejoAdministrador.ObtenerInstancia().
				RespuestaReporteRankingDeJugadores(id_terminal, aceptado);
		}

		/// 
		/// <param name="param"></param>
		public void PedidoReporteEstadoActual(XElement parametros)
		{
			// Recorro el Xml y busco las variables que necesito
			String pass = parametros.Attribute("password").Value;
			IdTerminalVirtual id_terminal = IdTerminalVirtual.Parse(parametros.Attribute("vTerm").Value);

			// Invoco al modelo
			bool aceptado = Modelo.Fachadas.AdministradorDeCasino.ObtenerInstancia().PuedePedirReporteEstadoActual(pass);

			// Envio la respuesta segun el resultado de la operacion
			MensajeroDeSalida.Mensajeros.AccesoYManejoAdministrador.ObtenerInstancia().
				RespuestaReporteEstadoActual(id_terminal, aceptado);
		}

		/// 
		/// <param name="param"></param>
		public void PedidoReporteDetalleMovimientosPorJugador(XElement parametros)
		{
			// Recorro el Xml y busco las variables que necesito
			String pass = parametros.Attribute("password").Value;
			IdTerminalVirtual id_terminal = IdTerminalVirtual.Parse(parametros.Attribute("vTerm").Value);

			// Invoco al modelo
			bool aceptado = Modelo.Fachadas.AdministradorDeCasino.ObtenerInstancia().PuedePedirReporteDetalleMovimientosPorJugador(pass);

			// Envio la respuesta segun el resultado de la operacion
			MensajeroDeSalida.Mensajeros.AccesoYManejoAdministrador.ObtenerInstancia().
				RespuestaReporteDetalleMovimientosPorJugador(id_terminal, aceptado);
		}

		/// 
		/// <param name="param"></param>
		public void EstablecerModoDirigidoTragamonedas(XElement parametros)
		{
			throw new NotImplementedException();
		}

		/// 
		/// <param name="param"></param>
		public void EstablecerModoDirigidoCraps(XElement parametros)
		{
			// Recorro el Xml y busco las variables que necesito
			String pass = parametros.Attribute("password").Value;
			IdTerminalVirtual id_terminal = IdTerminalVirtual.Parse(parametros.Attribute("vTerm").Value);
			int? dado1 = string.IsNullOrEmpty(parametros.Element("controlResultados").Element("dado1").Value) ? (int?)null :
				int.Parse(parametros.Element("controlResultados").Element("dado1").Value);
			int? dado2 = string.IsNullOrEmpty(parametros.Element("controlResultados").Element("dado2").Value) ? (int?)null :
							int.Parse(parametros.Element("controlResultados").Element("dado2").Value);
			string tipoJugada = parametros.Element("controlTipoJugadas").Element("tipo").Value;

			// Invoco al modelo
			bool aceptado = Modelo.Fachadas.AdministradorDeCasino.ObtenerInstancia().ConfigurarModoDirigidoCraps(dado1, dado2, tipoJugada, pass);

			// Envio la respuesta segun el resultado de la operacion
			MensajeroDeSalida.Mensajeros.AccesoYManejoAdministrador.ObtenerInstancia().
				RespuestaConfigurarModoDirigidoCraps(id_terminal, Modelo.Fachadas.AdministradorDeCasino.ObtenerInstancia().DetalleUltimaAccion(), aceptado);
		}

		public void EstablecerModoDirigidoFeliz(XElement parametros)
		{
			// Recorro el Xml y busco las variables que necesito
			String pass = parametros.Attribute("password").Value;
			IdTerminalVirtual id_terminal = IdTerminalVirtual.Parse(parametros.Attribute("vTerm").Value);
			IdMesa idmesa = IdMesa.Parse(parametros.Element("mesa").Value);

			// Invoco al modelo
			bool aceptado = Modelo.Fachadas.AdministradorDeCasino.ObtenerInstancia().ConfigurarModoDirigidoJugadaFeliz(idmesa, pass);

			// Envio la respuesta segun el resultado de la operacion
			MensajeroDeSalida.Mensajeros.AccesoYManejoAdministrador.ObtenerInstancia().
				RespuestaConfigurarModoDirigidoJugadaFeliz(id_terminal, Modelo.Fachadas.AdministradorDeCasino.ObtenerInstancia().DetalleUltimaAccion(), aceptado);
		}
	}
}