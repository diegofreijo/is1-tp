using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CasinoOnline.Servidor.Modelo
{
	class HistorialJugadas
	{
		#region Singleton
		/// <summary>
		/// La instancia de la clase
		/// </summary>
		private static HistorialJugadas instancia = null;

		/// <summary>
		/// Constructor privado para no permitir crear mas instancias que las necesarias
		/// </summary>
		private HistorialJugadas()
		{
		}

		/// <summary>
		/// Devuelve la instancia de la clase
		/// </summary>
		public static HistorialJugadas ObtenerInstancia()
		{
			if (instancia == null)
			{
				instancia = new HistorialJugadas();
			}
			return instancia;
		}
		#endregion

		#region Miembros
		private List<JugadaCraps> jugadas_craps;
		private List<JugadaTragamonedas> jugadas_tragamonedas;
		#endregion


		#region Propiedades

		private List<JugadaTragamonedas> JugadasTragamonedas
		{
			get { return jugadas_tragamonedas; }
		}
		private List<JugadaCraps> JugadasCraps
		{
			get { return jugadas_craps; }
		}

		#endregion
	}
}
