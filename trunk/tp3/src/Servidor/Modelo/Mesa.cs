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
		protected List<Jugador> jugadores_en_mesa = new List<Jugador>();
		protected Jugador proximo_tirador = null;
		protected Jugada ultima_jugada = null;

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
			get { return  jugadores_en_mesa; }
		}

		#endregion


		#region Metodos Publicos

		public virtual void AgregarJugador(Jugador jugador)
		{
			jugadores_en_mesa.Add(jugador);
		}
		public virtual void QuitarJugador(Jugador jugador)
		{
			jugadores_en_mesa.Remove(jugador);

			// AGREGADO: Si no hay nadie mas jugando en mi, me mato
			if (jugadores_en_mesa.Count == 0)
			{
				MesasAbiertas.ObtenerInstancia().BorrarMesaCraps(this.id);
			}
		}


		#endregion
	}
}
