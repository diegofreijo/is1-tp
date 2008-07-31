using System;
using System.Collections.Generic;
using Servidor.Modelo;

namespace CasinoOnline.Servidor.Modelo
{
	using Nombre = String;
	using Creditos = Decimal;

	public class LobbyCasino
	{
		#region Singleton
		/// <summary>
		/// La instancia de la clase
		/// </summary>
		private static LobbyCasino instancia = null;

		/// <summary>
		/// Constructor privado para no permitir crear mas instancias que las necesarias
		/// </summary>
		private LobbyCasino()
		{
		}

		/// <summary>
		/// Devuelve la instancia de la clase
		/// </summary>
		public static LobbyCasino ObtenerInstancia()
		{
			if (instancia == null)
			{
				instancia = new LobbyCasino();
			}
			return instancia;
		}
		#endregion

		#region Miembros
		private String detalle_ultima_accion;
		#endregion

		#region Metodos Publicos

		/// 
		/// <param name="usuario"></param>
		/// <param name="modo"></param>
		public Boolean EntrarCasino(Nombre usuario, String modo)
		{

			throw new NotImplementedException();
		}

		/// 
		/// <param name="usuario"></param>
		public Boolean SalirCasino(Nombre usuario)
		{

			throw new NotImplementedException();
		}

		/// 
		/// <param name="usuario"></param>
		public Boolean PedirEstadoCasino(Nombre usuario)
		{

			throw new NotImplementedException();
		}

		public String DetalleUltimaAccion()
		{

			throw new NotImplementedException();
		}

		public List<Nombre> JugadoresEnCasino()
		{

			throw new NotImplementedException();
		}

		public List<Nombre> ObservadoresEnCasino()
		{

			throw new NotImplementedException();
		}

		public Creditos MontoPozoFeliz()
		{

			throw new NotImplementedException();
		}

		public Creditos MontoPozoProgresivo()
		{

			throw new NotImplementedException();
		}

		#endregion

	}
}
