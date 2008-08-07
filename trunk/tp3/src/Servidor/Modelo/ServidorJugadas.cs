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
		private Dictionary<IdMesa, KeyValuePair<SelectorTipoJugada, SelectorResultadoCraps>> mesas_craps = 
			new Dictionary<int,KeyValuePair<SelectorTipoJugada,SelectorResultadoCraps>>();
		private Dictionary<IdMesa, KeyValuePair<SelectorTipoJugada, SelectorResultadoTragamonedas>> mesas_tragamonedas = 
			new Dictionary<int,KeyValuePair<SelectorTipoJugada,SelectorResultadoTragamonedas>>();
		#endregion


		#region Metodos Publicos
		/// 
		/// <param name="mesa"></param>
		public TipoJugada CalcularTipoJugadaDeCasinoCraps(IdMesa mesa)
		{
			if (!mesas_craps.ContainsKey(mesa))
			{
				mesas_craps.Add(mesa, new KeyValuePair<SelectorTipoJugada,SelectorResultadoCraps>(
					new SelectorAzar(), new SelectorResultadoAlAzarCraps()));
			}
			return mesas_craps[mesa].Key.SeleccionarTipoJugada();
		}
		/// 
		/// <param name="mesa"></param>
		public TipoJugada CalcularTipoJugadaDeCasinoTragamonedas(IdMesa mesa)
		{
			throw new NotImplementedException();
		}
		public KeyValuePair<Dado, Dado> CalcularDados(IdMesa mesa)
		{
			if (!mesas_craps.ContainsKey(mesa))
			{
				mesas_craps.Add(mesa, new KeyValuePair<SelectorTipoJugada, SelectorResultadoCraps>(
					new SelectorAzar(), new SelectorResultadoAlAzarCraps()));
			}
			return mesas_craps[mesa].Value.SeleccionarResultado();
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
			if (!mesas_craps.ContainsKey(mesa))
			{
				mesas_craps.Add(mesa, new KeyValuePair<SelectorTipoJugada, SelectorResultadoCraps>(
					selector, new SelectorResultadoAlAzarCraps()));
			}
			else
			{
				mesas_craps[mesa] = new KeyValuePair<SelectorTipoJugada,SelectorResultadoCraps>(selector, mesas_craps[mesa].Value);
			}
		}
		/// 
		/// <param name="mesa"></param>
		/// <param name="selector"></param>
		public void EstablecerResultadoCraps(IdMesa mesa, SelectorResultadoCraps selector)
		{
			if (!mesas_craps.ContainsKey(mesa))
			{
				mesas_craps.Add(mesa, new KeyValuePair<SelectorTipoJugada, SelectorResultadoCraps>(
					new SelectorAzar(), selector));
			}
			else
			{
				mesas_craps[mesa] = new KeyValuePair<SelectorTipoJugada,SelectorResultadoCraps>(mesas_craps[mesa].Key, selector);
			}
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
