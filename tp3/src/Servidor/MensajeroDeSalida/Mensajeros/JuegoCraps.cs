using System;
using CasinoOnline.Servidor.Modelo;
using CasinoOnline.Servidor.Comunicacion;

namespace CasinoOnline.Servidor.MensajeroDeSalida.Mensajeros
{
	using IdMesa = Int32;
	using IdTerminalVirtual = Int32;
	using Nombre = String;
	using Creditos = Decimal;

	class JuegoCraps
	{
		#region Singleton
		/// <summary>
		/// La instancia de la clase
		/// </summary>
		private static JuegoCraps instancia = null;

		/// <summary>
		/// Constructor privado para no permitir crear mas instancias que las necesarias
		/// </summary>
		private JuegoCraps()
		{
		}

		/// <summary>
		/// Devuelve la instancia de la clase
		/// </summary>
		public static JuegoCraps ObtenerInstancia()
		{
			if (instancia == null)
			{
				instancia = new JuegoCraps();
			}
			return instancia;
		}
		#endregion


		/// 
		/// <param name="idt"></param>
		/// <param name="idu"></param>
		/// <param name="idm"></param>
		/// <param name="aceptado"></param>
		public void ResponderApuestaCraps(IdTerminalVirtual idt, Nombre idu, IdMesa idm, Boolean aceptado)
		{
			throw new NotImplementedException();
		}

		/// 
		/// <param name="idt"></param>
		/// <param name="idu"></param>
		/// <param name="idm"></param>
		/// <param name="aceptado"></param>
		public void ResponderTiroCraps(IdTerminalVirtual idt, Nombre idu, IdMesa idm, Boolean aceptado)
		{
			throw new NotImplementedException();
		}

	}
}
