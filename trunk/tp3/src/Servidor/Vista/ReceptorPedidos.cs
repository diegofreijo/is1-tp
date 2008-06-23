using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CasinoOnline.Servidor.Vista
{
    abstract class ReceptorPedidos
    {
        /// <summary>
        /// Comienza a recibir los pedidos de los clientes
        /// </summary>
        public abstract void ComenzarRecepcion();
    }
}
