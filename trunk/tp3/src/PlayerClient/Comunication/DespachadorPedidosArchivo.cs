using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using CasinoOnline.PlayerClient.Utils;

namespace CasinoOnline.PlayerClient.Comunication
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

                // Obtengo un writer de acceso exclusivo
                bool done = false;
                XmlTextWriter writer = null;
                while (!done)
                {
                    try
                    {
                        writer = new XmlTextWriter(File.Open(ruta_archivo, FileMode.Create, FileAccess.Write, FileShare.None), Encoding.UTF8);
                        done = true;
                    }
                    catch (Exception) { }
                }

                // Guardo el Xml
                pedido.Parametros.Save(writer);

                // Cerramos el stream
                writer.Close();
            }
            catch (Exception ex)
            {
                Log.Error("Ocurrio un error al escribir el nuevo archivo a disco: " + ex.ToString());
            }
        }
    }
}
