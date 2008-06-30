using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace CasinoOnline.Servidor.Vista
{
	class Respuesta
	{
		private XElement parametros = null;
		private String tipo = "";


		/// <summary>
		/// El tipo de respuesta
		/// </summary>
		public String Tipo
		{
			get { return tipo; }
			set { tipo = value; }
		}

		/// <summary>
		/// Informacion detallada de la respuesta
		/// </summary>
		internal XElement Parametros
		{
			get { return parametros; }
			set { parametros = value; }
		}

		/// <summary>
		/// Muestra la respuesta en forma bonita
		/// </summary>
		public override string ToString()
		{
			string ret;

			// Muestro el tipo
			ret = this.tipo + " - " + parametros.ToString();

			return ret;
		}

	}
}
