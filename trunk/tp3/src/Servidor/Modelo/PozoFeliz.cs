using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CasinoOnline.Servidor.Modelo
{
	using Creditos = Decimal;

	class PozoFeliz : Pozo
	{
		public PozoFeliz(Creditos monto_minimo) : base(monto_minimo)
		{
		}
		public PozoFeliz Clonar()
		{
			PozoFeliz ret = new PozoFeliz(this.monto_minimo);
			ret.monto = this.monto;

			return ret;
		}
	}
}
