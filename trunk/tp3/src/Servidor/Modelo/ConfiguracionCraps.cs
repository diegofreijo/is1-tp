using System;
using System.Collections.Generic;

namespace CasinoOnline.Servidor.Modelo
{
	public class ConfiguracionCraps
	{
		private Dictionary<NumeroDadosCraps, Decimal> probabilidad_ocurrencia_numeros;


		public Dictionary<NumeroDadosCraps, Decimal> ProbabilidadOcurrenciaNumeros
		{
			get { return probabilidad_ocurrencia_numeros; }
		}


		/// 
		/// <param name="p_ocurr_num"></param>
		public ConfiguracionCraps(Dictionary<NumeroDadosCraps, Decimal> p_ocurr_num)
		{
			this.probabilidad_ocurrencia_numeros = p_ocurr_num;
		}
	}
}
