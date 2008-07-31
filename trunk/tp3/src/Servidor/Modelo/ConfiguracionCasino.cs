using System;
using Servidor.Modelo;
using System.Xml.Linq;
using System.Collections.Generic;

namespace CasinoOnline.Servidor.Modelo
{
	public class ConfiguracionCasino
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
		public Creditos MontoMinimo
		{
			get { return configuracion_pozo_progresivo.MontoMinimo; }
		}


		public Decimal PorcentajeDescuentoTodosponen
		{
			get { return configuracion_pozo_feliz.PorcentajeDescuentoTodosponen.; }
		}
		public Decimal ProbabilidadOcurrenciaFeliz
		{
			get { return configuracion_pozo_feliz.ProbabilidadOcurrenciaFeliz; }
		}
		public Decimal ProbabilidadOcurrenciaTodosponen
		{
			get { return configuracion_pozo_feliz.ProbabilidadOcurrenciaTodosponen; }
		}
		public Creditos MontoMinimo
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
		}
		public String PasswordAdmin
		{
			get { return configuracion_general_del_casino.PasswordAdmin; }
		}


		private Dictionary<NumeroDadosCraps, Decimal> ProbabilidadOcurrenciaNumeros
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
			throw new NotImplementedException();
		}

		#endregion


	}
}
