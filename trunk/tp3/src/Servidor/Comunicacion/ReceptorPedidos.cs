using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Xml.Linq;
using CasinoOnline.Servidor.Utils;

namespace CasinoOnline.Servidor.Comunicacion
{
	/// <summary>
	/// Receptor generico de pedidos XML
	/// </summary>
    class ReceptorPedidos
	{
		#region Miembros
		private const int espera_entre_pooleo = 1000;
		private bool encendido = true;
		private IObtenedorPedidos obtenedor = null;
		#endregion


		#region Metodos Publicos

		public ReceptorPedidos(IObtenedorPedidos obtenedor)
		{
			this.obtenedor = obtenedor;
		}

		/// <summary>
        /// Comienza a recibir los pedidos de los clientes
        /// </summary>
		public void ComenzarRecepcion()
		{
			XElement nuevo_xml = null;
			while (encendido)
			{
				// Veo si hay un nuevo pedido
				if (obtenedor.ObtenerNuevoPedido(ref nuevo_xml))
				{
					// Hay un nuevo archivo, asi que genero el Pedido asociado
					Pedido nuevo_pedido = new Pedido(nuevo_xml.Name.ToString(), nuevo_xml);

					// Proceso el nuevo pedido
					Log.Mensaje("Llego un nuevo pedido de tipo " + nuevo_pedido.Tipo);
					MensajeroDeEntrada.DespachadorPedidos.ObtenerInstancia().DespacharPedido(nuevo_pedido);
				}
				else
				{
					// Si no habia archivo nuevo, espero
					Thread.Sleep(espera_entre_pooleo);
				}
			}
		}
		#endregion
	}
}
