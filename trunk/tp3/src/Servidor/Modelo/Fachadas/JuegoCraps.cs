using System;
using System.Collections.Generic;
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
		public Boolean EntrarCraps(Nombre nombre_jugador, int? idmesa)
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
						mesa = CrearMesaCraps();
						detalle_ultima_accion = "Se creo una nueva mesa y el jugador acaba de ingresar a ella";
					}
					else
					{
						mesa = MesasAbiertas.ObtenerInstancia().ObtenerMesaCraps((int)idmesa);
						detalle_ultima_accion = "El jugador entro a la mesa que selecciono";
					}

					// falta el e/h
					throw new NotImplementedException();

					// Agrego al jugador a la mes
					mesa.JugadoresEnMesa.Add(jugador);
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
		public Boolean SalirCraps(Nombre jugador, IdMesa mesa)
		{
			throw new NotImplementedException();
		}

		/// 
		/// <param name="jugador"></param>
		/// <param name="mesa"></param>
		/// <param name="tipo_apuesta"></param>
		/// <param name="fichas"></param>
		/// <param name="puntaje_apostado"></param>
		public Boolean ApostarCraps(Nombre jugador, IdMesa mesa, String tipo_apuesta, Dictionary<Creditos, int> fichas, int puntaje_apostado)
		{
			throw new NotImplementedException();
		}

		/// 
		/// <param name="jugador"></param>
		/// <param name="mesa"></param>
		public Boolean TirarCraps(Nombre jugador, IdMesa mesa)
		{

			throw new NotImplementedException();
		}

		/// 
		/// <param name="mesa"></param>
		public int Dado1UltimoTiro(IdMesa mesa)
		{

			throw new NotImplementedException();
		}

		/// 
		/// <param name="mesa"></param>
		public int Dado2UltimoTiro(IdMesa mesa)
		{

			throw new NotImplementedException();
		}

		public String TipoJugadaUltimoTiro()
		{

			throw new NotImplementedException();
		}

		/// 
		/// <param name="mesa"></param>
		public List<Nombre> JugadoresEnMesa(IdMesa mesa)
		{

			throw new NotImplementedException();
		}

		/// 
		/// <param name="mesa"></param>
		public Nombre TiradorProximoTiro(IdMesa mesa)
		{

			throw new NotImplementedException();
		}

		/// 
		/// <param name="mesa"></param>
		public Boolean EsProximoTiroDeSalida(IdMesa mesa)
		{

			throw new NotImplementedException();
		}

		/// 
		/// <param name="mesa"></param>
		public int ValorPuntoProximoTiro(IdMesa mesa)
		{

			throw new NotImplementedException();
		}

		/// 
		/// <param name="mesa"></param>
		public Nombre TiradorUltimoTiro(IdMesa mesa)
		{

			throw new NotImplementedException();
		}

		/// 
		/// <param name="mesa"></param>
		public List<KeyValuePair<KeyValuePair<KeyValuePair<Nombre, Creditos>, Creditos>, Creditos>> PremiosUltimoTiro(IdMesa mesa)
		{

			throw new NotImplementedException();
		}

		/// 
		/// <param name="mesa"></param>
		public List<KeyValuePair<KeyValuePair<KeyValuePair<Nombre, String>, String>, Dictionary<Creditos, int>>> ApuestasVigentes(IdMesa mesa)
		{

			throw new NotImplementedException();
		}

		public String DetalleUltimaAccion()
		{

			throw new NotImplementedException();
		}

		public List<IdMesa> ObtenerMesasCraps()
		{

			throw new NotImplementedException();
		}

		#endregion

		#region Metodos Privados
		private MesaCraps CrearMesaCraps()
		{
			throw new NotImplementedException();
		}
		#endregion
	}
}
