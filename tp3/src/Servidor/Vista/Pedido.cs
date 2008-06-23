using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace CasinoOnline.Servidor.Vista
{
    class Pedido
    {
		private Dictionary<string, object> parametros = new Dictionary<string, object>();
		//private XElement raiz;
		//private XElement seleccion_actual;

		public Dictionary<string, object> Parametros
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
			ret += "}\n";

			return ret;
		}

		/*public Pedido()
		{
			//raiz = new XElement();
			seleccion_actual = raiz;
		}

		public void ImportarXml(XElement xml)
		{
			raiz = xml;
		}

		public XElement ExportarXml()
		{
			return raiz;
		}

		/*public void EntrarNodo()
		{
		}

		public void SalirNodo()
		{
		}

		public void EscribirAtributo(string nombre, string valor)
		{
		}

		public void EscribirAtributo(string nombre, string valor)
		{
		}*/


    }
}
