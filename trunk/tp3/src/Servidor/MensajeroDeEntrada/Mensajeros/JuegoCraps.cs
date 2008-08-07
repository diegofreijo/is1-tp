using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using CasinoOnline.Servidor;
using CasinoOnline.Servidor.Utils;

namespace CasinoOnline.Servidor.MensajeroDeEntrada.Mensajeros
{
	using Creditos = Decimal;
	using Nombre = String;
	using IdTerminalVirtual = Int32;
	using IdMesa = Int32;

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


		#region Manejadores

		/// <summary>
		/// Procesa un pedido de apuesta de craps
		/// </summary>
		public void ApostarCraps(XElement parametros)
		{
			// Recorro el Xml y busco las variables que necesito
			Nombre usuario = parametros.Attribute("usuario").Value;
			IdMesa id_mesa = IdMesa.Parse(parametros.Attribute("mesa").Value);
			IdTerminalVirtual id_terminal = IdTerminalVirtual.Parse(parametros.Attribute("vTerm").Value);
			int? puntaje_apostado = !String.IsNullOrEmpty(parametros.Element("opcionApuesta").Element("puntajeApostado").Value) ?
				int.Parse(parametros.Element("opcionApuesta").Element("puntajeApostado").Value) : (int?)null;
			String tipo_apuesta = parametros.Element("opcionApuesta").Element("tipoApuesta").Value;
			Dictionary<Creditos, int> fichas_apostadas = parametros.Element("valorApuesta").Elements("fichaValor").
				ToDictionary(n => Creditos.Parse(n.Element("valor").Value), n => int.Parse(n.Element("cantidad").Value));
			
			// Invoco al modelo
			bool aceptado = Modelo.Fachadas.JuegoCraps.ObtenerInstancia().ApostarCraps(usuario, id_mesa, tipo_apuesta,
				fichas_apostadas, puntaje_apostado);

			// Envio la respuesta segun el resultado de la operacion
			MensajeroDeSalida.Mensajeros.JuegoCraps.ObtenerInstancia().
				ResponderApuestaCraps(id_terminal, usuario, id_mesa, aceptado);
		}
		/// <summary>
		/// Procesa una tirada de dados de craps
		/// </summary>
		public void TirarCraps(XElement parametros)
		{
			// Recorro el Xml y busco las variables que necesito
			Nombre usuario = parametros.Attribute("usuario").Value;
			IdMesa id_mesa = IdMesa.Parse(parametros.Attribute("mesa").Value);
			IdTerminalVirtual id_terminal = IdTerminalVirtual.Parse(parametros.Attribute("vTerm").Value);

			// Invoco al modelo
			bool aceptado = Modelo.Fachadas.JuegoCraps.ObtenerInstancia().TirarCraps(usuario, id_mesa);

			// Envio la respuesta segun el resultado de la operacion
			MensajeroDeSalida.Mensajeros.JuegoCraps.ObtenerInstancia().
				ResponderTiroCraps(id_terminal, usuario, id_mesa, aceptado);
		}

		#endregion
	}
}
