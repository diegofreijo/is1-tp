using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace CasinoOnline.Servidor.MensajeroDeSalida.Mensajeros
{
	using Nombre = String;
	using CasinoOnline.Servidor.Utils;

	class JuegoCraps
	{
		#region Singleton
		/// <summary>
		/// La instancia de la clase
		/// </summary>
		private static JuegoCraps instancia = null;

		/// <summary>
		/// Constructor privado para no permitir crear mas instancias que las necesarias
		/// </summary>
		private JuegoCraps()
		{
		}

		/// <summary>
		/// Devuelve la instancia de la clase
		/// </summary>
		public static JuegoCraps ObtenerInstancia()
		{
			if (instancia == null)
			{
				instancia = new JuegoCraps();
			}
			return instancia;
		}
		#endregion

		public void ResponderApuestaCraps(int id_terminal, Nombre usuario, int id_mesa, bool aceptado)
		{
			try
			{
				// Genero la respuesta
				XElement parametros = new XElement("respuestaApuestaCraps", new object[] {
					new XAttribute("vTerm", id_terminal),
					new XAttribute("usuario", usuario),
					new XAttribute("mesa", id_mesa),
					new XElement("aceptado", (aceptado ? "si" : "no"))
				});

				// Despacho la respuesta
				Respuesta respuesta = new Respuesta("respuestaApuestaCraps", id_terminal, parametros);
				DespachadorRespuestasArchivo.ObtenerInstancia().DespacharRespuesta(respuesta);
			}
			catch (Exception ex)
			{
				Log.Error("Ocurrio un error generando la vista ResponderApuestaCraps: " + ex.ToString());
			}
		}

		public void ResponderTiroCraps(int id_terminal, Nombre usuario, int id_mesa, bool aceptado)
		{
			try
			{
				// Genero la parte en comun de la respuesta a ambos casos
				XElement parametros = new XElement("respuestaTiroCraps", new object[] {
					new XAttribute("vTerm", id_terminal),
					new XAttribute("usuario", usuario),
					new XAttribute("mesa", id_mesa),
					new XElement("aceptado", (aceptado ? "si" : "no"))
				});

				// Termino la respuesta dependiendo si fue o no aceptado el tiro
				if (aceptado)
				{
					parametros.Add(new XElement("tipoJugada"));
					parametros.Add(new XElement("resultado"));
					throw new NotImplementedException();
				}
				else
				{
					parametros.Add(new XElement("resultado"));
				}

				// Despacho la respuesta
				Respuesta respuesta = new Respuesta("respuestaTiroCraps", id_terminal, parametros);
				DespachadorRespuestasArchivo.ObtenerInstancia().DespacharRespuesta(respuesta);
			}
			catch (Exception ex)
			{
				Log.Error("Ocurrio un error generando la vista ResponderTiroCraps: " + ex.ToString());
			}
		}
	}
}
