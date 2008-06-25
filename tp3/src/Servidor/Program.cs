using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CasinoOnline.Servidor.Vista;
using CasinoOnline.Servidor.Controlador;

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
			// Pido que se inicialicen todos los manejadores
			InicializarManejadores();

			// Comienzo la recepcion de pedidos
			ReceptorPedidos receptor = new ReceptorPedidosXml();
			receptor.ComenzarRecepcion();
		}

		private static void InicializarManejadores()
		{
			CasinoOnline.Servidor.Controlador.Manejadores.EntrarCasino.ObtenerInstancia();
		}
    }
}
