using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CasinoOnline.Servidor.Modelo
{
	class Pozos
	{
		#region Singleton
		/// <summary>
		/// La instancia de la clase
		/// </summary>
		private static Pozos instancia = null;

		/// <summary>
		/// Constructor privado para no permitir crear mas instancias que las necesarias
		/// </summary>
		private Pozos()
		{
		}

		/// <summary>
		/// Devuelve la instancia de la clase
		/// </summary>
		public static Pozos ObtenerInstancia()
		{
			if (instancia == null)
			{
				instancia = new Pozos();
			}
			return instancia;
		}
		#endregion

		private PozoProgresivo prozo_progresivo;
		private PozoFeliz prozo_feliz;


		public PozoProgresivo ProzoProgresivo
		{
			get { return prozo_progresivo; }
		}
		public PozoFeliz ProzoFeliz
		{
			get { return prozo_feliz; }
		}

	}
}
