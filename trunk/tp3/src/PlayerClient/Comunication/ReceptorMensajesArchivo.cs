using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Threading;
using CasinoOnline.PlayerClient.Utils;

namespace CasinoOnline.PlayerClient.Comunication
{
    using MessageId = String;
    using IdTerminalVirtual = Int32;

    class ReceptorMensajesArchivo : IReceptorMensajes
    {
        private const String m_numero_grupo = "05";
        private const String m_bufferEntrada = "..\\buffer_salida\\";
        private const int m_pollingWaitTimeMilliSeconds = 100;

        public bool ObtenerNuevoMensajeAsync(MessageId msgId, IdTerminalVirtual termId, ref XElement xml)
        {
            try
            {
                // Reviso en la lista de archivos en el buffer de entrada para ver si está el mensaje solicitado
                string archivo_esperado = msgId + m_numero_grupo + termId.ToString("D4") + ".xml";
                string ruta_archivo_esperado = m_bufferEntrada + archivo_esperado;

                string[] ruta_archivos_buffer = Directory.GetFiles(m_bufferEntrada);
                if (!ruta_archivos_buffer.Contains(ruta_archivo_esperado))
                {
                    return false;
                }
                else
                {
                    try
                    {
                        xml = XElement.Load(ruta_archivo_esperado);
                    }
                    catch (Exception ex)
                    {
                        // Informo que el XML estaba mal armado
                        Log.Error("Error cargando el mensaje XML (estaba mal armado)" + Environment.NewLine + ex.ToString());
                        return false;
                    }
                    finally
                    {
                        string backupFile = m_bufferEntrada + "_" + archivo_esperado;

                        // Borro el archivo de backup si existe
                        if (File.Exists(backupFile))
                            File.Delete(backupFile);

                        // Renombro el archivo procesado en vez de borrarlo por si interesa mirarlo...
                        File.Move(ruta_archivo_esperado, backupFile);
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error("Error obteniendo mensaje: " + Environment.NewLine + ex.ToString());
                return false;
            }

            return true;
        }

        public XElement ObtenerNuevoMensajeSync(MessageId msgId, IdTerminalVirtual termId)
        {
            // Respuesta
            XElement nuevo_xml;

            try
            {
                // Reviso en la lista de archivos en el buffer de entrada hasta obtener el mensaje solicitado
                string archivo_esperado = msgId + m_numero_grupo + termId.ToString("D4") + ".xml";
                string ruta_archivo_esperado = m_bufferEntrada + archivo_esperado;

                string[] ruta_archivos_buffer = Directory.GetFiles(m_bufferEntrada);
                while (!ruta_archivos_buffer.Contains(ruta_archivo_esperado))
                {
                    Thread.Sleep(m_pollingWaitTimeMilliSeconds);
                    ruta_archivos_buffer = Directory.GetFiles(m_bufferEntrada);
                }

                try
                {
                    nuevo_xml = XElement.Load(ruta_archivo_esperado);
                }
                catch (Exception ex)
                {
                    // Informo que el XML estaba mal armado
                    Log.Error("Error cargando el mensaje XML (estaba mal armado)" + Environment.NewLine + ex.ToString());
                    return null;
                }
                finally
                {
                    string backupFile = m_bufferEntrada + "_" + archivo_esperado;

                    // Borro el archivo de backup si existe
                    if (File.Exists(backupFile))
                        File.Delete(backupFile);

                    // Renombro el archivo procesado en vez de borrarlo por si interesa mirarlo...
                    File.Move(ruta_archivo_esperado, backupFile);
                }
            }
            catch (Exception ex)
            {
                Log.Error("Error obteniendo mensaje: " + Environment.NewLine + ex.ToString());
                return null;
            }

            return nuevo_xml;
        }
    }
}
