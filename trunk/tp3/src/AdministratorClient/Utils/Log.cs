using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace CasinoOnline.AdminClient.Utils
{
	using IdTerminalVirtual = Int32;

	static class Log
	{
		/// <summary>
		/// Registra un mensaje
		/// </summary>
		public static void Mensaje(string String)
		{
			EscribirSelloTemporal(); 
			
			Console.ForegroundColor = ConsoleColor.White;
			Console.WriteLine(String);
		}
		/// <summary>
		/// Registra un error
		/// </summary>
		public static void Error(string String)
		{
			EscribirSelloTemporal();
			
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine(String);
		}

		/// <summary>
		///  Lo uso mas de 1 vez asi que prefiero ponerlo en un metodo aparte
		/// </summary>
		private static void EscribirSelloTemporal()
		{
			Console.ForegroundColor = ConsoleColor.Green;
			Console.Write("[" + DateTime.Now.ToString("HH:mm:ss") + "]  ");
		}


		#region Mensajes Customizados
        /*
		/// <summary>
		/// Escribe el aviso que se recibio un nuevo pedido
		/// </summary>
		public static void MensajeRecepcionPedido(Comunicacion.Pedido pedido)
		{
			IdTerminalVirtual idterm = IdTerminalVirtual.Parse(pedido.Parametros.Attribute("vTerm").Value);

			Console.WriteLine();

			EscribirSelloTemporal();

			Console.ForegroundColor = ConsoleColor.White;
			Console.Write("Pedido de tipo ");

			Console.ForegroundColor = ConsoleColor.Cyan;
			Console.Write(pedido.Tipo);

			Console.ForegroundColor = ConsoleColor.White;
			Console.Write(" recibido de ");

			Console.ForegroundColor = ConsoleColor.Cyan;
			Console.WriteLine(idterm);
		}
		/// <summary>
		/// Escribe la confirmacion que una respuesta fue enviada con exito
		/// </summary>
		public static void MensajeEnvioRespuesta(Comunicacion.Respuesta respuesta)
		{
			EscribirSelloTemporal();

			Console.ForegroundColor = ConsoleColor.White;
			Console.Write("Respuesta de tipo ");

			Console.ForegroundColor = ConsoleColor.Cyan;
			Console.Write(respuesta.Tipo);

			Console.ForegroundColor = ConsoleColor.White;
			Console.Write(" enviada a ");

			Console.ForegroundColor = ConsoleColor.Cyan;
			Console.WriteLine(respuesta.IdTerminal);
		}
		/// <summary>
		/// Escribe un error no manejado que ocurre en medio del procesamiento de un pedido
		/// </summary>
		public static void ErrorProcesandoPedido(Comunicacion.Pedido pedido, Exception ex)
		{
			IdTerminalVirtual idterm = IdTerminalVirtual.Parse(pedido.Parametros.Attribute("vTerm").Value);

			EscribirSelloTemporal();

			Console.ForegroundColor = ConsoleColor.Red;
			Console.Write("Ocurrio un error procesando un pedido de tipo ");

			Console.ForegroundColor = ConsoleColor.Cyan;
			Console.Write(pedido.Tipo);

			Console.ForegroundColor = ConsoleColor.Red;
			Console.Write(" recibido de ");

			Console.ForegroundColor = ConsoleColor.Cyan;
			Console.WriteLine(idterm);

			Console.ForegroundColor = ConsoleColor.DarkRed;
			Console.WriteLine(ex.ToString());
		}*/

		#endregion

	}
}
