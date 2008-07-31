using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace CasinoOnline.Servidor.Modelo
{
	class JugadoresRegistrados
	{
		#region Singleton
		/// <summary>
		/// La instancia de la clase
		/// </summary>
		private static JugadoresRegistrados instancia = null;

		/// <summary>
		/// Constructor privado para no permitir crear mas instancias que las necesarias
		/// </summary>
		private JugadoresRegistrados()
		{
		}

		/// <summary>
		/// Devuelve la instancia de la clase
		/// </summary>
		public static JugadoresRegistrados ObtenerInstancia()
		{
			if (instancia == null)
			{
				instancia = new JugadoresRegistrados();
			}
			return instancia;
		}
		#endregion

		private List<JugadorRegistrado> jugadores = new List<JugadorRegistrado>();

		public List<JugadorRegistrado> Jugadores
		{
			get { return jugadores; }
		}

		public void Inicializar(XElement xml)
		{
			throw new NotImplementedException();
		}
	}
}
