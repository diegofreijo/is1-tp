using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Xml.Linq;
using CasinoOnline.Servidor.Utils;
using System.Reflection.Emit;

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

		#region Metodos Protegidos
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
					}
				}

				// Si no levante ninguna ruta, es porque no habia mensaje nuevo
				if (String.IsNullOrEmpty(ruta_archivo))
					return false;

				// Lo trato de levantar
				bool levantado = false;
				try
				{
					nuevo_xml = XElement.Load(ruta_archivo);
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
					// Borro el archivo del buffer de entrada
					File.Move(ruta_archivo, ruta_buffer_entrada + "_" + nombre_archivo);
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
		#endregion
	}
}
