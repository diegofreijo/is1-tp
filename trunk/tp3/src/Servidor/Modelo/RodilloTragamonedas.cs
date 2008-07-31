using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CasinoOnline.Servidor.Modelo
{
	class RodilloTragamonedas
	{
		private FiguraRodillo figura;

		public FiguraRodillo Figura
		{
			get { return figura; }
		}

		public RodilloTragamonedas(FiguraRodillo figura)
		{
			this.figura = figura;
		}
	}
}
