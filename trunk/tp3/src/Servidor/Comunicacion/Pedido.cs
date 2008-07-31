using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace CasinoOnline.Servidor.MensajeroDeSalida
{
    class Pedido
    {
		private XElement parametros = null;
		private String tipo = "";


		/// <summary>
		/// Tipo de pedido
		/// </summary>
		public String Tipo
		{
			get { return tipo; }
			set { tipo = value; }
		}

		/// <summary>
		/// Informacion detallada del pedido
		/// </summary>
		public XElement Parametros
		{
			get { return parametros; }
			set { parametros = value; }
		}


		/// <summary>
		/// Constructor completo
		/// </summary>
		public Pedido(String tipo, XElement parametros)
		{
			this.tipo = tipo;
			this.parametros = parametros;
		}


		/// <summary>
		/// Muestra al pedido en forma bonita
		/// </summary>
		public override string ToString()
		{
			string ret;

			// Muestro el tipo
			ret = this.Tipo + " - " + parametros.ToString();

			return ret;
		}
    }
}
