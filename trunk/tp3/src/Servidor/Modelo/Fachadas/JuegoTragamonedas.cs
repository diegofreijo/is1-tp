using System;
using CasinoOnline.Servidor.Modelo;

namespace CasinoOnline.Servidor.Modelo.Fachadas
{
	using IdMesa = Int32;
	using Creditos = Decimal;
	using Nombre = String;
	using System.Collections.Generic;

	class JuegoTragamonedas
	{
		#region Singleton
		/// <summary>
		/// La instancia de la clase
		/// </summary>
		private static JuegoTragamonedas instancia = null;

		/// <summary>
		/// Constructor privado para no permitir crear mas instancias que las necesarias
		/// </summary>
		private JuegoTragamonedas()
		{
		}

		/// <summary>
		/// Devuelve la instancia de la clase
		/// </summary>
		public static JuegoTragamonedas ObtenerInstancia()
		{
			if (instancia == null)
			{
				instancia = new JuegoTragamonedas();
			}
			return instancia;
		}
		#endregion

		#region Miembros

		private IdMesa idmesa_recien_creada;
		private String detalle_ultima_accion;
		
		#endregion


		#region Metodos Publicos

		/// 
		/// <param name="jugador"></param>
		public Boolean EntrarTragamonedas(Nombre jugador)
		{

			throw new NotImplementedException();
		}

		/// 
		/// <param name="jugador"></param>
		/// <param name="mesa"></param>
		public Boolean SalirTragamonedas(Nombre jugador, IdMesa mesa)
		{
			throw new NotImplementedException();
		}

		/// 
		/// <param name="jugador"></param>
		/// <param name="mesa"></param>
		/// <param name="fichas"></param>
		public Boolean ApostarTragamonedas(Nombre jugador, IdMesa mesa, int fichas)
		{

			throw new NotImplementedException();
		}

		/// 
		/// <param name="jugador"></param>
		/// <param name="mesa"></param>
		public Boolean TirarTragamonedas(Nombre jugador, IdMesa mesa)
		{

			throw new NotImplementedException();
		}

		public IdMesa ObtenerIdMesaRecienCreada()
		{

			throw new NotImplementedException();
		}

		public List<KeyValuePair<KeyValuePair<KeyValuePair<KeyValuePair<KeyValuePair<IdMesa, Nombre>, Nombre>, String>, String>, String>> ObtenerDatosTragamonedas()
		{

			throw new NotImplementedException();
		}

		public String DetalleUltimaAccion()
		{

			throw new NotImplementedException();
		}
		#endregion
	}
}
