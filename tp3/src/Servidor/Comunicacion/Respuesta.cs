using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace CasinoOnline.Servidor.MensajeroDeSalida
{
	class Respuesta
	{
		private XElement parametros = null;
		private String tipo = "";
		private int id_terminal = -1;


		/// <summary>
		/// El id de la terminal virtual a la cual esta dirigida la respuesta
		/// </summary>
		public int IdTerminal
		{
			get { return id_terminal; }
			set { id_terminal = value; }
		}

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
		/// Constructor completo
		/// </summary>
		public Respuesta(String tipo, int id_terminal, XElement parametros)
		{
			this.tipo = tipo;
			this.id_terminal = id_terminal;
			this.parametros = parametros;
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
