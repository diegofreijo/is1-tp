using System;
using CasinoOnline.Servidor.Comunicacion;

namespace CasinoOnline.Servidor.MensajeroDeSalida.Mensajeros
{
	using IdMesa = Int32;
	using IdTerminalVirtual = Int32;
	using Nombre = String;
	using Creditos = Decimal;
	using System.Xml.Linq;
	using System.Collections.Generic;

	class AccesoYVistaCraps
	{
		#region Singleton
		/// <summary>
		/// La instancia de la clase
		/// </summary>
		private static AccesoYVistaCraps instancia = null;

		/// <summary>
		/// Constructor privado para no permitir crear mas instancias que las necesarias
		/// </summary>
		private AccesoYVistaCraps()
		{
		}

		/// <summary>
		/// Devuelve la instancia de la clase
		/// </summary>
		public static AccesoYVistaCraps ObtenerInstancia()
		{
			if (instancia == null)
			{
				instancia = new AccesoYVistaCraps();
			}
			return instancia;
		}
		#endregion



		/// 
		/// <param name="idt"></param>
		/// <param name="idu"></param>
		/// <param name="idm"></param>
		/// <param name="aceptado"></param>
		/// <param name="descripcion"></param>
		public void ResponderEntradaCraps(IdTerminalVirtual idterminal, Nombre usuario, int? idmesa, Boolean aceptado, String descripcion)
		{
			// Genero el XML de salida
			XElement parametros = new XElement("entradaCraps", new object[] {
				new XAttribute("vTerm", idterminal),
				new XAttribute("usuario", usuario),
				new XAttribute("mesa", idmesa != null ? idmesa.ToString() : ""),
				new XElement("aceptado", aceptado ? "si" : "no"),
				new XElement("descripcion", descripcion)
			});

			// Genero la respuesta
			Respuesta respuesta = new Respuesta("respuestaEntradaCraps", idterminal, parametros);

			// Envio el XML de salida
			DespachadorRespuestas.ObtenerInstancia().DespacharRespuesta(respuesta);
		}

		/// 
		/// <param name="idt"></param>
		/// <param name="idu"></param>
		/// <param name="idm"></param>
		/// <param name="aceptado"></param>
		/// <param name="descripcion"></param>
		public void ResponderSalidaCraps(IdTerminalVirtual idterminal, Nombre usuario, IdMesa idmesa, Boolean aceptado, String descripcion)
		{
			// Genero el XML de salida
			XElement parametros = new XElement("salidaCraps", new object[] {
				new XAttribute("vTerm", idterminal),
				new XAttribute("usuario", usuario),
				new XAttribute("mesa", idmesa),
				new XElement("aceptado", aceptado ? "si" : "no"),
				new XElement("descripcion", descripcion)
			});

			// Genero la respuesta
			Respuesta respuesta = new Respuesta("respuestaSalidaCraps", idterminal, parametros);

			// Envio el XML de salida
			DespachadorRespuestas.ObtenerInstancia().DespacharRespuesta(respuesta);
		}

		/// 
		/// <param name="idt"></param>
		/// <param name="idu"></param>
		/// <param name="idm"></param>
		public void NotificarEstadoCraps(IdTerminalVirtual idterminal, Nombre usuario, IdMesa idmesa)
		{
			// Genero el XML de salida
			XElement parametros = new XElement("estadoMesaCraps", new object[] {
				new XAttribute("vTerm", idterminal),
				new XAttribute("usuario", usuario),
				new XAttribute("mesa", idmesa)
			});

			// Jugadores
			XElement jugadores = new XElement("jugadores");
			foreach (Nombre jugador in Modelo.Fachadas.JuegoCraps.ObtenerInstancia().JugadoresEnMesa(idmesa))
			{
				jugadores.Add(new XElement("jugador", jugador));
			}
			parametros.Add(jugadores);

			// Proximo tiro
			XElement proximoTiro = new XElement("proximoTiro", new object[] {
				new XElement("tirador", Modelo.Fachadas.JuegoCraps.ObtenerInstancia().TiradorProximoTiro(idmesa)),
				new XElement("tiroSalida", Modelo.Fachadas.JuegoCraps.ObtenerInstancia().EsProximoTiroDeSalida(idmesa) ? "si" : "no"),
				new XElement("punto", Modelo.Fachadas.JuegoCraps.ObtenerInstancia().ValorPuntoProximoTiro(idmesa) != null ?
					((int)Modelo.Fachadas.JuegoCraps.ObtenerInstancia().ValorPuntoProximoTiro(idmesa)).ToString() : ""),
			});
			parametros.Add(proximoTiro);

			// Ultimo tiro
			XElement ultimoTiro = new XElement("ultimoTiro", new object[] {
				new XElement("tirador", Modelo.Fachadas.JuegoCraps.ObtenerInstancia().TiradorUltimoTiro(idmesa)),
				new XElement("resultado", new object[] {
					new XElement("dado1", Modelo.Fachadas.JuegoCraps.ObtenerInstancia().Dado1UltimoTiro(idmesa).ToString()),
					new XElement("dado2", Modelo.Fachadas.JuegoCraps.ObtenerInstancia().Dado2UltimoTiro(idmesa).ToString())
				})
			});

			// Premios
			XElement premios = new XElement("premios");
			foreach (KeyValuePair<KeyValuePair<KeyValuePair<Nombre, Creditos>, Creditos>, Creditos> premio in Modelo.Fachadas.JuegoCraps.ObtenerInstancia().PremiosUltimoTiro(idmesa))
			{
				XElement nuevoPremio = new XElement("premio", new object[] {
					new XElement("apostador", premio.Key.Key.Key),
					new XElement("montoPremioJugada", premio.Key.Key.Value.ToString()),
					new XElement("montoPremioJugadaFeliz", premio.Key.Value.ToString()),
					new XElement("montoRetenidoJugadaTodosponen", premio.Value.ToString())
				});
				premios.Add(nuevoPremio);
			}
			ultimoTiro.Add(premios);
			parametros.Add(ultimoTiro);

			// Apuestas vigentes
			XElement apuestasVigentes = new XElement("apuestasVigentes");
			foreach (KeyValuePair<KeyValuePair<KeyValuePair<Nombre, String>, String>, Dictionary<Creditos, int>> apuestaVigente in Modelo.Fachadas.JuegoCraps.ObtenerInstancia().ApuestasVigentes(idmesa))
			{
				XElement opcionApuesta = new XElement("opcionApuesta");
				opcionApuesta.Add(new object[] {
					new XElement("tipoApuesta", apuestaVigente.Key.Key.Value),
					new XElement("puntajeApostado", apuestaVigente.Key.Value)
				});

				XElement valorApuesta = new XElement("valorApuesta");
				foreach (Creditos valor in apuestaVigente.Value.Keys)
				{
					valorApuesta.Add(new XElement("fichaValor", new object[] {
						new XElement("cantidad", apuestaVigente.Value[valor].ToString()),
						new XElement("valor", valor.ToString())
					}));
				}

				apuestasVigentes.Add(new XElement("apuesta", new object[] { 
					new XElement("apostador", apuestaVigente.Key.Key.Key),
					opcionApuesta,
					valorApuesta
				}));
			}
			parametros.Add(apuestasVigentes);

			// Genero la respuesta
			Respuesta respuesta = new Respuesta("estadoCraps", idterminal, parametros);

			// Envio el XML de salida
			DespachadorRespuestas.ObtenerInstancia().DespacharRespuesta(respuesta);
		}

	}
}
