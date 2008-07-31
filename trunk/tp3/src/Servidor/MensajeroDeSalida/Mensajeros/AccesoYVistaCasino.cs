using System;
using Servidor.Modelo;
using Servidor.Comunicacion;

namespace CasinoOnline.Servidor.MensajeroDeSalida
{
	using IdMesa = Int32;
	using IdTerminalVirtual = Int32;
	using Nombre = String;
	using Creditos = Decimal;

	public class AccesoYVistaCasino
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


		/// 
		/// <param name="idt"></param>
		/// <param name="idu"></param>
		/// <param name="descripcion"></param>
		/// <param name="aceptado"></param>
		public void ResponderEntrada(IdTerminalVirtual idt, Nombre idu, String descripcion, Boolean aceptado)
		{
			throw new NotImplementedException();
		}

		/// 
		/// <param name="idt"></param>
		/// <param name="idu"></param>
		/// <param name="descripcion"></param>
		/// <param name="aceptado"></param>
		public void ResponderSalida(IdTerminalVirtual idt, Nombre idu, String descripcion, Boolean aceptado)
		{
			throw new NotImplementedException();
		}

		/// 
		/// <param name="idt"></param>
		/// <param name="idu"></param>
		public void ResponderEstadoCasino(IdTerminalVirtual idt, Nombre idu)
		{
			throw new NotImplementedException();
		}
	}
}
