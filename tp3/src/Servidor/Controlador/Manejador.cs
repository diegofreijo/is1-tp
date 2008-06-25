using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CasinoOnline.Servidor.Controlador
{
	abstract class Manejador
	{
		#region Singleton
		/// <summary>
		/// La instancia de la clase
		/// </summary>
		private static Manejador instancia = null;

		/// <summary>
		/// Constructor privado para no permitir crear mas instancias que las necesarias
		/// </summary>
		private Manejador()
		{
			// Asocio el manejador a su tipo de pedido
			Asociarse();
		}

		/// <summary>
		/// Devuelve la instancia de la clase
		/// </summary>
		public static Manejador ObtenerInstancia()
		{
			if (instancia == null)
			{
				instancia = new this.GetType();
			}
			return instancia;
		}
		#endregion
	
		/// <summary>
		/// Realiza las acciones necesarias para el pedido pasado
		/// </summary>
		public abstract void ManejarPedido(Vista.Pedido pedido);

		/// <summary>
		/// Asocia al manejador con su tipo de pedido
		/// </summary>
		private void Asociarse()
		{
			DespachadorPedidos.ObtenerInstancia().AsociarManejador(this.PedidoAsociado, this);
		}

		/// <summary>
		/// Devuelve el tipo de pedido que tiene asociado este manejador
		/// </summary>
		protected abstract Vista.Pedido PedidoAsociado
		{
			get;
		}
	}
}
