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
		private List<JugadaCraps> jugadas_craps = new List<JugadaCraps>();
		private List<JugadaTragamonedas> jugadas_tragamonedas = new List<JugadaTragamonedas>();
		#endregion


		#region Propiedades

		public List<JugadaTragamonedas> JugadasTragamonedas
		{
			get { return jugadas_tragamonedas; }
		}
		public List<JugadaCraps> JugadasCraps
		{
			get { return jugadas_craps; }
		}

		#endregion
	}
}
