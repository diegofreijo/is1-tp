using System;
using System.Collections.Generic;
using CasinoOnline.Servidor;

namespace CasinoOnline.Servidor.Modelo
{
	using IdMesa = Int32;

	class ServidorJugadas
	{
		#region Singleton
		/// <summary>
		/// La instancia de la clase
		/// </summary>
		private static ServidorJugadas instancia = null;

		/// <summary>
		/// Constructor privado para no permitir crear mas instancias que las necesarias
		/// </summary>
		private ServidorJugadas()
		{
		}

		/// <summary>
		/// Devuelve la instancia de la clase
		/// </summary>
		public static ServidorJugadas ObtenerInstancia()
		{
			if (instancia == null)
			{
				instancia = new ServidorJugadas();
			}
			return instancia;
		}
		#endregion


		#region Miembros
		private Dictionary<IdMesa, KeyValuePair<SelectorTipoJugada, SelectorResultadoCraps>> mesas_craps;
		private Dictionary<IdMesa, KeyValuePair<SelectorTipoJugada, SelectorResultadoTragamonedas>> mesas_tragamonedas;
		#endregion


		#region Metodos Publicos
		/// 
		/// <param name="mesa"></param>
		public TipoJugada CalcularTipoJugadaDeCasinoCraps(IdMesa mesa)
		{
			throw new NotImplementedException();
		}
		/// 
		/// <param name="mesa"></param>
		public TipoJugada CalcularTipoJugadaDeCasinoTragamonedas(IdMesa mesa)
		{
			throw new NotImplementedException();
		}
		public KeyValuePair<Dado, Dado> CalcularDados()
		{
			throw new NotImplementedException();
		}
		public KeyValuePair<KeyValuePair<RodilloTragamonedas, RodilloTragamonedas>, RodilloTragamonedas> CalcularRodillos()
		{
			throw new NotImplementedException();
		}
		/// 
		/// <param name="mesa"></param>
		/// <param name="selector"></param>
		public void EstablecerTipoJugadaCraps(IdMesa mesa, SelectorTipoJugada selector)
		{
			throw new NotImplementedException();
		}
		/// 
		/// <param name="mesa"></param>
		/// <param name="selector"></param>
		public void EstablecerResultadoCraps(IdMesa mesa, SelectorResultadoCraps selector)
		{
			throw new NotImplementedException();
		}
		/// 
		/// <param name="mesa"></param>
		/// <param name="selector"></param>
		public void EstablecerTipoJugadaTragamonedas(IdMesa mesa, SelectorTipoJugada selector)
		{
			throw new NotImplementedException();
		}
		/// 
		/// <param name="mesa"></param>
		/// <param name="selector"></param>
		public void EstablecerResultadoTragamonedas(IdMesa mesa, SelectorResultadoTragamonedas selector)
		{
			throw new NotImplementedException();
		}

		#endregion
	}
}
