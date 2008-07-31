using System;
using Servidor.Modelo;
using Servidor.Comunicacion;

namespace CasinoOnline.Servidor.MensajeroDeSalida
{
	using IdMesa = Int32;
	using IdTerminalVirtual = Int32;
	using Nombre = String;
	using Creditos = Decimal;

	public class AccesoYJuegoTragamonedas
	{
		#region Singleton
		/// <summary>
		/// La instancia de la clase
		/// </summary>
		private static AccesoYJuegoTragamonedas instancia = null;

		/// <summary>
		/// Constructor privado para no permitir crear mas instancias que las necesarias
		/// </summary>
		private AccesoYJuegoTragamonedas()
		{
		}

		/// <summary>
		/// Devuelve la instancia de la clase
		/// </summary>
		public static AccesoYJuegoTragamonedas ObtenerInstancia()
		{
			if (instancia == null)
			{
				instancia = new AccesoYJuegoTragamonedas();
			}
			return instancia;
		}
		#endregion


		/// 
		/// <param name="idt"></param>
		/// <param name="idu"></param>
		/// <param name="idm"></param>
		/// <param name="descripcion"></param>
		/// <param name="aceptado"></param>
		public void ResponderEntradaTragamonedas(IdTerminalVirtual idt, Nombre idu, IdMesa idm, String descripcion, Boolean aceptado)
		{
			throw new NotImplementedException();
		}

		/// 
		/// <param name="idt"></param>
		/// <param name="idu"></param>
		/// <param name="idm"></param>
		/// <param name="descripcion"></param>
		/// <param name="aceptado"></param>
		public void RespoderSalidaTragamonedas(IdTerminalVirtual idt, Nombre idu, IdMesa idm, String descripcion, Boolean aceptado)
		{
			throw new NotImplementedException();
		}

		/// 
		/// <param name="idt"></param>
		/// <param name="idu"></param>
		/// <param name="idm"></param>
		/// <param name="monto"></param>
		/// <param name="aceptado"></param>
		public void ResponderApuestaTragamonedas(IdTerminalVirtual idt, Nombre idu, IdMesa idm, Creditos monto, Boolean aceptado)
		{
			throw new NotImplementedException();
		}

		/// 
		/// <param name="idt"></param>
		/// <param name="idu"></param>
		/// <param name="idm"></param>
		/// <param name="aceptado"></param>
		public void ResponderTiroTragamonedas(IdTerminalVirtual idt, Nombre idu, IdMesa idm, Boolean aceptado)
		{
			throw new NotImplementedException();
		}

	}
}
