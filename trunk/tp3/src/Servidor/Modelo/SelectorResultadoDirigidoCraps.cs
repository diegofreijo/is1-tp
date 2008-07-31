using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CasinoOnline.Servidor.Modelo
{
	class SelectorResultadoDirigidoCraps : SelectorResultadoCraps
	{
		private Dado dado1;
		private Dado dado2;

		public SelectorResultadoDirigidoCraps(Dado dado1, Dado dado2)
		{
			this.dado1 = dado1;
			this.dado2 = dado2;
		}
		public override KeyValuePair<Dado, Dado> SeleccionarResultado()
		{
			throw new NotImplementedException();
		}
	}
}
