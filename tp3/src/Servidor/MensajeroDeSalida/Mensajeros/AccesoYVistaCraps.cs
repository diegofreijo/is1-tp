using System;
using CasinoOnline.Servidor.Modelo;
using CasinoOnline.Servidor.Comunicacion;

namespace CasinoOnline.Servidor.MensajeroDeSalida.Mensajeros
{
	using IdMesa = Int32;
	using IdTerminalVirtual = Int32;
	using Nombre = String;
	using Creditos = Decimal;

	class AccesoYVistaCraps
	{
		#region Singleton
		/// <summary>
		/// La instancia de la clase
		/// </summary>
		private static AccesoYVistaCraps instancia = null;

		/// <summary>
		/// Constructor privado para no permitir crear mas instancias que las necesarias
		/// </summary>
		private AccesoYVistaCraps()
		{
		}

		/// <summary>
		/// Devuelve la instancia de la clase
		/// </summary>
		public static AccesoYVistaCraps ObtenerInstancia()
		{
			if (instancia == null)
			{
				instancia = new AccesoYVistaCraps();
			}
			return instancia;
		}
		#endregion



		/// 
		/// <param name="idt"></param>
		/// <param name="idu"></param>
		/// <param name="idm"></param>
		/// <param name="aceptado"></param>
		/// <param name="descripcion"></param>
		public void ResponderEntradaCraps(IdTerminalVirtual idt, Nombre idu, IdMesa idm, Boolean aceptado, String descripcion)
		{
			throw new NotImplementedException();
		}

		/// 
		/// <param name="idt"></param>
		/// <param name="idu"></param>
		/// <param name="idm"></param>
		/// <param name="aceptado"></param>
		/// <param name="descripcion"></param>
		public void ResponderSalidaCraps(IdTerminalVirtual idt, Nombre idu, IdMesa idm, Boolean aceptado, String descripcion)
		{
			throw new NotImplementedException();
		}

		/// 
		/// <param name="idt"></param>
		/// <param name="idu"></param>
		/// <param name="idm"></param>
		public void NotificarEstadoCraps(IdTerminalVirtual idt, Nombre idu, IdMesa idm)
		{
			throw new NotImplementedException();
		}

	}
}
