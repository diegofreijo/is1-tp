using System;
using System.Collections.Generic;

namespace CasinoOnline.Servidor.Modelo
{
	class ConfiguracionCraps
	{
		private Dictionary<int, Decimal> probabilidad_ocurrencia_numeros;


		public Dictionary<int, Decimal> ProbabilidadOcurrenciaNumeros
		{
			get { return probabilidad_ocurrencia_numeros; }
		}


		/// 
		/// <param name="p_ocurr_num"></param>
		public ConfiguracionCraps(Dictionary<int, Decimal> p_ocurr_num)
		{
			this.probabilidad_ocurrencia_numeros = p_ocurr_num;
		}
	}
}
