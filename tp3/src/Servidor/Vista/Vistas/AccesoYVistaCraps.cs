using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace CasinoOnline.Servidor.Vista.Vistas
{
	using Nombre = String;

	class AccesoYVistaCraps
	{
		#region Singleton
		/// <summary>
		/// La instancia de la clase
		/// </summary>
		private static AccesoYVistaCraps instancia = null;

		/// <summary>
		/// Constructor privado para no permitir crear mas instancias que las necesarias
		/// </summary>
		private AccesoYVistaCraps()
		{
		}

		/// <summary>
		/// Devuelve la instancia de la clase
		/// </summary>
		public static AccesoYVistaCraps ObtenerInstancia()
		{
			if (instancia == null)
			{
				instancia = new AccesoYVistaCraps();
			}
			return instancia;
		}
		#endregion

		public void ResponderEntradaCraps(int id_terminal, Nombre usuario, int id_mesa, bool aceptado, String descripcion)
		{
			try
			{
				// Genero la respuesta
				XElement parametros = new XElement("respuestaEntradaCraps", new object[] {
					new XAttribute("vTerm", id_terminal),
					new XAttribute("usuario", usuario),
					new XAttribute("mesa", id_mesa),
					new XElement("aceptado", (aceptado ? "si" : "no")),
					new XElement("descripcion", descripcion)
				});

				// Despacho la respuesta
				Respuesta respuesta = new Respuesta("respuestaEntradaCraps", id_terminal, parametros);
				DespachadorRespuestasArchivo.ObtenerInstancia().DespacharRespuesta(respuesta);
			}
			catch (Exception ex)
			{
				Log.Error("Ocurrio un error generando la vista ResponderEntradaCraps: " + ex.ToString());
			}
		}

		public void ResponderSalidaCraps(int id_terminal, Nombre usuario, int id_mesa, bool aceptado, String descripcion)
		{
			try
			{
				// Genero la respuesta
				XElement parametros = new XElement("respuestaSalidaCraps", new object[] {
					new XAttribute("vTerm", id_terminal),
					new XAttribute("usuario", usuario),
					new XAttribute("mesa", id_mesa),
					new XElement("aceptado", (aceptado ? "si" : "no")),
					new XElement("descripcion", descripcion)
				});

				// Despacho la respuesta
				Respuesta respuesta = new Respuesta("respuestaSalidaCraps", id_terminal, parametros);
				DespachadorRespuestasArchivo.ObtenerInstancia().DespacharRespuesta(respuesta);
			}
			catch (Exception ex)
			{
				Log.Error("Ocurrio un error generando la vista ResponderSalidaCraps: " + ex.ToString());
			}
		}

		public void NotificarEstadoCraps(int id_terminal, Nombre usuario, int id_mesa)
		{
			try
			{
				// Genero la respuesta
				XElement parametros = new XElement("estadoMesaCraps", new object[] {
					new XAttribute("vTerm", id_terminal),
					new XAttribute("usuario", usuario),
					new XAttribute("mesa", id_mesa)
				});

				// Consulto el estado de la mesa
				throw new NotImplementedException();

				// Despacho la respuesta
				Respuesta respuesta = new Respuesta("EstadoCraps", id_terminal, parametros);
				DespachadorRespuestasArchivo.ObtenerInstancia().DespacharRespuesta(respuesta);
			}
			catch (Exception ex)
			{
				Log.Error("Ocurrio un error generando la vista NotificarEstadoCraps: " + ex.ToString());
			}
		}
	}
}
