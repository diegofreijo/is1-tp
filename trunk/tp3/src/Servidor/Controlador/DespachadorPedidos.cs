using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CasinoOnline.Servidor;

namespace CasinoOnline.Servidor.Controlador
{
	class DespachadorPedidos
	{
		#region Singleton
		/// <summary>
		/// La instancia de la clase
		/// </summary>
		private static DespachadorPedidos instancia = null;

		/// <summary>
		/// Constructor privado para no permitir crear mas instancias que las necesarias
		/// </summary>
		private DespachadorPedidos()
		{
		}

		/// <summary>
		/// Devuelve la instancia de la clase
		/// </summary>
		public static DespachadorPedidos ObtenerInstancia()
		{
			if (instancia == null)
			{
				instancia = new DespachadorPedidos();
			}
			return instancia;
		}
		#endregion


		#region Miembros Privados
		private Dictionary<Type, Manejador> asociaciones = new Dictionary<Type, Manejador>();
		#endregion

		#region Metodos Publicos
		/// <summary>
		/// Comprende el pedido y genera las modificaciones y respuestas necesarias
		/// </summary>
		public void DespacharPedido(Vista.Pedido pedido)
		{
			// Trato de obtener el manejador asociado al pedido que me vino
			Manejador manejador_asociado = null;
			Type tipo_pedido = pedido.GetType();
			if (asociaciones.TryGetValue(tipo_pedido, out manejador_asociado))
			{
				// Tengo al manejador, lo uso
				manejador_asociado.ManejarPedido(pedido);
			}
			else
			{
				// No tenia al manejador asociado, flor de error
				throw new Exception("Me llego un pedido que no se adonde despachar");
			}

		}

		/// <summary>
		/// Asocia un manejador a un tipo de pedidos
		/// </summary>
		public void AsociarManejador(Type pedido, Manejador manejador)
		{
			// Verifico si no estaba ya asociado el pedido
			Manejador ya_asociado = null;
			if (asociaciones.TryGetValue(pedido, out ya_asociado))
			{
				throw new Exception("Se quiso asociar un pedido ya asociado.");
			}

			// Agrego la asociacion a la lista
			this.asociaciones.Add(pedido.GetType(), manejador);
		}

		#endregion
	}
}
