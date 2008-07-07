using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cliente.Controlador
{
	class Craps
	{
		#region Singleton
		/// <summary>
		/// La instancia de la clase
		/// </summary>
		private static Craps instancia = null;

		/// <summary>
		/// Constructor privado para no permitir crear mas instancias que las necesarias
		/// </summary>
		private Craps()
		{
		}

		/// <summary>
		/// Devuelve la instancia de la clase
		/// </summary>
		public static Craps ObtenerInstancia()
		{
			if (instancia == null)
			{
				instancia = new Craps();
			}
			return instancia;
		}
		#endregion
	}
}
