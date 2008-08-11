using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Xml.Linq;
using CasinoOnline.Servidor.Utils;
using System.Reflection.Emit;
using System.Xml;

namespace CasinoOnline.Servidor.Comunicacion
{
	/// <summary>
	/// Receptor de pedidos XML desde archivos
	/// </summary>
    class ObtenedorPedidosArchivo : IObtenedorPedidos
    {
        #region Miembros
		private const string ruta_buffer_entrada = "..\\buffer_entrada\\";
        #endregion


		#region Metodos Publicos

		/// <summary>
		/// Constructor por defecto
		/// </summary>
		public ObtenedorPedidosArchivo()
		{
			// Borro (logicamente) todos los archivos en los buffers que puedan ser considerados pedidos
			string[] ruta_archivos_buffer = Directory.GetFiles(ruta_buffer_entrada);
			foreach (string ruta_archivo_actual in ruta_archivos_buffer)
			{
				if (EsArchivoUnPedido(ruta_archivo_actual))
				{
					// Es un pedido, borro el archivo
					BorrarArchivo(Path.GetFileName(ruta_archivo_actual));
				}
			}
		}
		
		/// <summary>
        /// Obtiene el siguiente XML a procesar
        /// </summary>
		public bool ObtenerNuevoPedido(ref XElement nuevo_xml)
        {
			try
			{
				// Reviso en la lista de archivos en el buffer si alguno es valido como pedido
				string ruta_archivo = "";
				string nombre_archivo = "";
				string[] ruta_archivos_buffer = Directory.GetFiles(ruta_buffer_entrada);
				foreach (string ruta_archivo_actual in ruta_archivos_buffer)
				{
					if (EsArchivoUnPedido(ruta_archivo_actual))
					{
						ruta_archivo = ruta_archivo_actual;
						nombre_archivo = Path.GetFileName(ruta_archivo);
						break;
					}
				}

				// Si no levante ninguna ruta, es porque no habia mensaje nuevo
				if (String.IsNullOrEmpty(ruta_archivo))
					return false;

				// Intento abrir el archivo solo para ver si tengo acceso o no
				XmlTextReader xml_reader;
				try
				{
					xml_reader = new XmlTextReader(File.Open(ruta_archivo, FileMode.Open, FileAccess.ReadWrite));
				}
				catch (IOException )
				{
					// Considero que el archivo esta en uso asi que no lo toco por ahora
					return false;
				}

				// Lo trato de parsear
				bool levantado = false;
				try
				{ 
					nuevo_xml = XElement.Load(xml_reader);
					levantado = true;
				}
				catch (Exception ex)
				{
					// Informo que el XML estaba mal armado
					Log.Error("Error cargando el nuevo XML (estaba mal armado)" + Environment.NewLine + ex.ToString());
					levantado = false;
				}
				finally
				{
					// Cierro el reader
					xml_reader.Close();

					// Borro el archivo
					BorrarArchivo(nombre_archivo);
				}

				return levantado;
			}
			catch (Exception ex)
			{
				Log.Error("Error obteniendo pedido: " + Environment.NewLine + ex.ToString());
				return false;
			}
        }
		
		#endregion


		#region Metdos Privados
		
		/// <summary>
		/// Informa si la ruta del archivo es un archivo de pedido
		/// </summary>
		private bool EsArchivoUnPedido(string ruta_archivo)
		{
			return
				!Path.GetFileName(ruta_archivo).StartsWith("_") &&
				Path.GetExtension(ruta_archivo) == ".xml";
		}

		/// <summary>
		/// Borra el archivo para que no se lo vuelva a levantar de nuevo
		/// </summary>
		private void BorrarArchivo(string nombre_archivo)
		{
			string ruta_archivo = Path.Combine(ruta_buffer_entrada, nombre_archivo);
			string ruta_borrado = Path.Combine(ruta_buffer_entrada, "_" + nombre_archivo);

			// Borro el archivo de backup si existe
			if (File.Exists(ruta_borrado))
				File.Delete(ruta_borrado);

			// Renombro el archivo procesado en vez de borrarlo por si interesa mirarlo...
			File.Move(ruta_archivo, ruta_borrado);
		}
		
		#endregion
	}
}
