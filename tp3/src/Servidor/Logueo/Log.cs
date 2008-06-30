using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CasinoOnline.Servidor.Logueo
{
	static class Log
	{
		public static void Mensaje(string texto)
		{
			Console.WriteLine(SelloTemporal() + texto);
		}
		
		public static void Error(string texto)
		{
			Console.WriteLine("------------------------------------------------------");
			Console.WriteLine(SelloTemporal() + "ERROR: " + texto);
			Console.WriteLine("------------------------------------------------------");
		}

		private static string SelloTemporal()
		{
			return "[" + DateTime.Now.ToString("HH:mm:ss") + "]  ";
		}
	}
}
