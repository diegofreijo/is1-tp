using System;
using System.Linq;
using System.Xml.Linq;
using CasinoOnline.Servidor.Modelo;
using CasinoOnline.Servidor.Comunicacion;

namespace CasinoOnline.Servidor.MensajeroDeSalida.Mensajeros
{
	using IdMesa = Int32;
	using IdTerminalVirtual = Int32;
	using Nombre = String;
	using Creditos = Decimal;
	using System.Collections.Generic;

	class AccesoYManejoAdministrador
	{

		#region Singleton
		/// <summary>
		/// La instancia de la clase
		/// </summary>
		private static AccesoYManejoAdministrador instancia = null;

		/// <summary>
		/// Constructor privado para no permitir crear mas instancias que las necesarias
		/// </summary>
		private AccesoYManejoAdministrador()
		{
		}

		/// <summary>
		/// Devuelve la instancia de la clase
		/// </summary>
		public static AccesoYManejoAdministrador ObtenerInstancia()
		{
			if (instancia == null)
			{
				instancia = new AccesoYManejoAdministrador();
			}
			return instancia;
		}
		#endregion


		/// 
		/// <param name="term"></param>
		/// <param name="aceptado"></param>
		public void RespuestaReporteRankingDeJugadores(IdTerminalVirtual idterminal, Boolean aceptado)
		{
			// Averiguo los ganadores y perdedores
			List<Nombre> ganadores = Modelo.Fachadas.AdministradorDeCasino.ObtenerInstancia().ObtenerJugadoresMasGanadores();
			List<Nombre> perdedores = Modelo.Fachadas.AdministradorDeCasino.ObtenerInstancia().ObtenerJugadoresMasPerdedores();

			// Genero el XML de salida
			XElement parametros = new XElement("respuestaReporteRankingDeJugadores", new object[]{
				new XAttribute("vTerm", idterminal),
				new XAttribute("aceptado", aceptado ? "si" : "no")
			});

			if (aceptado)
			{
				parametros.Add(
					new XElement("jugadoresMasGanadores",
						ganadores.Select((n, i) => new XElement("jugador", new object[] {
							new XAttribute("ranking", i.ToString()),
							new XAttribute("nombre", n.ToString())
						}))),
					new XElement("jugadoresMasPerdedores",
						perdedores.Select((n, i) => new XElement("jugador", new object[] {
							new XAttribute("ranking", i.ToString()),
							new XAttribute("nombre", n.ToString())
						})))
				);
			}
			

			// Genero la respuesta
			Respuesta respuesta = new Respuesta("respuestaReporteRankingDeJugadores", idterminal, parametros);

			// Envio el XML de salida
			DespachadorRespuestas.ObtenerInstancia().DespacharRespuesta(respuesta);
		}

		/// 
		/// <param name="term"></param>
		/// <param name="aceptado"></param>
		public void RespuestaReporteEstadoActual(IdTerminalVirtual idterminal, Boolean aceptado)
		{
			// Averiguo el estado actual
			Dictionary<Nombre, Creditos> jugadores = Modelo.Fachadas.AdministradorDeCasino.ObtenerInstancia().ObtenerJugadoresConSaldo();
			Creditos saldoCasino = Modelo.Fachadas.AdministradorDeCasino.ObtenerInstancia().ObtenerSaldoCasino();
			
			// Genero el XML de salida
			XElement parametros = new XElement("respuestaReporteEstadoActual", new object[]{
				new XAttribute("vTerm", idterminal),
				new XAttribute("aceptado", aceptado ? "si" : "no")
			});

			if (aceptado)
			{
				parametros.Add(
					new XElement("jugadores", jugadores.Select(j => new XElement("jugador", new object[] {
						new XAttribute("nombre", j.Key),
						new XAttribute("saldo", j.Value)
					}))),
					new XElement("saldoCasino", new XAttribute("monto", saldoCasino.ToString()))
				);
			}

			// Genero la respuesta
			Respuesta respuesta = new Respuesta("respuestaReporteEstadoActual", idterminal, parametros);

			// Envio el XML de salida
			DespachadorRespuestas.ObtenerInstancia().DespacharRespuesta(respuesta);
		}

		/// 
		/// <param name="term"></param>
		/// <param name="aceptado"></param>
		public void RespuestaReporteDetalleMovimientosPorJugador(IdTerminalVirtual idterminal, Boolean aceptado)
		{
			// Averiguo las apuestas
			List<Modelo.Fachadas.AdministradorDeCasino.PremioDetalleMovimientoJugadores> apuestas =
				Modelo.Fachadas.AdministradorDeCasino.ObtenerInstancia().DetalleMovimientoJugadores();

			// Genero el XML de salida
			XElement parametros = new XElement("respuestaReporteMovimientos", new object[] {
				new XAttribute("vTerm", idterminal),
				new XAttribute("aceptado", aceptado ? "si" : "no")
			});

			if (aceptado)
			{
				parametros.Add(
					new XElement("apuestas", apuestas.Select(a => new XElement("apuesta", new object[] {
						new XElement("jugador", new XAttribute("nombre", a.jugador)),
						new XElement("tipoApuesta", new XAttribute("nombre", a.tipoApuesta)),
						new XElement("normal", new XAttribute("monto", a.normal)),
						new XElement("feliz", new XAttribute("monto", a.feliz)),
						new XElement("todosPonen", new XAttribute("monto", a.todosPonen)),
						new XElement("progresivo", new XAttribute("monto", a.progresivo))
					})))
				);
			}

			// Genero la respuesta
			Respuesta respuesta = new Respuesta("respuestaReporteMovimientos", idterminal, parametros);

			// Envio el XML de salida
			DespachadorRespuestas.ObtenerInstancia().DespacharRespuesta(respuesta);
		}

		/// 
		/// <param name="term"></param>
		/// <param name="descripcion"></param>
		/// <param name="aceptado"></param>
		public void RespuestaConfigurarModoDirigidoTragamonedas(IdTerminalVirtual idterminal, String descripcion, Boolean aceptado)
		{
			throw new NotImplementedException();
		}

		/// 
		/// <param name="term"></param>
		/// <param name="descripcion"></param>
		/// <param name="aceptado"></param>
		public void RespuestaConfigurarModoDirigidoCraps(IdTerminalVirtual idterminal, String descripcion, Boolean aceptado)
		{
			// Genero el XML de salida
			XElement parametros = new XElement("respuestaConfigurarModoDirigidoCraps", new object[]{
				new XAttribute("vTerm", idterminal),
				new XAttribute("aceptado", aceptado ? "si" : "no"),
				new XElement("descripcion", descripcion)
			});

			// Genero la respuesta
			Respuesta respuesta = new Respuesta("respuestaConfigurarModoDirigidoCraps", idterminal, parametros);

			// Envio el XML de salida
			DespachadorRespuestas.ObtenerInstancia().DespacharRespuesta(respuesta);
		}

		/// 
		/// <param name="idt"></param>
		/// <param name="detalles"></param>
		/// <param name="aceptado"></param>
		public void RespuestaConfigurarModoDirigidoJugadaFeliz(IdTerminalVirtual idterminal, String descripcion, Boolean aceptado)
		{
			// Genero el XML de salida
			XElement parametros = new XElement("respuestaConfigurarModoDirigidoJugadaFeliz", new object[]{
				new XAttribute("vTerm", idterminal),
				new XAttribute("aceptado", aceptado ? "si" : "no"),
				new XElement("descripcion", descripcion)
			});

			// Genero la respuesta
			Respuesta respuesta = new Respuesta("respuestaConfigurarModoDirigidoJugadaFeliz", idterminal, parametros);

			// Envio el XML de salida
			DespachadorRespuestas.ObtenerInstancia().DespacharRespuesta(respuesta);
		}
	}
}
