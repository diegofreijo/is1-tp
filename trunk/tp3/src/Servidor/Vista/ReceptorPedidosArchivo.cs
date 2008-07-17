using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Xml.Linq;
using CasinoOnline.Servidor.Logueo;
using System.Reflection.Emit;

namespace CasinoOnline.Servidor.Vista
{
	/// <summary>
	/// Receptor de pedidos XML desde archivos
	/// </summary>
    class ReceptorPedidosArchivo : ReceptorPedidos
    {
        #region Miembros
		private const string ruta_buffer_entrada = "..\\buffer_entrada\\";
        #endregion

		#region Metodos Protegidos
        /// <summary>
        /// Obtiene el siguiente XML a procesar
        /// </summary>
		protected override bool ObtenerNuevoPedido(ref XElement nuevo_xml)
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
			if(String.IsNullOrEmpty(ruta_archivo))
				return false;

			// Lo levanto
			try
			{
				nuevo_xml = XElement.Load(ruta_archivo);
			}
			catch(Exception ex)
			{
				Log.Error("Excepcion levantando el nuevo XML.\n	Ruta: " + ruta_archivo + ".\n	Excepcion: " + ex.ToString());
			}

			// Borro el archivo del buffer de entrada
			File.Move(ruta_archivo, ruta_buffer_entrada + "_" + nombre_archivo);

        	return true;
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
