using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CasinoOnline.AdminClient.Utils;

namespace CasinoOnline.AdminClient.Comunication
{
    public class DespachadorPedidosArchivo : IDespachadorPedidos
    {
        private const String m_numero_grupo = "05";
        private const String m_bufferSalida = "..\\buffer_entrada\\";

        public void DespacharPedido(Pedido pedido)
        {
            // Escribo un nuevo archivo XML al buffer de salida
            try
            {
                // Genero el nombre del archivo
                string ruta_archivo = m_bufferSalida + pedido.Tipo + m_numero_grupo + pedido.TermId.ToString("D4") + ".xml";

                // Guardo el Xml
                pedido.Parametros.Save(ruta_archivo);
            }
            catch (Exception ex)
            {
                Log.Error("Ocurrio un error al escribir el nuevo archivo a disco: " + ex.ToString());
            }
        }
    }
}
