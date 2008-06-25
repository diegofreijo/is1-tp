using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CasinoOnline.Servidor;
using CasinoOnline.Servidor.Logueo;

namespace CasinoOnline.Servidor.Controlador.Manejadores
{
	class EntrarCasino : Manejador
	{
		public override void ManejarPedido(CasinoOnline.Servidor.Vista.Pedido pedido)
		{
			Log.Mensaje("Estoy manejando, estoy manejando!");
		}

		protected override Vista.Pedido PedidoAsociado
		{
			get { return new Vista.Pedidos.EntrarCasino(); }
		}
	}
}
