using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using CasinoOnline.Servidor.Utils;

namespace CasinoOnline.Servidor.MensajeroDeEntrada.Mensajeros
{
	using Nombre = String;
	using IdTerminalVirtual = Int32;
	using IdMesa = Int32;

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


		#region Manejadores

		public void EntrarCraps(XElement parametros)
		{
			// Recorro el Xml y busco las variables que necesito
			Nombre usuario = parametros.Attribute("usuario").Value;
			int? id_mesa = String.IsNullOrEmpty(parametros.Attribute("mesa").Value) ? null : IdMesa.Parse(parametros.Attribute("mesa").Value);
			IdTerminalVirtual id_terminal = IdTerminalVirtual.Parse(parametros.Attribute("vTerm").Value);

			// Invoco al modelo
			bool aceptado = Modelo.Fachadas.JuegoCraps.ObtenerInstancia().EntrarCraps(usuario, id_mesa);

			// Envio la respuesta segun el resultado de la operacion
			MensajeroDeSalida.Mensajeros.AccesoYVistaCraps.ObtenerInstancia().
				ResponderEntradaCraps(id_terminal, usuario, id_mesa, aceptado, Modelo.Fachadas.JuegoCraps.ObtenerInstancia().DetalleUltimaAccion());
		}
		public void SalirCraps(XElement parametros)
		{
			// Recorro el Xml y busco las variables que necesito
			Nombre usuario = parametros.Attribute("usuario").Value;
			IdMesa id_mesa = IdMesa.Parse(parametros.Attribute("mesa").Value);
			IdTerminalVirtual id_terminal = IdTerminalVirtual.Parse(parametros.Attribute("vTerm").Value);

			// Invoco al modelo
			bool aceptado = Modelo.Fachadas.JuegoCraps.ObtenerInstancia().SalirCraps(usuario, id_mesa);

			// Envio la respuesta segun el resultado de la operacion
			MensajeroDeSalida.Mensajeros.AccesoYVistaCraps.ObtenerInstancia().
				ResponderSalidaCraps(id_terminal, usuario, id_mesa, aceptado, Modelo.Fachadas.JuegoCraps.ObtenerInstancia().DetalleUltimaAccion());
		}

		#endregion
	}
}
