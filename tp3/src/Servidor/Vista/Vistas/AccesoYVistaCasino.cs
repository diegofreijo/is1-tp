using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using CasinoOnline.Servidor.Logueo;

namespace CasinoOnline.Servidor.Vista.Vistas
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

		public void ResponderEntrada(int id_terminal, string usuario, string descripcion, bool aceptado)
		{
			try
			{
				// Genero la respuesta
				XElement parametros = new XElement("entradaCasino", new object[] {
					new XAttribute("vTerm", id_terminal),
					new XAttribute("usuario", usuario),
					new XElement("aceptado", (aceptado ? "si" : "no")),
					new XElement("modoAcceso", "jugador"),
					new XElement("saldo", 200),
					new XElement("descripcion", descripcion),
				});

				// Despacho la respuesta
				Respuesta respuesta = new Respuesta("responderEntrada", id_terminal, parametros);
				DespachadorRespuestasArchivo.ObtenerInstancia().DespacharRespuesta(respuesta);
			}
			catch(Exception ex)
			{
				Log.Error("Ocurrio un error generando la vista ResponderEntrada: " + ex.ToString());
			}
		}



	}
}
