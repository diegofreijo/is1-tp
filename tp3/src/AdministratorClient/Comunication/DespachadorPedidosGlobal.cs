using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CasinoOnline.AdminClient.Comunication
{
    public class DespachadorPedidosGlobal
    {
        #region Singleton
		/// <summary>
		/// La instancia de la clase
		/// </summary>
		private static DespachadorPedidosGlobal instancia = null;

		/// <summary>
		/// Constructor privado para no permitir crear mas instancias que las necesarias
		/// </summary>
        private DespachadorPedidosGlobal()
		{
		}

		/// <summary>
		/// Devuelve la instancia de la clase
		/// </summary>
        public static DespachadorPedidosGlobal ObtenerInstancia()
		{
			if (instancia == null)
			{
                instancia = new DespachadorPedidosGlobal();
			}
			return instancia;
		}
		#endregion

        private IDespachadorPedidos m_despachador;

        public IDespachadorPedidos Despachador
		{
            set { m_despachador = value; }
		}

        public void DespacharPedido(Pedido pedido)
        {
            m_despachador.DespacharPedido(pedido);
        }
    }
}
