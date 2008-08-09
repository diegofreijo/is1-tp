using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace CasinoOnline.PlayerClient.Comunication
{
    public interface IDespachadorPedidos
    {
        void DespacharPedido(Pedido pedido);
    }
}
