using System;
using CasinoOnline.Servidor.Modelo;
using CasinoOnline.Servidor.Comunicacion;

namespace CasinoOnline.Servidor.MensajeroDeSalida.Mensajeros
{
	using IdMesa = Int32;
	using IdTerminalVirtual = Int32;
	using Nombre = String;
	using Creditos = Decimal;

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
		/// <param name="term"></param>
		/// <param name="aceptado"></param>
		public void RespuestaReporteRankingDeJugadores(IdTerminalVirtual term, Boolean aceptado)
		{
			throw new NotImplementedException();
		}

		/// 
		/// <param name="term"></param>
		/// <param name="aceptado"></param>
		public void RespuestaReporteEstadoActual(IdTerminalVirtual term, Boolean aceptado)
		{
			throw new NotImplementedException();
		}

		/// 
		/// <param name="term"></param>
		/// <param name="aceptado"></param>
		public void RespuestaReporteDetalleMovimientosPorJugador(IdTerminalVirtual term, Boolean aceptado)
		{
			throw new NotImplementedException();
		}

		/// 
		/// <param name="term"></param>
		/// <param name="descripcion"></param>
		/// <param name="aceptado"></param>
		public void RespuestaConfigurarModoDirigidoTragamonedas(IdTerminalVirtual term, String descripcion, Boolean aceptado)
		{
			throw new NotImplementedException();
		}

		/// 
		/// <param name="term"></param>
		/// <param name="descripcion"></param>
		/// <param name="aceptado"></param>
		public void RespuestaConfigurarModoDirigidoCraps(IdTerminalVirtual term, String descripcion, Boolean aceptado)
		{
			throw new NotImplementedException();
		}

		/// 
		/// <param name="idt"></param>
		/// <param name="detalles"></param>
		/// <param name="aceptado"></param>
		public void RespuestaConfigurarModoDirigidoJugadaFeliz(IdTerminalVirtual idt, String detalles, Boolean aceptado)
		{
			throw new NotImplementedException();
		}
	}
}
