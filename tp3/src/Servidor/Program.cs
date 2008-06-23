using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CasinoOnline.Servidor.Vista;

namespace CasinoOnline.Servidor
{
    class Program
    {
        static void Main(string[] args)
        {
            // Comienzo la recepcion de pedidos
            ReceptorPedidos receptor = new ReceptorPedidosXml();
            receptor.ComenzarRecepcion();
        }
    }
}
