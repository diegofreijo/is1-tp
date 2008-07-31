using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CasinoOnline.Servidor.Modelo
{
	abstract class TipoJugada
	{
		public abstract List<Premio> Resolverse(Jugada jugada);
		public abstract String ObtenerNombreTipoJugada();
	}
}
