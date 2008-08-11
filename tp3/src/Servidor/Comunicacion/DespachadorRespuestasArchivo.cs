using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;
using CasinoOnline.Servidor.Utils;

namespace CasinoOnline.Servidor.Comunicacion
{
	class DespachadorRespuestasArchivo : IDespachadorRespuestasEspecifico
	{
		#region Miembros
		private const string numero_grupo = "05";
		private const string buffer_salida = "..\\buffer_salida\\";
		#endregion


		#region Metodos Publicos

		public void DespacharRespuesta(Respuesta respuesta)
		{
			// Escribo un nuevo archivo XML al buffer de salida
			try
			{
				// Genero el nombre del archivo
				string ruta_archivo = buffer_salida + respuesta.Tipo + numero_grupo + respuesta.IdTerminal.ToString("D4") + ".xml";

                // Obtengo un writer de acceso exclusivo
                bool done = false;
                XmlTextWriter writer = null;
                while (!done)
                {
                    try
                    {
                        writer = new XmlTextWriter(File.Open(ruta_archivo, FileMode.Create, FileAccess.Write, FileShare.None), Encoding.UTF8);
                        done = true;
                    } catch (Exception) { }
                }

				// Guardo el Xml
                respuesta.Parametros.Save(writer);

                // Cerramos el stream
                writer.Close();
			}
			catch (Exception ex)
			{
				Log.Error("Ocurrio un error al escribir el nuevo archivo a disco: " + ex.ToString());
			}

			// Informo que se envio una nueva respuesta
			Log.MensajeEnvioRespuesta(respuesta);
		}

		#endregion
	}
}
