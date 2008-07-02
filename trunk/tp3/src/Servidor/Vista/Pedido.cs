﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace CasinoOnline.Servidor.Vista
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