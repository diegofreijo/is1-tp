using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using CasinoOnline.Servidor.Utils;

namespace CasinoOnline.Servidor.MensajeroDeSalida.Mensajeros
{
	public class AccesoYVistaCasino
	{
		#region Singleton
		/// <summary>
		/// La instancia de la clase
		/// </summary>
		private static AccesoYVistaCasino instancia = null;

		/// <summary>
		/// Constructor privado para no permitir crear mas instancias que las necesarias
		/// </summary>
		private AccesoYVistaCasino()
		{
		}

		/// <summary>
		/// Devuelve la instancia de la clase
		/// </summary>
		public static AccesoYVistaCasino ObtenerInstancia()
		{
			if (instancia == null)
			{
				instancia = new AccesoYVistaCasino();
			}
			return instancia;
		}
		#endregion

		public void ResponderEntradaCasino(int id_terminal, string usuario, string descripcion, bool aceptado)
		{
			try
			{
				// Genero la respuesta
				XElement parametros = new XElement("entradaCasino", new object[] {
						new XAttribute("vTerm", id_terminal),
						new XAttribute("usuario", usuario)
				});
				if (aceptado)
				{
					throw new NotImplementedException();
				}
				else
				{
					parametros.Add(new object[] {
						new XElement("aceptado", "no"),
						new XElement("modoAcceso"),
						new XElement("saldo"),
						new XElement("descripcion", descripcion)
					});
				}

				// Despacho la respuesta
				Respuesta respuesta = new Respuesta("respuestaEntradaCasino", id_terminal, parametros);
				DespachadorRespuestasArchivo.ObtenerInstancia().DespacharRespuesta(respuesta);
			}
			catch(Exception ex)
			{
				Log.Error("Ocurrio un error generando la vista ResponderEntradaCasino: " + ex.ToString());
			}
		}

		public void ResponderSalidaCasino(int id_terminal, string usuario, string descripcion, bool aceptado)
		{
			try
			{
				// Genero la respuesta
				XElement parametros = new XElement("entradaCasino", new object[] {
						new XAttribute("vTerm", id_terminal),
						new XAttribute("usuario", usuario)
				});
				if (aceptado)
				{
					throw new NotImplementedException();
				}
				else
				{
					parametros.Add(new object[] {
						new XElement("aceptado", "no"),
						new XElement("modoAcceso"),
						new XElement("saldo"),
						new XElement("descripcion", descripcion)
					});
				}

				// Despacho la respuesta
				Respuesta respuesta = new Respuesta("respuestaEntradaCasino", id_terminal, parametros);
				DespachadorRespuestasArchivo.ObtenerInstancia().DespacharRespuesta(respuesta);
			}
			catch (Exception ex)
			{
				Log.Error("Ocurrio un error generando la vista ResponderEntradaCasino: " + ex.ToString());
			}
		}

		public void ResponderEstadoCasino(int id_terminal, string usuario)
		{
			try
			{
				// Genero la respuesta
				XElement parametros = new XElement("estadoCasino", new object[] {
						new XAttribute("vTerm", id_terminal),
						new XAttribute("usuario", usuario)
				});
				
				// Logica de negocio
				throw new NotImplementedException();

				// Despacho la respuesta
				Respuesta respuesta = new Respuesta("respuestaEstadoCasino", id_terminal, parametros);
				DespachadorRespuestasArchivo.ObtenerInstancia().DespacharRespuesta(respuesta);
			}
			catch (Exception ex)
			{
				Log.Error("Ocurrio un error generando la vista ResponderEstadoCasino: " + ex.ToString());
			}
		}
	}
}
