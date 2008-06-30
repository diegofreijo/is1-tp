using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Xml.Linq;
using CasinoOnline.Servidor.Logueo;

namespace CasinoOnline.Servidor.Vista
{
	/// <summary>
	/// Receptor generico de pedidos XML
	/// </summary>
    abstract class ReceptorPedidos
	{
		#region Miembros
		protected const int espera_entre_pooleo = 1000;
		protected bool encendido = true;
		#endregion


		#region Metodos Publicos
		/// <summary>
        /// Comienza a recibir los pedidos de los clientes
        /// </summary>
		public void ComenzarRecepcion()
		{
			XElement nuevo_xml = null;
			while (encendido)
			{
				// Veo si hay un nuevo pedido
				if (ObtenerNuevoPedido(ref nuevo_xml))
				{
					// Hay un nuevo archivo, asi que genero el Pedido asociado
					Pedido nuevo_pedido = new Pedido();
					nuevo_pedido.Parametros = nuevo_xml;
					nuevo_pedido.Tipo = nuevo_xml.Name.ToString();

					// Proceso el nuevo pedido
					Log.Mensaje("Llego un nuevo pedido de tipo " + nuevo_pedido.Tipo);
					Controlador.DespachadorPedidos.ObtenerInstancia().DespacharPedido(nuevo_pedido);
				}
				else
				{
					// Si no habia archivo nuevo, espero
					Thread.Sleep(espera_entre_pooleo);
				}
			}
		}
		#endregion
		

		#region Metodos Protegidos
		/// <summary>
        /// Obtiene el siguiente pedido a procesar si es que habia.
        /// </summary>
		protected abstract bool ObtenerNuevoPedido(ref XElement nuevo_xml);
		#endregion
	}
}
