using System;
using System.Xml.Linq;
using System.Collections.Generic;
using System.Linq;
using CasinoOnline.Servidor.Modelo;

namespace CasinoOnline.Servidor.Modelo
{
	using Creditos = Decimal;
	using Nombre = String;

	class ConfiguracionCasino
	{
		#region Singleton
		/// <summary>
		/// La instancia de la clase
		/// </summary>
		private static ConfiguracionCasino instancia = null;

		/// <summary>
		/// Constructor privado para no permitir crear mas instancias que las necesarias
		/// </summary>
		private ConfiguracionCasino()
		{
		}

		/// <summary>
		/// Devuelve la instancia de la clase
		/// </summary>
		public static ConfiguracionCasino ObtenerInstancia()
		{
			if (instancia == null)
			{
				instancia = new ConfiguracionCasino();
			}
			return instancia;
		}
		#endregion


		#region Miembros
		private ConfiguracionPozoFeliz configuracion_pozo_feliz;
		private ConfiguracionCraps configuracion_craps;
		private ConfiguracionTragamonedas configuracion_tragamonedas;
		private ConfiguracionPozoProgresivo configuracion_pozo_progresivo;
		private ConfiguracionGeneralDelCasino configuracion_general_del_casino;
		#endregion


		#region Propiedades

		public int CantApuestasJugadaMaximaGordoProgresivo
		{
			get { return configuracion_pozo_progresivo.CantApuestasJugadaMaximaGordoProgresivo; }
		}
		public Decimal PorcentajeDescuentoPorApuesta
		{
			get { return configuracion_pozo_progresivo.PorcentajeDescuentoPorApuesta; }
		}
		public Creditos MontoMinimoPozoProgresivo
		{
			get { return configuracion_pozo_progresivo.MontoMinimo; }
		}


		public Decimal PorcentajeDescuentoTodosponen
		{
			get { return configuracion_pozo_feliz.PorcentajeDescuentoTodosponen; }
		}
		public Decimal ProbabilidadOcurrenciaFeliz
		{
			get { return configuracion_pozo_feliz.ProbabilidadOcurrenciaFeliz; }
		}
		public Decimal ProbabilidadOcurrenciaTodosponen
		{
			get { return configuracion_pozo_feliz.ProbabilidadOcurrenciaTodosponen; }
		}
		public Creditos MontoMinimoPozoFeliz
		{
			get { return configuracion_pozo_feliz.MontoMinimo; }
		}


		public List<Creditos> FichasValidas
		{
			get { return configuracion_general_del_casino.FichasValidas; }
		}
		public Creditos SaldoCasino
		{
			get { return configuracion_general_del_casino.SaldoCasino; }
			set { configuracion_general_del_casino.SaldoCasino = value; }
		}
		public String PasswordAdmin
		{
			get { return configuracion_general_del_casino.PasswordAdmin; }
		}


		private Dictionary<int, Decimal> ProbabilidadOcurrenciaNumeros
		{
			get { return configuracion_craps.ProbabilidadOcurrenciaNumeros; }
		}


		private Dictionary<FiguraRodillo, Decimal> ProbabilidadOcurrenciaFiguras
		{
			get { return configuracion_tragamonedas.ProbabilidadOcurrenciaFiguras; }
		}

		#endregion


		#region Metodos Publicos

		/// 
		/// <param name="configuracion"></param>
		public void Inicializar(XElement configuracion)
		{
			// Configuracion del casino
			string pass_admin = configuracion.Element("configuracionDelCasino").Element("passwordAdmin").Attribute("valor").Value;
			Creditos saldo_casino = Creditos.Parse(configuracion.Element("configuracionDelCasino").Element("saldoCasino").Attribute("monto").Value);
			List<Creditos> fichas_validas = configuracion.Element("configuracionDelCasino").Element("fichasValidas").Elements("fichaValida").
				Attributes("valor").Select<XAttribute, Creditos>(n => Creditos.Parse(n.Value)).ToList();
			configuracion_general_del_casino = new ConfiguracionGeneralDelCasino(fichas_validas, saldo_casino, pass_admin);

			// Configuracion del juego de tragamonedas
			Dictionary<FiguraRodillo, decimal> probabilidadOcurrenciaFiguras = configuracion.Element("configuracionTragamonedas").
				Element("probabilidadOcurrenciaFiguras").Elements("figura").ToDictionary(
				f => TextoAFiguraRodillo(f.Attribute("tipo").Value), 
				f => decimal.Parse(f.Attribute("ocurrencia").Value));
			configuracion_tragamonedas = new ConfiguracionTragamonedas(probabilidadOcurrenciaFiguras);

			// Configuracion del juego de craps
			Dictionary<int, decimal> probabilidadOcurrenciaNumeros = configuracion.Element("configuracionCraps").
				Element("probabilidadOcurrenciaNumeros").Elements("numero").ToDictionary(
				f => int.Parse(f.Attribute("valor").Value),
				f => decimal.Parse(f.Attribute("ocurrencia").Value));
			configuracion_craps = new ConfiguracionCraps(probabilidadOcurrenciaNumeros);

			// Configuracion del pozo feliz
			decimal porcentajeDescuentoTodosPonen = decimal.Parse(configuracion.Element("configuracionPozoFeliz").Element("porcentajeDescuentoTodosPonen").Attribute("valor").Value);
			decimal probabilidadOcurrenciaFeliz = decimal.Parse(configuracion.Element("configuracionPozoFeliz").Element("probabilidadOcurrenciaFeliz").Attribute("valor").Value);
			decimal probabilidadOcurrenciaTodosPonen = decimal.Parse(configuracion.Element("configuracionPozoFeliz").Element("probabilidadOcurrenciaTodosPonen").Attribute("valor").Value);
			Creditos montoMinimoPF = Creditos.Parse(configuracion.Element("configuracionPozoFeliz").Element("montoMinimo").Attribute("valor").Value);
			configuracion_pozo_feliz = new ConfiguracionPozoFeliz(porcentajeDescuentoTodosPonen, probabilidadOcurrenciaFeliz,
				probabilidadOcurrenciaTodosPonen, montoMinimoPF);

			// Configuracion del pozo progresivo
			int cantApuestasJugagaMaximaGordoProgresivo = int.Parse(configuracion.Element("configuracionPozoProgresivo").Element("cantApuestasJugagaMaximaGordoProgresivo").Attribute("valor").Value);
			decimal porcentajeDescuentoPorApuesta = decimal.Parse(configuracion.Element("configuracionPozoProgresivo").Element("porcentajeDescuentoPorApuesta").Attribute("valor").Value);
			Creditos montoMinimoPP = Creditos.Parse(configuracion.Element("configuracionPozoProgresivo").Element("montoMinimo").Attribute("valor").Value);
			configuracion_pozo_progresivo = new ConfiguracionPozoProgresivo(cantApuestasJugagaMaximaGordoProgresivo, 
				porcentajeDescuentoPorApuesta, montoMinimoPP);
		}

		#endregion


		#region Metodos Privados


		private FiguraRodillo TextoAFiguraRodillo(string texto)
		{
			switch (texto)
			{
				case "Blanco":		return FiguraRodillo.Blanco;
				case "Cereza":		return FiguraRodillo.Cereza;
				case "BarSimple":	return FiguraRodillo.BarSimple;
				case "BarDoble":	return FiguraRodillo.BarDoble;
				case "BarTriple":	return FiguraRodillo.BarTriple;
				case "Dinosaurio":	return FiguraRodillo.Dinosaurio;
				default:
					throw new ArgumentException("El texto no fue reconocido como una figura de rodillo");
			}
		}

		#endregion

	}
}
