using System;
using CasinoOnline.Servidor.Modelo;
using CasinoOnline.Servidor.Comunicacion;
using System.Collections.Generic;

namespace CasinoOnline.Servidor.MensajeroDeSalida
{
	using IdMesa = Int32;
	using IdTerminalVirtual = Int32;
	using Nombre = String;

	class NotificadorDeCambiosAClientes : IMesaObserver
	{
		#region Singleton
		/// <summary>
		/// La instancia de la clase
		/// </summary>
		private static NotificadorDeCambiosAClientes instancia = null;

		/// <summary>
		/// Constructor privado para no permitir crear mas instancias que las necesarias
		/// </summary>
		private NotificadorDeCambiosAClientes()
		{
		}

		/// <summary>
		/// Devuelve la instancia de la clase
		/// </summary>
		public static NotificadorDeCambiosAClientes ObtenerInstancia()
		{
			if (instancia == null)
			{
				instancia = new NotificadorDeCambiosAClientes();
			}
			return instancia;
		}
		#endregion


		private Dictionary<Nombre, IdTerminalVirtual> terminales = new Dictionary<string,int>();

		/// 
		/// <param name="mesa"></param>
		public void NotificarCambio(IdMesa idmesa)
		{
			// Notifico el cambio a cada terminal
			foreach (Nombre usuario in Modelo.Fachadas.JuegoCraps.ObtenerInstancia().JugadoresEnMesa(idmesa))
			{
				Mensajeros.AccesoYVistaCraps.ObtenerInstancia().NotificarEstadoCraps(terminales[usuario], usuario, idmesa);
			}
		}

		/// 
		/// <param name="id_term"></param>
		/// <param name="jugador"></param>
		public void SuscribirJugadorAMesa(IdTerminalVirtual id_term, Nombre jugador)
		{
			terminales.Add(jugador, id_term);
		}

		/// 
		/// <param name="jugador"></param>
		public void DesuscribirJugadorAMesa(Nombre jugador)
		{
			terminales.Remove(jugador);
		}
	}
}
