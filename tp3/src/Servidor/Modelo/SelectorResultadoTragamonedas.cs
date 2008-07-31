using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CasinoOnline.Servidor.Modelo
{
	abstract class SelectorResultadoTragamonedas
	{
		public abstract KeyValuePair<RodilloTragamonedas, KeyValuePair<RodilloTragamonedas, RodilloTragamonedas>> SeleccionarResultado();
	}
}
