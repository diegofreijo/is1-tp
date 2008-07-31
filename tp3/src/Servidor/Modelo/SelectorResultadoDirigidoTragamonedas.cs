using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CasinoOnline.Servidor.Modelo
{
	class SelectorResultadoDirigidoTragamonedas : SelectorResultadoTragamonedas
	{
		private RodilloTragamonedas rodillo1;
		private RodilloTragamonedas rodillo2;
		private RodilloTragamonedas rodillo3;

		public SelectorResultadoDirigidoTragamonedas(RodilloTragamonedas rodillo1, RodilloTragamonedas rodillo2, RodilloTragamonedas rodillo3)
		{
			this.rodillo1 = rodillo1;
			this.rodillo2 = rodillo2;
			this.rodillo3 = rodillo3;
		}
		public override KeyValuePair<RodilloTragamonedas, KeyValuePair<RodilloTragamonedas, RodilloTragamonedas>> SeleccionarResultado()
		{
			throw new NotImplementedException();
		}
	}
}
