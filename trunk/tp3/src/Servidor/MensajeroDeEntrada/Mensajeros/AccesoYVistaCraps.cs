using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace CasinoOnline.Servidor.MensajeroDeEntrada.Mensajeros
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

		public void EntrarCraps(XElement parametros)
		{
			try
			{
				// Recorro el Xml y busco las variables que necesito
				Nombre usuario = parametros.Attribute("usuario").Value;
				int id_mesa = int.Parse(parametros.Attribute("mesa").Value);
				int id_terminal = int.Parse(parametros.Attribute("vTerm").Value);

				// Informo la accion que se esta realizando
				Log.Mensaje("Procesando EntrarCraps: " + id_terminal + ", " + usuario + ", " + id_mesa);


				// Validaciones
				// 
				

				// Logica de negocio


				// Envio la respuesta satisfactoria
				MensajeroDeSalida.Mensajeros.AccesoYVistaCraps.ObtenerInstancia().ResponderEntradaCraps(id_terminal, usuario, id_mesa, true, "Bienvenido a la mesa!");
			}
			catch (Exception ex)
			{
				Log.Error("Ocurrio un error procesando un pedido de EntrarCraps: " + ex.ToString());
			}
		}

		public void SalirCraps(XElement parametros)
		{
			try
			{
				// Recorro el Xml y busco las variables que necesito
				Nombre usuario = parametros.Attribute("usuario").Value;
				int id_mesa = int.Parse(parametros.Attribute("mesa").Value);
				int id_terminal = int.Parse(parametros.Attribute("vTerm").Value);

				// Informo la accion que se esta realizando
				Log.Mensaje("Procesando SalirCraps: " + id_terminal + ", " + usuario + ", " + id_mesa);


				// Validaciones
				// 


				// Logica de negocio


				// Envio la respuesta satisfactoria
				MensajeroDeSalida.Mensajeros.AccesoYVistaCraps.ObtenerInstancia().ResponderEntradaCraps(id_terminal, usuario, id_mesa, true, "Gracias por gastar plata en esta mesa!");
			}
			catch (Exception ex)
			{
				Log.Error("Ocurrio un error procesando un pedido de SalirCraps: " + ex.ToString());
			}
		}
	}
}
