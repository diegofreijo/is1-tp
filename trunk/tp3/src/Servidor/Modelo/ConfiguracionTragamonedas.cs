using System;
using System.Collections.Generic;

namespace CasinoOnline.Servidor.Modelo
{
	public class ConfiguracionTragamonedas
	{
		private Dictionary<FiguraRodillo, Decimal> probabilidad_ocurrencia_figuras;


		public Dictionary<FiguraRodillo, Decimal> ProbabilidadOcurrenciaFiguras
		{
			get { return probabilidad_ocurrencia_figuras; }
		}


		public ConfiguracionTragamonedas(Dictionary<FiguraRodillo, Decimal> prob_ocurr_fig)
		{
			this.probabilidad_ocurrencia_figuras = prob_ocurr_fig;
		}
	}
}
