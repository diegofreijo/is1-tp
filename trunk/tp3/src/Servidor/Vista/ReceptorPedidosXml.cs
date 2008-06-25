using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Xml.Linq;
using CasinoOnline.Servidor.Logueo;

namespace CasinoOnline.Servidor.Vista
{
    class ReceptorPedidosXml : ReceptorPedidos
    {
        #region Miembros
		private const string ruta_buffer_entrada = "..\\buffer_entrada\\";
        #endregion


		#region Metodos Protegidos
        /// <summary>
        /// Transforma un archivo XML en un Pedido
        /// </summary>
		protected override Pedido Desempaquetar(object xml)
        {
			// Se que lo que me entra es un XML
			xml = (XElement)xml;
		
			// Genero el tipo de pedido correspondiente
			Pedido ret = new Pedido();

			// Levanto los parametros
			ret.Parametros = DesempaquetarElemento((XElement)xml);

			return ret;
        }

        /// <summary>
        /// Obtiene el siguiente XML a procesar
        /// </summary>
		protected override bool ObtenerNuevoPedido(ref object nuevo_archivo)
        {
			// Se que lo que me entra es un XML
			nuevo_archivo = (XElement)nuevo_archivo;

			// Reviso en la lista de archivos en el buffer si alguno es valido como pedido
			string ruta_archivo = "";
			string nombre_archivo = "";
			string[] ruta_archivos_buffer = Directory.GetFiles(ruta_buffer_entrada);
			foreach (string ruta_archivo_actual in ruta_archivos_buffer)
			{
				if (EsArchivoUnPedido(ruta_archivo_actual))
				{
					ruta_archivo = ruta_archivo_actual;
					nombre_archivo = Path.GetFileName(ruta_archivo);
				}
			}

			// Si no levante ninguna ruta, es porque no habia mensaje nuevo
			if(String.IsNullOrEmpty(ruta_archivo))
				return false;

			// Lo levanto
			try
			{
				nuevo_archivo = XElement.Load(ruta_archivo);
			}
			catch(Exception ex)
			{
				Log.Error("Exepcion levantando el nuevo XML.\n	Ruta: " + ruta_archivo + ".\n	Excepcion: " + ex.ToString());
			}

			// Borro el archivo del buffer de entrada
			File.Move(ruta_archivo, ruta_buffer_entrada + "_" + nombre_archivo);

        	return true;
        }
		#endregion


		#region Metdos Privados
		/// <summary>
		/// Desempaqueta un elemento XML generico
		/// </summary>
		private ParametrosPedido DesempaquetarElemento(XElement elemento)
		{
			// Agrego los atributos
			ParametrosPedido ret = new ParametrosPedido();
			foreach (XAttribute at in elemento.Attributes())
			{
				ret.Add(at.Name.ToString(), at.Value);
			}

			// Repito lo mismo para los elementos que tenga este nodo.
			foreach (XElement elem in elemento.Elements())
			{
				// Si es un elemento con solamente algun valor, lo agrego como si fuese un atributo. 
				// Si no, agrego una lista de objetos.
				if (!String.IsNullOrEmpty(elem.Value))
				{
					ret.Add(elem.Name.ToString(), elem.Value);
				}
				else
				{
					ret.Add(elem.Name.ToString(), DesempaquetarElemento(elem));
				}
			}

			return ret;
		}

		/// <summary>
		/// Informa si la ruta del archivo es un archivo de pedido
		/// </summary>
		private bool EsArchivoUnPedido(string ruta_archivo)
		{
			return
				!Path.GetFileName(ruta_archivo).StartsWith("_") &&
				Path.GetExtension(ruta_archivo) == ".xml";
		}
		#endregion
	}
}
