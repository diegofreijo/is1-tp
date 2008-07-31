using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CasinoOnline.Servidor.Modelo
{
	class ResultadoCraps : Resultado
	{
		private EstadoRondaCraps estado_ronda;
		private Dado dado1;
		private Dado dado2;

		public EstadoRondaCraps EstadoRonda
		{
			get { return estado_ronda; }
		}

		public ResultadoCraps(Dado dado1, Dado dado2, EstadoRondaCraps estado_ronda)
		{
			this.dado1 = dado1;
			this.dado2 = dado2;
			this.estado_ronda = estado_ronda;
		}
	}
}
