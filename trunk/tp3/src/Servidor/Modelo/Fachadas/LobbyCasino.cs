using System;
using System.Collections.Generic;
using System.Linq;
using CasinoOnline.Servidor.Modelo;

namespace CasinoOnline.Servidor.Modelo.Fachadas
{
	using Nombre = String;
	using Creditos = Decimal;

	class LobbyCasino
	{
		#region Singleton
		/// <summary>
		/// La instancia de la clase
		/// </summary>
		private static LobbyCasino instancia = null;

		/// <summary>
		/// Constructor privado para no permitir crear mas instancias que las necesarias
		/// </summary>
		private LobbyCasino()
		{
		}

		/// <summary>
		/// Devuelve la instancia de la clase
		/// </summary>
		public static LobbyCasino ObtenerInstancia()
		{
			if (instancia == null)
			{
				instancia = new LobbyCasino();
			}
			return instancia;
		}
		#endregion

		#region Miembros
		private String detalle_ultima_accion;
		#endregion

		#region Metodos Publicos

		/// 
		/// <param name="usuario"></param>
		/// <param name="modo"></param>
		public Boolean EntrarCasino(Nombre usuario, String modo)
		{
			// Existe otro jugador con el mismo nombre?
			if (UsuariosEnCasino.ObtenerInstancia().ObtenerJugador(usuario) != null)
			{
				detalle_ultima_accion = "Ya existe un jugador con el mismo nombre";
				return false;
			}

			// Veo como seguir segun el modo
			if (modo == "observador")
			{
				// Existe otro observador con el mismo nombre?
				if (UsuariosEnCasino.ObtenerInstancia().ObtenerObservador(usuario) != null)
				{
					detalle_ultima_accion = "Ya existe un oservador con el mismo nombre";
					return false;
				}

				// Lo agrego
				UsuariosEnCasino.ObtenerInstancia().AgregarObservador(new Observador(usuario));

				// Le doy la bienvenida
				detalle_ultima_accion = "Bienvenido! Acordate que si queres ganar platita tenes que ser jugador";
			}
			else if (modo == "jugador")
			{
				// Esta autorizado para acceder?
				if (!JugadoresRegistrados.ObtenerInstancia().Jugadores.Select(jr => jr.Nombre).ToList().
					Exists(delegate(string nombre) { return nombre == usuario; }))
				{
					detalle_ultima_accion = "El usuario no se encuentra entre los jugadores autorizados";
					return false;
				}

				// Si estaba como observador, saco a su observador correspondiente
				if (UsuariosEnCasino.ObtenerInstancia().ObtenerObservador(usuario) != null)
				{
					UsuariosEnCasino.ObtenerInstancia().QuitarObservador(usuario);
				}

				// Creo al jugador
				JugadorRegistrado nuevo = JugadoresRegistrados.ObtenerInstancia().Jugadores.Single(jr => jr.Nombre == usuario);
				UsuariosEnCasino.ObtenerInstancia().AgregarJugador(nuevo.ConstructorJugador.CrearJugador(nuevo.Nombre, nuevo.Saldo));					
				
				// Le doy la bienvenida
				detalle_ultima_accion = "Bienvenido! Espero que gastes mucha platita y ganes poca";
			}
			else
			{
				throw new ArgumentException("Modo de usuario desconocido");
			}

			return true;
		}

		/// 
		/// <param name="usuario"></param>
		public Boolean SalirCasino(Nombre usuario)
		{
			bool ret = false;

			// Veo si el usuario es un observador o jugador
			Observador observador = UsuariosEnCasino.ObtenerInstancia().ObtenerObservador(usuario);
			if (observador == null)
			{
				// No era observador, veo si es jugador
				Jugador jugador = UsuariosEnCasino.ObtenerInstancia().ObtenerJugador(usuario);
				if (jugador == null)
				{
					// Tampoco era jugador, el usuario no ingreso al casino
					detalle_ultima_accion = "El usuario que intenta salir no ingreso al casino";
					ret = false;
				}
				else
				{
					// Veo si esta o no en una mesa
					if (jugador.MesaElegida != null)
					{
						detalle_ultima_accion = "Antes de salir del casino el jugador debe salir de la mesa";
						ret = false;
					}
					else
					{
						// Saco al jugador
						UsuariosEnCasino.ObtenerInstancia().QuitarJugador(usuario);
						detalle_ultima_accion = "Que vuelvas pronto para gastar mas platita!";
						ret = true;
					}
				}
			}
			else
			{
				// Saco al observador
				UsuariosEnCasino.ObtenerInstancia().QuitarObservador(usuario);
				detalle_ultima_accion = "Que vuelvas pronto pero como jugador asi gastas platita!";
				ret = true;
			}

			return ret;
		}

		/// 
		/// <param name="usuario"></param>
		public Boolean PedirEstadoCasino(Nombre usuario)
		{
			// Esta el usuario en el casino?
			return UsuariosEnCasino.ObtenerInstancia().ObtenerJugador(usuario) != null
				|| UsuariosEnCasino.ObtenerInstancia().ObtenerObservador(usuario) != null;
		}

		public String DetalleUltimaAccion()
		{
			return this.detalle_ultima_accion;
		}

		public List<Nombre> JugadoresEnCasino()
		{
			return UsuariosEnCasino.ObtenerInstancia().Jugadores.Select(j => j.Nombre).ToList();
		}

		public List<Nombre> ObservadoresEnCasino()
		{
			return UsuariosEnCasino.ObtenerInstancia().Observadores.Select(o => o.Nombre).ToList();
		}

		public Creditos MontoPozoFeliz()
		{
			return Pozos.ObtenerInstancia().ProzoFeliz.Monto;
		}

		public Creditos MontoPozoProgresivo()
		{
			throw new NotImplementedException();
		}

		#endregion

	}
}
