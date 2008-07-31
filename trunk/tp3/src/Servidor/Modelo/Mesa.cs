using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CasinoOnline.Servidor.Modelo
{
	abstract class Mesa
	{
		#region Miembros
		
		protected IdMesa id;
		protected List<Jugador> jugadores_en_mesa;
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

		#endregion
	}
}
