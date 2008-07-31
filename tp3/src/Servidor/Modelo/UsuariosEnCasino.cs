using System.Collections.Generic;
using System;

namespace CasinoOnline.Servidor.Modelo
{
	using Nombre = String;

	public class UsuariosEnCasino 
	{
		#region Singleton
		/// <summary>
		/// La instancia de la clase
		/// </summary>
		private static UsuariosEnCasino instancia = null;

		/// <summary>
		/// Constructor privado para no permitir crear mas instancias que las necesarias
		/// </summary>
		private UsuariosEnCasino()
		{
		}

		/// <summary>
		/// Devuelve la instancia de la clase
		/// </summary>
		public static UsuariosEnCasino ObtenerInstancia()
		{
			if (instancia == null)
			{
				instancia = new UsuariosEnCasino();
			}
			return instancia;
		}
		#endregion

		#region Miembros
		private List<Jugador> jugadores = new List<Jugador>();
		private List<Observador> observadores = new List<Observador>();
		#endregion

		#region Propiedades
		public List<Jugador> Jugadores
		{
			get { return jugadores; }
			set { jugadores = value; }
		}
		
		public List<Observador> Observadores
		{
			get { return observadores; }
			set { observadores = value; }
		}
		#endregion

		#region Metodos Publicos
		public Jugador ObtenerJugador(Nombre nombre)
		{
			throw new NotImplementedException();
		}

		public Observador ObtenerObservador(Nombre nombre)
		{
			throw new NotImplementedException();
		}

		public void AgregarJugador(Jugador jugador)
		{
			throw new NotImplementedException();
		}

		public void AgregarObservador(Observador observador)
		{
			throw new NotImplementedException();
		}

		public void QuitarJugador(Nombre nombre)
		{
			throw new NotImplementedException();
		}

		public void QuitarObservador(Nombre nombre)
		{
			throw new NotImplementedException();
		}
		#endregion
	}
}
