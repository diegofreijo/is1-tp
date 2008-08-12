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

		/// <summary>
		/// El servidor esta encendido?
		/// Al ser volatil, esta variable puede ser tocada por varios threads (y lo es)
		/// </summary>
		private volatile bool encendido = true;
		
		private const int espera_entre_pooleo = 100;
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
					MensajeroDeEntrada.DespachadorPedidos.ObtenerInstancia().DespacharPedido(nuevo_pedido);
				}
				else
				{
					// Si no habia archivo nuevo, espero
					Thread.Sleep(espera_entre_pooleo);
				}
			}
		}

		/// <summary>
		/// Deja de recibir pedidos
		/// </summary>
		public void DetenerRecepcion()
		{
			encendido = false;
		}

		#endregion
	}
}
