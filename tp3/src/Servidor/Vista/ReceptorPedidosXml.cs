using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Xml.Linq;

namespace CasinoOnline.Servidor.Vista
{
    class ReceptorPedidosXml : ReceptorPedidos
    {
        #region Miembros
		private const string ruta_buffer_entrada = "..\\buffer_entrada\\";
		private const int intervalo_pooleo = 1000;
		private bool encendido = true;
        #endregion


        #region Metodos Publicos
        /// <summary>
        /// Comienza la recepcion de pedidos en forma de archivos XML
        /// </summary>
        public override void ComenzarRecepcion()
        {
			while(encendido)
			{
				// Pooleo por nuevos archivos
				while(!HayNuevoArchivo())
				{
					Thread.Sleep(intervalo_pooleo);
				}

				// Hay un nuevo archivo, asi que lo levanto y genero el Pedido asociado
				Pedido nuevo_pedido = Desempaquetar(ObtenerNuevoArchivo());

				// Proceso el nuevo pedido
				Console.WriteLine("Nuevo pedido!");
				Console.WriteLine("	" + nuevo_pedido.ToString());
				Console.WriteLine("------------------");
			}
        }
		#endregion


		#region Metodos Privados
        /// <summary>
        /// Transforma un archivo XML en un Pedido
        /// </summary>
        private Pedido Desempaquetar(XElement xml)
        {
			// Genero el tipo de pedido correspondiente
			Pedido ret = new Pedido();

			// Levanto los parametros
			ret.Parametros = DesempaquetarElemento(xml);

			return ret;
        }

		/// <summary>
		/// Desempaqueta un elemento XML generico
		/// </summary>
		private Dictionary<string, object> DesempaquetarElemento(XElement elemento)
		{
			// Agrego los atributos
			Dictionary<string, object> ret = new Dictionary<string, object>();
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
        /// Obtiene el siguiente XML a procesar
        /// </summary>
		private XElement ObtenerNuevoArchivo()
        {
			// Eligo que archivo levantar
			String ruta_archivo = Directory.GetFiles(ruta_buffer_entrada)[0];
        	
			// Lo levanto
        	XElement ret = null;
			try
			{
				ret = XElement.Load(ruta_archivo);
			}
			catch(Exception ex)
			{
				Console.WriteLine("ERROR: Levantando el nuevo XML.\n	Ruta: " + ruta_archivo + ".\n	Excepcion: " + ex.ToString());
			}

			// Borro el archivo del buffer de entrada
			File.Move(ruta_archivo, "_" + ruta_archivo);

        	return ret;
        }

        /// <summary>
        /// Informa si existe un nuevo archivo para procesar
        /// </summary>
        private bool HayNuevoArchivo()
        {
        	return Directory.GetFiles(ruta_buffer_entrada).Length > 0;
        }

        #endregion
    }
}
