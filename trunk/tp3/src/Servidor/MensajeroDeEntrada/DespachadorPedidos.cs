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
		public void DespacharPedido(MensajeroDeSalida.Pedido pedido)
		{
			try
			{
				// El famoso switch!!!!!
				switch (pedido.Tipo)
				{
					case "entradaCasino":
						Mensajeros.AccesoYVistaCasino.ObtenerInstancia().EntrarCasino(pedido.Parametros);
						break;

					case "apuestaCraps":
						Mensajeros.JuegoCraps.ObtenerInstancia().ApostarCraps(pedido.Parametros);
						break;

					default:
						// No reconozco el tipo de pedido
						throw new Exception("Me llego un pedido que no se adonde despachar, Tipo: " + pedido.Tipo);
				}
			}
			catch (Exception ex)
			{
				Log.Error("Ocurrio un error al intentar despachar un pedido: " + ex.ToString());
			}
		}
		#endregion
	}
}
