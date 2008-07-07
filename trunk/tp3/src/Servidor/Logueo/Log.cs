using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace CasinoOnline.Servidor.Logueo
{
	static class Log
	{
		#region Declaraciones para los colores en consola
		public enum ColorConsola { Blanco = 0x0007, Azul = 0x0001, Verde = 0x0002, Rojo = 0x0004};
		
		[DllImport("kernel32.dll")]
		public static extern bool SetConsoleTextAttribute(IntPtr hConsoleOutput, ColorConsola wAttributes);

		[DllImport("kernel32.dll")]
		public static extern IntPtr GetStdHandle(uint nStdHandle);

		// Cambia el color del texto escupido por consola
		private static void CambiarColorConsola(ColorConsola color)
		{
			uint STD_OUTPUT_HANDLE = 0xfffffff5;
			IntPtr hConsole = GetStdHandle(STD_OUTPUT_HANDLE);
			SetConsoleTextAttribute(hConsole, color);
		}
		#endregion


		// Registra un mensaje
		public static void Mensaje(string texto)
		{
			CambiarColorConsola(ColorConsola.Verde);
			Console.Write(SelloTemporal());
			CambiarColorConsola(ColorConsola.Blanco);
			Console.WriteLine(texto);
		}
		
		// Registra un error
		public static void Error(string texto)
		{
			CambiarColorConsola(ColorConsola.Rojo);
			Console.WriteLine("------------------------------------------------------");
			CambiarColorConsola(ColorConsola.Verde);
			Console.Write(SelloTemporal());
			CambiarColorConsola(ColorConsola.Rojo);
			Console.WriteLine(texto);
			Console.WriteLine("------------------------------------------------------");
		}

		// Lo uso mas de 1 vez asi que prefiero ponerlo en un metodo aparte
		private static string SelloTemporal()
		{
			return "[" + DateTime.Now.ToString("HH:mm:ss") + "]  ";
		}
	}
}
