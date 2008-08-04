using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CasinoOnline.Servidor.Modelo
{
	using IdMesa = Int32;

	abstract class Mesa
	{
		#region Miembros
		
		protected IdMesa id;
		private List<Jugador> jugadores_en_mesa;
		protected Jugador proximo_tirador;
		protected Jugada ultima_jugada;

		#endregion


		#region Propiedades

		public IdMesa Id
		{
			get { return id; }
		}
		public Jugada UltimaJugada
		{
			get { return ultima_jugada; }
		}
		public Jugador ProximoTirador
		{
			get { return proximo_tirador; }
		}
		public List<Jugador> JugadoresEnMesa
		{
			get { return jugadores_en_mesa; }
		}

		#endregion
	}
}
