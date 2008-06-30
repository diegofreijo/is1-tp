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

		#region Respuestas de la vista
		public void ResponderEntrada(int id_terminal, string usuario, string descripcion, bool aceptado)
		{
			try
			{
				XElement info = new XElement("entradaCasino");
				info.Add(new XAttribute("vTerm", id_terminal));
				info.Add(new XAttribute("usuario", usuario));
				info.Add(new XElement("aceptado", (aceptado ? "si" : "no")));
				info.Add(new XElement("modoAcceso", "jugador"));
				info.Add(new XElement("saldo", 200));
				info.Add(new XElement("descripcion", descripcion));

				Respuesta respuesta = new Respuesta();
				respuesta.Parametros = info;
				respuesta.Tipo = "responderEntrada";

				DespachadorRespuestasArchivo.ObtenerInstancia().DespacharRespuesta(respuesta);
			}
			catch(Exception ex)
			{
				Log.Error("Ocurrio un error generando la vista ResponderEntrada: " + ex.ToString());
			}
		}
		#endregion

	}
}
