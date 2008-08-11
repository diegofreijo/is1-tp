using System;
using System.Linq;
using System.Xml.Linq;
using System.Collections.Generic;
using CasinoOnline.Servidor.Modelo;

namespace CasinoOnline.Servidor.Modelo.Fachadas
{
	using IdMesa = Int32;
	using Creditos = Decimal;
	using Nombre = String;

	class AdministradorDeCasino
	{
		#region Singleton
		/// <summary>
		/// La instancia de la clase
		/// </summary>
		private static AdministradorDeCasino instancia = null;

		/// <summary>
		/// Constructor privado para no permitir crear mas instancias que las necesarias
		/// </summary>
		private AdministradorDeCasino()
		{
		}

		/// <summary>
		/// Devuelve la instancia de la clase
		/// </summary>
		public static AdministradorDeCasino ObtenerInstancia()
		{
			if (instancia == null)
			{
				instancia = new AdministradorDeCasino();
			}
			return instancia;
		}
		#endregion

		#region Miembros
		private String detalle_ultima_accion;
		#endregion

		#region Metodos Publicos
		/// 
		/// <param name="pass"></param>
		public Boolean PuedePedirReporteRankingDeJugadores(String pass)
		{
			if (pass == ConfiguracionCasino.ObtenerInstancia().PasswordAdmin)
			{
				detalle_ultima_accion = "Pedido de reporte aceptado";
				return true;
			}
			else
			{
				detalle_ultima_accion = "Contaseña de administrador invalida";
				return false;
			}
		}

		/// 
		/// <param name="pass"></param>
		public Boolean PuedePedirReporteEstadoActual(String pass)
		{
			if (pass == ConfiguracionCasino.ObtenerInstancia().PasswordAdmin)
			{
				detalle_ultima_accion = "Pedido de reporte aceptado";
				return true;
			}
			else
			{
				detalle_ultima_accion = "Contaseña de administrador invalida";
				return false;
			}
		}
		/// 
		/// <param name="pass"></param>
		public Boolean PuedePedirReporteDetalleMovimientosPorJugador(String pass)
		{
			if (pass == ConfiguracionCasino.ObtenerInstancia().PasswordAdmin)
			{
				detalle_ultima_accion = "Pedido de reporte aceptado";
				return true;
			}
			else
			{
				detalle_ultima_accion = "Contaseña de administrador invalida";
				return false;
			}
		}

		public String DetalleUltimaAccion()
		{
			return detalle_ultima_accion;
		}

		/// 
		/// <param name="rueda1"></param>
		/// <param name="rueda2"></param>
		/// <param name="rueda3"></param>
		/// <param name="tipo_jugada"></param>
		/// <param name="pass"></param>
		public Boolean ConfigurarModoDirigidoTragamonedas(String rueda1, String rueda2, String rueda3, String tipo_jugada, String pass)
		{
			throw new NotImplementedException();
		}

		/// 
		/// <param name="dado1"></param>
		/// <param name="dado2"></param>
		/// <param name="tipo_jugada"></param>
		/// <param name="pass"></param>
		public Boolean ConfigurarModoDirigidoCraps(bool resultado_azar, int? dado1, int? dado2, String tipoJugada, String pass)
		{
			if (pass == ConfiguracionCasino.ObtenerInstancia().PasswordAdmin)
			{
				// Si el resultado de los dados esta al azar, lo pongo asi
				if (resultado_azar)
				{
					// Le asigno el resultado a cada mesa de craps
					SelectorResultadoCraps nuevoSelectorResultado = new SelectorResultadoAlAzarCraps();
					foreach (IdMesa mesa in MesasAbiertas.ObtenerInstancia().MesasCraps.Select(m => m.Id).ToList())
					{
						ServidorJugadas.ObtenerInstancia().EstablecerResultadoCraps(mesa, nuevoSelectorResultado);
					}
				}
				else
				{
					// Si hay dados, seteo resultado
					if (dado1 != null && dado2 != null)
					{
						// Le asigno el resultado a cada mesa de craps
						SelectorResultadoCraps nuevoSelectorResultado = new SelectorResultadoDirigidoCraps(new Dado((int)dado1), new Dado((int)dado2));
						foreach (IdMesa mesa in MesasAbiertas.ObtenerInstancia().MesasCraps.Select(m => m.Id).ToList())
						{
							ServidorJugadas.ObtenerInstancia().EstablecerResultadoCraps(mesa, nuevoSelectorResultado);
						}
					}
				}

				// Si hay tipo jugada, seteo tipo jugada
				if (!string.IsNullOrEmpty(tipoJugada))
				{
					// Veo cual tipo de jugada es
					SelectorTipoJugada nuevoSelectorTipoJugada = null;
					switch (tipoJugada)
					{
						case "Azar": nuevoSelectorTipoJugada = new SelectorAzar(); break;
						case "Normal": nuevoSelectorTipoJugada = new SelectorNormal(); break;
						case "TodosPonen": nuevoSelectorTipoJugada = new SelectorTodosPonen(); break;
						case "NoTodosPonen": nuevoSelectorTipoJugada = new SelectorNoTodosPonen(); break;
						case "NoFeliz": nuevoSelectorTipoJugada = new SelectorNoFeliz(); break;
						default:
							throw new ArgumentException("Me vino un tipo de jugada no valido: " + tipoJugada);
					}

					// Le asigno el tipo de jugada a cada mesa de craps
					foreach (IdMesa mesa in MesasAbiertas.ObtenerInstancia().MesasCraps.Select(m => m.Id).ToList())
					{
						ServidorJugadas.ObtenerInstancia().EstablecerTipoJugadaCraps(mesa, nuevoSelectorTipoJugada);
					}
				}

				detalle_ultima_accion = "Configuracion de craps establecida con todo exito";
				return true;
			}
			else
			{
				detalle_ultima_accion = "Contaseña de administrador invalida";
				return false;
			}
		}

		/// 
		/// <param name="mesa"></param>
		/// <param name="pass"></param>
		public Boolean ConfigurarModoDirigidoJugadaFeliz(IdMesa idmesa, String pass)
		{
			// Veo si la contraseña es correcta
			if (pass != ConfiguracionCasino.ObtenerInstancia().PasswordAdmin)
			{
				detalle_ultima_accion = "Contaseña de administrador invalida";
				return false;
			}

			// Veo de que tipo de juego es la mesa
			if (MesasAbiertas.ObtenerInstancia().ObtenerMesaCraps(idmesa) != null)
			{
				ServidorJugadas.ObtenerInstancia().EstablecerTipoJugadaCraps(idmesa, new SelectorFeliz());

				detalle_ultima_accion = "Configuracion feliz establecida con todo exito";
				return true;
			}
			// La parte de tragamonedas no esta implementada
			//else if (MesasAbiertas.ObtenerInstancia().ObtenerMesaTragamonedas(idmesa) != null)
			//{
			//    ServidorJugadas.ObtenerInstancia().EstablecerTipoJugadaTragamonedas(idmesa, new SelectorFeliz());
			//    return true;
			//}
			else
			{
				detalle_ultima_accion = "La mesa seleccionada para ser feliz no existe";
				return false;
			}
		}

		/// 
		/// <param name="configuracion"></param>
		public void InicializarConfiguracion(XElement configuracion)
		{
			ConfiguracionCasino.ObtenerInstancia().Inicializar(configuracion);
		}

		/// 
		/// <param name="lista_clientes"></param>
		public void InicializarJugadoresRegistrados(XElement lista_clientes)
		{
			JugadoresRegistrados.ObtenerInstancia().Inicializar(lista_clientes);
		}

		/// 
		/// <param name="observador"></param>
		public void InicializarMesas(MensajeroDeSalida.IMesaObserver observador)
		{
			MesasAbiertas.ObtenerInstancia().Inicializar(observador);
		}

		public List<Nombre> ObtenerJugadoresMasGanadores()
		{
			// Levanto los premios
			Dictionary<Nombre, Creditos> ganancias = new Dictionary<string,decimal>();

			// Calculo las ganancias de cada jugador
			foreach(Premio premio in HistorialJugadas.ObtenerInstancia().JugadasCraps.SelectMany(j => j.Premios))
			{
				if(ganancias.ContainsKey(premio.Apostador.Nombre))
				{
					ganancias[premio.Apostador.Nombre] += premio.MontoNormal + premio.MontoFeliz - premio.MontoApostado - premio.MontoTodosPonen;
				}
				else
				{
					ganancias.Add(premio.Apostador.Nombre, premio.MontoNormal + premio.MontoFeliz - premio.MontoApostado - premio.MontoTodosPonen);
				}
			}

			// Me quedo con los mejores 3
			List<Nombre> ret = ganancias.OrderBy(k => k.Value).Select(k => k.Key).Take(3).ToList();

			return ret;
		}

		public List<Nombre> ObtenerJugadoresMasPerdedores()
		{
			// Levanto los premios
			Dictionary<Nombre, Creditos> ganancias = new Dictionary<string, decimal>();

			// Calculo las ganancias de cada jugador
			foreach (Premio premio in HistorialJugadas.ObtenerInstancia().JugadasCraps.SelectMany(j => j.Premios))
			{
				if (ganancias.ContainsKey(premio.Apostador.Nombre))
				{
					ganancias[premio.Apostador.Nombre] += premio.MontoNormal + premio.MontoFeliz - premio.MontoApostado - premio.MontoTodosPonen;
				}
				else
				{
					ganancias.Add(premio.Apostador.Nombre, premio.MontoNormal + premio.MontoFeliz - premio.MontoApostado - premio.MontoTodosPonen);
				}
			}

			// Me quedo con los peores 3
			List<Nombre> ret = ganancias.OrderBy(k => k.Value).Select(k => k.Key).Reverse().Take(3).ToList();

			return ret;
		}

		public Creditos ObtenerSaldoCasino()
		{
			return ConfiguracionCasino.ObtenerInstancia().SaldoCasino;
		}

		public Dictionary<Nombre, Creditos> ObtenerJugadoresConSaldo()
		{
			return UsuariosEnCasino.ObtenerInstancia().Jugadores.ToDictionary(j => j.Nombre, j => j.Saldo);
		}

		public List<Creditos> ObtenerFichasValidas()
		{
			return ConfiguracionCasino.ObtenerInstancia().FichasValidas;
		}

		public List<PremioDetalleMovimientoJugadores> DetalleMovimientoJugadores()
		{
			// Levanto todas las apuestas y genero el resultado (no considero los de tragamonedas)
			return HistorialJugadas.ObtenerInstancia().JugadasCraps.SelectMany(j => j.Premios)
				.Select(p => new PremioDetalleMovimientoJugadores(
					p.Apostador.Nombre,
					p.NombreTipoApuesta,
					p.MontoNormal,
					p.MontoFeliz,
					p.MontoTodosPonen,
					0
				)).ToList();
		}

		public class PremioDetalleMovimientoJugadores
		{
			public Nombre jugador;
			public String tipoApuesta;
			public Creditos normal;
			public Creditos feliz;
			public Creditos todosPonen;
			public Creditos progresivo;

			public PremioDetalleMovimientoJugadores(Nombre jugador, String tipoApuesta, Creditos normal, Creditos feliz,
				Creditos todosPonen, Creditos progresivo)
			{
				this.jugador = jugador;
				this.tipoApuesta = tipoApuesta;
				this.normal = normal;
				this.feliz = feliz;
				this.todosPonen = todosPonen;
				this.progresivo = progresivo;
			}
		}

		#endregion
	}

}
