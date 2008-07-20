﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using CasinoOnline.Servidor.Logueo;

namespace CasinoOnline.Servidor.Vista
{
	class DespachadorRespuestasArchivo : DespachadorRespuestas
	{
		private const string numero_grupo = "05";
		private const string buffer_salida = "..\\buffer_salida\\";

		#region Singleton
		/// <summary>
		/// La instancia de la clase
		/// </summary>
		private static DespachadorRespuestasArchivo instancia = null;

		/// <summary>
		/// Constructor privado para no permitir crear mas instancias que las necesarias
		/// </summary>
		private DespachadorRespuestasArchivo()
		{
		}

		/// <summary>
		/// Devuelve la instancia de la clase
		/// </summary>
		public static DespachadorRespuestasArchivo ObtenerInstancia()
		{
			if (instancia == null)
			{
				instancia = new DespachadorRespuestasArchivo();
			}
			return instancia;
		}
		#endregion

		public override void DespacharRespuesta(Respuesta respuesta)
		{
			// Escribo un nuevo archivo XML al buffer de salida
			try
			{
				// Genero el nombre del archivo
				string ruta_archivo = buffer_salida + respuesta.Tipo + numero_grupo + respuesta.IdTerminal + ".xml";

				// Guardo el Xml
				respuesta.Parametros.Save(ruta_archivo);
			}
			catch (Exception ex)
			{
				Log.Error("Ocurrio un error al escribir el nuevo archivo a disco: " + ex.ToString());
			}

			// Informo que se envio una nueva respuesta
			Log.Mensaje("Envie una respuesta de tipo " + respuesta.Tipo);
		}
	}
}