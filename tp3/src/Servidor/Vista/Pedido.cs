using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace CasinoOnline.Servidor.Vista
{
    class Pedido
    {
		private ParametrosPedido parametros = new ParametrosPedido();


		public ParametrosPedido Parametros
		{
			get { return parametros; }
			set { parametros = value; }
		}

		public override string ToString()
		{
			string ret = "";

			// Muestro el tipo
			ret += "TipoNada - ";

			// Muestro los parametros
			ret += "{ ";
			foreach (string parametro in parametros.Keys)
			{
				ret += "(" + parametro + "," + parametros[parametro] + ") ";
			}
			ret += "}";

			return ret;
		}
    }
}
