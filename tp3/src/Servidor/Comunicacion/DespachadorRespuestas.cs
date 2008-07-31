using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CasinoOnline.Servidor.Comunicacion
{
	class DespachadorRespuestas
	{
		#region Singleton
		/// <summary>
		/// La instancia de la clase
		/// </summary>
		private static DespachadorRespuestas instancia = null;

		/// <summary>
		/// Constructor privado para no permitir crear mas instancias que las necesarias
		/// </summary>
		private DespachadorRespuestas()
		{
		}

		/// <summary>
		/// Devuelve la instancia de la clase
		/// </summary>
		public static DespachadorRespuestas ObtenerInstancia()
		{
			if (instancia == null)
			{
				instancia = new DespachadorRespuestas();
			}
			return instancia;
		}
		#endregion

		private IDespachadorRespuestasEspecifico despachador;


		public IDespachadorRespuestasEspecifico Despachador
		{
			set { despachador = value; }
		}

		
		public void DespacharRespuesta(Respuesta respuesta)
		{
			despachador.DespacharRespuesta(respuesta);
		}
		

	}
}