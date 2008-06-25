using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using CasinoOnline.Servidor.Logueo;

namespace CasinoOnline.Servidor.Vista
{
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
			object nuevo_pedido_crudo = null;
			while (encendido)
			{
				// Veo si hay un nuevo archivo
				if (ObtenerNuevoPedido(ref nuevo_pedido_crudo))
				{
					// Hay un nuevo archivo, asi que genero el Pedido asociado
					Pedido nuevo_pedido = Desempaquetar(nuevo_pedido_crudo);

					// Proceso el nuevo pedido
					Log.Mensaje("NUEVO PEDIDO: " + Environment.NewLine + "		" + nuevo_pedido.ToString());
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
		/// Desempaqueta un pedido en crudo
		/// </summary>
		protected abstract Pedido Desempaquetar(object pedido_crudo);

		/// <summary>
        /// Obtiene el siguiente pedido a procesar
        /// </summary>
		protected abstract bool ObtenerNuevoPedido(ref object nuevo_pedido_crudo);

		#endregion
	}
}
