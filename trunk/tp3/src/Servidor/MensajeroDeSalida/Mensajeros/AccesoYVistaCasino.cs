using System;
using System.Linq;
using CasinoOnline.Servidor.Modelo;
using CasinoOnline.Servidor.Comunicacion;

namespace CasinoOnline.Servidor.MensajeroDeSalida.Mensajeros
{
	using IdMesa = Int32;
	using IdTerminalVirtual = Int32;
	using Nombre = String;
	using Creditos = Decimal;
	using System.Xml.Linq;
	using CasinoOnline.Servidor.Utils;
	using System.Collections.Generic;

	class AccesoYVistaCasino
	{
		#region Singleton
		/// <summary>
		/// La instancia de la clase
		/// </summary>
		private static AccesoYVistaCasino instancia = null;

		/// <summary>
		/// Constructor privado para no permitir crear mas instancias que las necesarias
		/// </summary>
		private AccesoYVistaCasino()
		{
		}

		/// <summary>
		/// Devuelve la instancia de la clase
		/// </summary>
		public static AccesoYVistaCasino ObtenerInstancia()
		{
			if (instancia == null)
			{
				instancia = new AccesoYVistaCasino();
			}
			return instancia;
		}
		#endregion


		#region Manejadores

		/// 
		/// <param name="idt"></param>
		/// <param name="idu"></param>
		/// <param name="descripcion"></param>
		/// <param name="aceptado"></param>
		public void ResponderEntrada(IdTerminalVirtual idt, Nombre usuario, String descripcion, Boolean aceptado)
		{
			// Averiguo el modoAcceso
			string modoAcceso = "";
			string saldo = "";
			if (aceptado)
			{
				if (Modelo.Fachadas.LobbyCasino.ObtenerInstancia().ObservadoresEnCasino().
					Exists(delegate(string nombre) { return nombre == usuario; }))
				{
					modoAcceso = "observador";
				}
				else
				{
					modoAcceso = "jugador";
					saldo = Modelo.Fachadas.AdministradorDeCasino.ObtenerInstancia().
						ObtenerJugadoresConSaldo()[usuario].ToString();
				}
			}

			// Genero el XML de salida
			XElement parametros = new XElement("entradaCasino", new object[]{
				new XAttribute("vTerm", idt),
				new XAttribute("usuario", usuario),
				new XElement("aceptado", aceptado ? "si" : "no"),
				new XElement("modoAcceso", modoAcceso),
				new XElement("saldo", saldo),
				new XElement("fichasHabilitadas", 
					Modelo.Fachadas.AdministradorDeCasino.ObtenerInstancia().ObtenerFichasValidas().
					Select(c => new XElement("valorFicha", c)).ToList()),
				new XElement("descripcion", descripcion)
			});

			// Genero la respuesta
			Respuesta respuesta = new Respuesta("respuestaEntradaCasino", idt, parametros);

			// Envio el XML de salida
			DespachadorRespuestas.ObtenerInstancia().DespacharRespuesta(respuesta);
		}
		/// 
		/// <param name="idt"></param>
		/// <param name="idu"></param>
		/// <param name="descripcion"></param>
		/// <param name="aceptado"></param>
		public void ResponderSalida(IdTerminalVirtual idt, Nombre usuario, String descripcion, Boolean aceptado)
		{
			// Genero el XML de salida
			XElement parametros = new XElement("salidaCasino", new object[]{
				new XAttribute("vTerm", idt),
				new XAttribute("usuario", usuario),
				new XElement("aceptado", aceptado ? "si" : "no"),
				new XElement("descripcion", descripcion)
			});

			// Genero la respuesta
			Respuesta respuesta = new Respuesta("respuestaSalidaCasino", idt, parametros);

			// Envio el XML de salida
			DespachadorRespuestas.ObtenerInstancia().DespacharRespuesta(respuesta);
		}
		/// 
		/// <param name="idt"></param>
		/// <param name="idu"></param>
		public void ResponderEstadoCasino(IdTerminalVirtual idterminal, Nombre usuario, Boolean aceptado)
		{
			// Genero el XML de salida
			XElement parametros = new XElement("estadoCasino", new object[] {
				new XAttribute("vTerm", idterminal),
				new XAttribute("usuario", usuario),
				new XAttribute("aceptado", aceptado ? "si" : "no")
			});

			if(aceptado)
			{
				// Jugadores
				XElement jugadores = new XElement("jugadores");
				foreach (Nombre jugador in Modelo.Fachadas.LobbyCasino.ObtenerInstancia().JugadoresEnCasino())
				{
					jugadores.Add(new XElement("jugador", new XAttribute("nombre", jugador)));
				}
				parametros.Add(jugadores);

				// Observadores
				XElement observadores = new XElement("observadores");
				foreach (Nombre jugador in Modelo.Fachadas.LobbyCasino.ObtenerInstancia().ObservadoresEnCasino())
				{
					observadores.Add(new XElement("observador", new XAttribute("nombre", jugador)));
				}
				parametros.Add(observadores);

				// Juegos
				XElement juegos = new XElement("juegos");
				XElement craps = new XElement("craps");
				juegos.Add(new XElement("tragamonedas"));
				juegos.Add(craps);
				parametros.Add(juegos);

				// Mesas craps
				XElement mesasCraps = new XElement("mesasCraps");
				craps.Add(mesasCraps);
				foreach (IdMesa idmesa in Modelo.Fachadas.JuegoCraps.ObtenerInstancia().ObtenerMesasCraps())
				{
					XElement mesaCraps = new XElement("mesaCraps", new XAttribute("id", idmesa));
					mesasCraps.Add(mesaCraps);

					// Jugadores
					XElement jugadoresEnMesa = new XElement("jugadores");
					foreach (Nombre jugador in Modelo.Fachadas.JuegoCraps.ObtenerInstancia().JugadoresEnMesa(idmesa))
					{
						jugadoresEnMesa.Add(new XElement("jugador", jugador));
					}
					mesaCraps.Add(jugadoresEnMesa);

					// Proximo tiro
					XElement proximoTiro = new XElement("proximoTiro", new object[] {
						new XElement("tirador", Modelo.Fachadas.JuegoCraps.ObtenerInstancia().TiradorProximoTiro(idmesa)),
						new XElement("tiroSalida", Modelo.Fachadas.JuegoCraps.ObtenerInstancia().EsProximoTiroDeSalida(idmesa) ? "si" : "no"),
						new XElement("punto", Modelo.Fachadas.JuegoCraps.ObtenerInstancia().ValorPuntoProximoTiro(idmesa) != null ?
							((int)Modelo.Fachadas.JuegoCraps.ObtenerInstancia().ValorPuntoProximoTiro(idmesa)).ToString() : ""),
					});
					mesaCraps.Add(proximoTiro);

					// Ultimo tiro
					XElement ultimoTiro = new XElement("ultimoTiro", new object[] {
						new XElement("id", Modelo.Fachadas.JuegoCraps.ObtenerInstancia().IdUltimoTiro(idmesa)),
						new XElement("tirador", Modelo.Fachadas.JuegoCraps.ObtenerInstancia().TiradorUltimoTiro(idmesa)),
						new XElement("resultado", new object[] {
							new XElement("dado1", Modelo.Fachadas.JuegoCraps.ObtenerInstancia().Dado1UltimoTiro(idmesa).ToString()),
							new XElement("dado2", Modelo.Fachadas.JuegoCraps.ObtenerInstancia().Dado2UltimoTiro(idmesa).ToString())
						})
					});

					mesaCraps.Add(ultimoTiro);
				}

				// Pozos
				parametros.Add(new XElement("pozosCasino",
					new XElement("pozoFeliz", Modelo.Fachadas.LobbyCasino.ObtenerInstancia().MontoPozoFeliz().ToString())
				));
			}

			// Genero la respuesta
			Respuesta respuesta = new Respuesta("respuestaEstadoCasino", idterminal, parametros);

			// Envio el XML de salida
			DespachadorRespuestas.ObtenerInstancia().DespacharRespuesta(respuesta);
		}

		#endregion
	}
}
