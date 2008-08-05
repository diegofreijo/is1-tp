using System;
using System.Collections.Generic;
using System.Linq;
using CasinoOnline.Servidor.Modelo;

namespace CasinoOnline.Servidor.Modelo.Fachadas
{
	using Creditos = Decimal;
	using Nombre = String;
	using IdMesa = Int32;

	class JuegoCraps
	{
		#region Singleton
		/// <summary>
		/// La instancia de la clase
		/// </summary>
		private static JuegoCraps instancia = null;

		/// <summary>
		/// Constructor privado para no permitir crear mas instancias que las necesarias
		/// </summary>
		private JuegoCraps()
		{
		}

		/// <summary>
		/// Devuelve la instancia de la clase
		/// </summary>
		public static JuegoCraps ObtenerInstancia()
		{
			if (instancia == null)
			{
				instancia = new JuegoCraps();
			}
			return instancia;
		}
		#endregion

		#region Miembros
		private String detalle_ultima_accion;
		#endregion

		#region Metodos Publicos

		/// 
		/// <param name="jug"></param>
		/// <param name="mesa"></param>
		public Boolean EntrarCraps(Nombre nombre_jugador, ref int? idmesa)
		{
			Boolean ret = false;
			Mesa mesa;

			// Veo si el jugador ingreso
			Jugador jugador = UsuariosEnCasino.ObtenerInstancia().ObtenerJugador(nombre_jugador);
			if (jugador != null)
			{
				// Veo si el jugador no esta en una mesa
				if (jugador.MesaElegida == null)
				{
					// Veo si hay que crear la mesa
					if (idmesa == null)
					{
						mesa = MesasAbiertas.ObtenerInstancia().CrearMesaCraps();
						idmesa = mesa.Id;
						detalle_ultima_accion = "Se creo una nueva mesa y el jugador acaba de ingresar a ella";
					}
					else
					{
						// AGREGADO: Veo si la mesa elegida existe
						mesa = MesasAbiertas.ObtenerInstancia().ObtenerMesaCraps((int)idmesa);
						if (mesa != null)
						{
							detalle_ultima_accion = "El jugador entro a la mesa que selecciono";
						}
						else
						{
							detalle_ultima_accion = "La mesa elegida no existe";
							return false;
						}
					}

					// Agrego al jugador a la mesa
					mesa.AgregarJugador(jugador);
					jugador.ElegirMesa(mesa);
					ret = true;
				}
				else
				{
					// Ya estaba en una mesa
					detalle_ultima_accion = "El jugador ya estaba en una mesa, no se puede ingresar a una nueva.";
					ret = false;
				}
			}
			else
			{
				// El usuario no es un jugador
				detalle_ultima_accion = "El usuario no ingreso o no ingreso al casino en modo jugador.";
				ret = false;
			}

			return ret;
		}
		public Boolean SalirCraps(Nombre nombre_jugador, IdMesa idmesa)
		{
			// Veo si el jugador ingreso
			Jugador jugador = UsuariosEnCasino.ObtenerInstancia().ObtenerJugador(nombre_jugador);
			if (jugador != null)
			{
				// Veo si el jugador esta en la mesa que especifico
				if (jugador.MesaElegida != null  &&  jugador.MesaElegida.Id == idmesa)
				{
					// Saco al jugador de la mesa
					Mesa mesa = MesasAbiertas.ObtenerInstancia().ObtenerMesaCraps(idmesa);
					mesa.QuitarJugador(jugador);
					jugador.ElegirMesa(null);
					detalle_ultima_accion = "El jugador se fue de la mesa que eligio.";
					return true;
				}
				else
				{
					// No estaba en esa mesa
					detalle_ultima_accion = "El jugador no estaba en la mesa de la que decidio salir.";
					return false;
				}
			}
			else
			{
				// El usuario no es un jugador
				detalle_ultima_accion = "El usuario no ingreso al casino o no ingreso en modo jugador.";
				return false;
			}
		}

		/// 
		/// <param name="jugador"></param>
		/// <param name="mesa"></param>
		/// <param name="tipo_apuesta"></param>
		/// <param name="fichas"></param>
		/// <param name="puntaje_apostado"></param>
		public Boolean ApostarCraps(Nombre jugador, IdMesa idmesa, String tipo_apuesta, Dictionary<Creditos, int> fichas, int puntaje_apostado)
		{
			throw new NotImplementedException();
		}

		/// 
		/// <param name="jugador"></param>
		/// <param name="mesa"></param>
		public Boolean TirarCraps(Nombre jugador, IdMesa idmesa)
		{
			throw new NotImplementedException();
		}

		/// 
		/// <param name="mesa"></param>
		public int? Dado1UltimoTiro(IdMesa idmesa)
		{
			Jugada ultimaJugada = MesasAbiertas.ObtenerInstancia().ObtenerMesaCraps(idmesa).UltimaJugada;
			return ultimaJugada != null ? ((ResultadoCraps)ultimaJugada.Resultado).Dado1.Numero : (int?)null;
		}

		/// 
		/// <param name="mesa"></param>
		public int? Dado2UltimoTiro(IdMesa idmesa)
		{
			Jugada ultimaJugada = MesasAbiertas.ObtenerInstancia().ObtenerMesaCraps(idmesa).UltimaJugada;
			return ultimaJugada != null ? ((ResultadoCraps)ultimaJugada.Resultado).Dado2.Numero : (int?)null;
		}

		public String TipoJugadaUltimoTiro(IdMesa idmesa)
		{
			Jugada ultimaJugada = MesasAbiertas.ObtenerInstancia().ObtenerMesaCraps(idmesa).UltimaJugada;
			return ultimaJugada != null ? ultimaJugada.TipoJugada.ObtenerNombreTipoJugada() : "";
		}

		/// 
		/// <param name="mesa"></param>
		public List<Nombre> JugadoresEnMesa(IdMesa idmesa)
		{
			return MesasAbiertas.ObtenerInstancia().ObtenerMesaCraps(idmesa).JugadoresEnMesa.Select(j => j.Nombre).ToList();
		}

		/// 
		/// <param name="mesa"></param>
		public Nombre TiradorProximoTiro(IdMesa idmesa)
		{
			Jugador proximoTirador = MesasAbiertas.ObtenerInstancia().ObtenerMesaCraps(idmesa).ProximoTirador;
			return proximoTirador != null ? proximoTirador.Nombre : "";
		}

		/// 
		/// <param name="mesa"></param>
		public Boolean EsProximoTiroDeSalida(IdMesa idmesa)
		{
			return MesasAbiertas.ObtenerInstancia().ObtenerMesaCraps(idmesa).Estado == EstadoRondaCraps.EstanSaliendo;
		}

		/// 
		/// <param name="mesa"></param>
		public int? ValorPuntoProximoTiro(IdMesa idmesa)
		{
			return MesasAbiertas.ObtenerInstancia().ObtenerMesaCraps(idmesa).Punto;
		}

		/// 
		/// <param name="mesa"></param>
		public Nombre TiradorUltimoTiro(IdMesa idmesa)
		{
			Jugada ultimaJugada = MesasAbiertas.ObtenerInstancia().ObtenerMesaCraps(idmesa).UltimaJugada;
			return ultimaJugada != null ? ultimaJugada.Tirador.Nombre : "";
		}

		/// 
		/// <param name="mesa"></param>
		public List<KeyValuePair<KeyValuePair<KeyValuePair<Nombre, Creditos>, Creditos>, Creditos>> PremiosUltimoTiro(IdMesa idmesa)
		{
			List<KeyValuePair<KeyValuePair<KeyValuePair<Nombre, Creditos>, Creditos>, Creditos>> ret = new List<KeyValuePair<KeyValuePair<KeyValuePair<string,decimal>,decimal>,decimal>>();
			JugadaCraps ultimaJugada = (JugadaCraps)MesasAbiertas.ObtenerInstancia().ObtenerMesaCraps(idmesa).UltimaJugada;
			if (ultimaJugada != null)
			{
				foreach (Premio premio in ultimaJugada.Premios)
				{
					ret.Add(new KeyValuePair<KeyValuePair<KeyValuePair<Nombre, Creditos>, Creditos>, Creditos>(
						new KeyValuePair<KeyValuePair<Nombre, Creditos>, Creditos>(
							new KeyValuePair<Nombre, Creditos>(premio.Apostador.Nombre, premio.MontoNormal),
							premio.MontoFeliz),
						premio.MontoTodosPonen));
				}
			}

			return ret;
		}

		/// 
		/// <param name="mesa"></param>
		public List<KeyValuePair<KeyValuePair<KeyValuePair<Nombre, String>, String>, Dictionary<Creditos, int>>> ApuestasVigentes(IdMesa idmesa)
		{
			List<KeyValuePair<KeyValuePair<KeyValuePair<Nombre, String>, String>, Dictionary<Creditos, int>>> ret = new List<KeyValuePair<KeyValuePair<KeyValuePair<string, string>, string>, Dictionary<decimal, int>>>();
			foreach(ApuestaCraps apuesta in MesasAbiertas.ObtenerInstancia().ObtenerMesaCraps(idmesa).Apuestas)
			{
				ret.Add(new KeyValuePair<KeyValuePair<KeyValuePair<Nombre, String>, String>, Dictionary<Creditos, int>>(
					new KeyValuePair<KeyValuePair<Nombre, String>, String>(
						new KeyValuePair<Nombre, String>(apuesta.Apostador.Nombre, apuesta.ObtenerNombreTipoApuesta()),
						apuesta.ObtenerPuntajeApostado() != null ? apuesta.ObtenerPuntajeApostado().ToString() : ""),
					apuesta.Fichas)
				);
			}

			return ret;
		}

		public String DetalleUltimaAccion()
		{
			return detalle_ultima_accion;
		}

		public List<IdMesa> ObtenerMesasCraps()
		{
			return MesasAbiertas.ObtenerInstancia().MesasCraps.Select(m => m.Id).ToList();
		}

		#endregion
	}
}
