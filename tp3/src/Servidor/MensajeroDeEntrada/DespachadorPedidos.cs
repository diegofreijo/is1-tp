using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CasinoOnline.Servidor;
using CasinoOnline.Servidor.Utils;

namespace CasinoOnline.Servidor.MensajeroDeEntrada
{
	/// <summary>
	/// Encargado de ver a que manejador asignarle un pedido
	/// </summary>
	class DespachadorPedidos
	{
		#region Singleton
		/// <summary>
		/// La instancia de la clase
		/// </summary>
		private static DespachadorPedidos instancia = null;

		/// <summary>
		/// Constructor privado para no permitir crear mas instancias que las necesarias
		/// </summary>
		private DespachadorPedidos()
		{
		}

		/// <summary>
		/// Devuelve la instancia de la clase
		/// </summary>
		public static DespachadorPedidos ObtenerInstancia()
		{
			if (instancia == null)
			{
				instancia = new DespachadorPedidos();
			}
			return instancia;
		}
		#endregion

		#region Metodos Publicos
		/// <summary>
		/// Despacha el pedido entrante al manejador encargado de manejarlo
		/// </summary>
		public void DespacharPedido(Comunicacion.Pedido pedido)
		{
			try
			{
				// Informo el pedido que me llego
				Log.MensajeRecepcionPedido(pedido);

				// El famoso switch!!!!!
				switch (pedido.Tipo)
				{
					// Acceso y vista casino
					case "entradaCasino":
						Mensajeros.AccesoYVistaCasino.ObtenerInstancia().EntrarCasino(pedido.Parametros);
						break;

					case "salidaCasino":
						Mensajeros.AccesoYVistaCasino.ObtenerInstancia().SalirCasino(pedido.Parametros);
						break;

					case "estadoCasino":
						Mensajeros.AccesoYVistaCasino.ObtenerInstancia().PedirEstadoCasino(pedido.Parametros);
						break;

					// Acceso y vista craps
					case "entradaCraps":
						Mensajeros.AccesoYVistaCraps.ObtenerInstancia().EntrarCraps(pedido.Parametros);
						break;

					case "salidaCraps":
						Mensajeros.AccesoYVistaCraps.ObtenerInstancia().SalirCraps(pedido.Parametros);
						break;

					// Juego craps
					case "apuestaCraps":
						Mensajeros.JuegoCraps.ObtenerInstancia().ApostarCraps(pedido.Parametros);
						break;

					case "tiroCraps":
						Mensajeros.JuegoCraps.ObtenerInstancia().TirarCraps(pedido.Parametros);
						break;

					// No encontre destinatario
					default:
						throw new Exception("Me llego un pedido que no se adonde despachar, Tipo: " + pedido.Tipo);
				}
			}
			catch (Exception ex)
			{
				// Escribo de forma bonita que hubo un error procesando el pedido
				Log.ErrorProcesandoPedido(pedido, ex);
			}
		}
		#endregion
	}
}
