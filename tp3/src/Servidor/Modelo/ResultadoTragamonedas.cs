using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CasinoOnline.Servidor.Modelo
{
	class ResultadoTragamonedas : Resultado
	{
		#region Miembros
		private RodilloTragamonedas rodillo1;
		private RodilloTragamonedas rodillo2;
		private RodilloTragamonedas rodillo3;
		#endregion


		#region Propiedades

		public RodilloTragamonedas Rodillo1
		{
			get { return rodillo1; }
		}
		public RodilloTragamonedas Rodillo2
		{
			get { return rodillo2; }
		}
		public RodilloTragamonedas Rodillo3
		{
			get { return rodillo3; }
		}

		#endregion


		#region Metodos Publicos

		public ResultadoTragamonedas(RodilloTragamonedas rodillo1,
			RodilloTragamonedas rodillo2, RodilloTragamonedas rodillo3)
		{
			this.rodillo1 = rodillo1;
			this.rodillo2 = rodillo2;
			this.rodillo3 = rodillo3;
		}

		#endregion
	}
}
