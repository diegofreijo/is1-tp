using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace CasinoOnline.Servidor.Comunicacion
{
	using IdTerminalVirtual = Int32;

	class Respuesta
	{
		private XElement parametros = null;
		private String tipo = "";
		private IdTerminalVirtual id_terminal = -1;


		/// <summary>
		/// El id de la terminal virtual a la cual esta dirigida la respuesta
		/// </summary>
		public int IdTerminal
		{
			get { return id_terminal; }
		}

		/// <summary>
		/// El tipo de respuesta
		/// </summary>
		public String Tipo
		{
			get { return tipo; }
		}

		/// <summary>
		/// Informacion detallada de la respuesta
		/// </summary>
		internal XElement Parametros
		{
			get { return parametros; }
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
