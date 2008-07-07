using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using CasinoOnline.Servidor;
using CasinoOnline.Servidor.Logueo;

namespace CasinoOnline.Servidor.Controlador.Controladores
{
	using Creditos = Int32;
	using Nombre = String;

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


		/// <summary>
		/// Procesa un pedido de apuesta de craps
		/// </summary>
		public void ApostarCraps(XElement parametros)
		{
			try
			{
				// Recorro el Xml y busco las variables que necesito
				Nombre usuario = parametros.Attribute("usuario").Value;
				int id_mesa = int.Parse(parametros.Attribute("mesa").Value);
				int id_terminal = int.Parse(parametros.Attribute("vTerm").Value);
				Dictionary<Creditos, int> fichas_apostadas = parametros.Element("valorApuesta").Elements("fichaValor").
					ToDictionary(n => int.Parse(n.Element("valor").Value), n => int.Parse(n.Element("cantidad").Value));
				Creditos apuesta_total = fichas_apostadas.Sum(f => f.Key * f.Value);

				// Informo la accion que se esta realizando
				Log.Mensaje("Procesando ApuestaCraps: " + id_terminal + ", " + usuario + ", " + id_mesa);


				// Validaciones:
				// El usuario es un jugador???????


				// El jugador esta en la mesa?
				if (!Modelo.Administradores.AdministradorMesaCraps.ObtenerInstancia().JugadoresEnMesa(id_mesa).Exists(delegate(String n) { return n == usuario; }))
				{
					Vista.Vistas.JuegoCraps.ObtenerInstancia().ResponderApuestaCraps(id_terminal, usuario, id_mesa, false);
					Log.Mensaje("Rechaze un pedido de apuesta craps por no existir el jugador en la mesa: " + id_terminal + ", " + usuario + ", " + id_mesa);
					return;
				}

				// El saldo del jugador alcanza para pagar la apuesta?
				if (Modelo.Administradores.AdministradorJugador.ObtenerInstancia().SaldoJugador(usuario) < apuesta_total)
				{
					Vista.Vistas.JuegoCraps.ObtenerInstancia().ResponderApuestaCraps(id_terminal, usuario, id_mesa, false);
					Log.Mensaje("Rechaze un pedido de apuesta craps por saldo insuficiente: " + id_terminal + ", " + usuario + ", " + id_mesa);
					return;
				}

				// Las fichas son validas?????


				// Logica de negocio


				// Envio la respuesta satisfactoria
				Vista.Vistas.JuegoCraps.ObtenerInstancia().ResponderApuestaCraps(id_terminal, usuario, id_mesa, true);
			}
			catch (Exception ex)
			{
				Log.Error("Ocurrio un error procesando un pedido de ApostarCraps: " + ex.ToString());
			}
		}

		/// <summary>
		/// Procesa una tirada de dados de craps
		/// </summary>
		public void TirarCraps(XElement parametros)
		{
			try
			{
				// Recorro el Xml y busco las variables que necesito
				Nombre usuario = parametros.Attribute("usuario").Value;
				int id_mesa = int.Parse(parametros.Attribute("mesa").Value);
				int id_terminal = int.Parse(parametros.Attribute("vTerm").Value);

				// Informo la accion que se esta realizando
				Log.Mensaje("Procesando TirarCraps: " + id_terminal + ", " + usuario + ", " + id_mesa);

				// Validaciones
				// El usuario es jugador?
				// El jugador esta en la mesa?
				// El jugador es el tirador?
				// Se cumplio el tiempo de espera necesario?

				// Logica de negocio

				// Envio la respuesta satisfactoria
				Vista.Vistas.JuegoCraps.ObtenerInstancia().ResponderTiroCraps(id_terminal, usuario, id_mesa, true);
			}
			catch (Exception ex)
			{
				Log.Error("Ocurrio un error procesando un pedido de TirarCraps: " + ex.ToString());
			}
		}
	}
}
