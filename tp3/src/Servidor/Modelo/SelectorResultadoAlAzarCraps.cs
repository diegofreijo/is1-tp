using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CasinoOnline.Servidor.Modelo
{
	class SelectorResultadoAlAzarCraps : SelectorResultadoCraps
	{
		public override KeyValuePair<Dado, Dado> SeleccionarResultado()
		{
			Random rand = new Random(DateTime.Now.Millisecond);
			return new KeyValuePair<Dado, Dado>(new Dado(rand.Next(1, 6)), new Dado(rand.Next(1, 6)));
		}
	}
}
