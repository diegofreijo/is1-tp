using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CasinoOnline.Servidor.Modelo
{
	abstract class SelectorResultadoCraps
	{
		public abstract KeyValuePair<Dado, Dado> SeleccionarResultado();
	}
}
