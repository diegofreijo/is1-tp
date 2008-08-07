using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CasinoOnline.Servidor.Modelo
{
	class SelectorNoFeliz : SelectorTipoJugada
	{
		public override TipoJugada SeleccionarTipoJugada()
		{
			Random rand = new Random(DateTime.Now.Millisecond);
			if ((decimal)rand.NextDouble() < ConfiguracionCasino.ObtenerInstancia().ProbabilidadOcurrenciaTodosponen)
			{
				return new TodosPonen();
			}
			else
			{
				return new Normal();
			}
		}
	}
}
