using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CasinoOnline.Servidor.Vista;
using CasinoOnline.Servidor.Controlador;
using CasinoOnline.Servidor.Logueo;

namespace CasinoOnline.Servidor
{
    class Program
    {
        static void Main(string[] args)
        {
			EncenderServidor();
        }

		private static void EncenderServidor()
		{
			Log.Mensaje("Servidor de CasinoOnline iniciado" + 
				Environment.NewLine + "=============================================");

			// Comienzo la recepcion de pedidos
			Log.Mensaje("Comenzando recepcion de pedidos" + Environment.NewLine);
			ReceptorPedidos receptor = new ReceptorPedidosArchivo();
			receptor.ComenzarRecepcion();
		}
    }
}
