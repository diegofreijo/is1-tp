using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CasinoOnline.Servidor.Modelo
{
	class SelectorNormal : SelectorTipoJugada
	{
		public override TipoJugada SeleccionarTipoJugada()
		{
			return new Normal();
		}
	}
}
