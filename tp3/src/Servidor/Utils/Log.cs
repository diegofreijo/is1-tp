using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace CasinoOnline.Servidor.Utils
{
	static class Log
	{
		// Registra un mensaje
		public static void Mensaje(string String)
		{
			CambiarColorConsola(ColorConsola.Verde);
			Console.Write(SelloTemporal());
			CambiarColorConsola(ColorConsola.Blanco);
			Console.WriteLine(String);
		}
		
		// Registra un error
		public static void Error(string String)
		{
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine("------------------------------------------------------");
			
			Console.ForegroundColor = ConsoleColor.Green;
			Console.Write(SelloTemporal());
			
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine(String);
			Console.WriteLine("------------------------------------------------------");
		}

		// Lo uso mas de 1 vez asi que prefiero ponerlo en un metodo aparte
		private static string SelloTemporal()
		{
			return "[" + DateTime.Now.ToString("HH:mm:ss") + "]  ";
		}
	}
}
