using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CasinoOnline.Servidor.Modelo
{
	using IdMesa = Int32;

	class MesasAbiertas
	{
		#region Singleton
		/// <summary>
		/// La instancia de la clase
		/// </summary>
		private static MesasAbiertas instancia = null;

		/// <summary>
		/// Constructor privado para no permitir crear mas instancias que las necesarias
		/// </summary>
		private MesasAbiertas()
		{
		}

		/// <summary>
		/// Devuelve la instancia de la clase
		/// </summary>
		public static MesasAbiertas ObtenerInstancia()
		{
			if (instancia == null)
			{
				instancia = new MesasAbiertas();
			}
			return instancia;
		}
		#endregion

		#region Miembros
		/// <summary>
		/// Id de la siguiente mesa a crear
		/// </summary>
		private int contador_idmesa = 1;
		private MensajeroDeSalida.IMesaObserver observador_cambios_craps;
		private List<MesaCraps> mesas_craps = new List<MesaCraps>();
		private List<MesaTragamonedas> mesas_tragamonedas = new List<MesaTragamonedas>();

		#endregion


		#region Propiedades

		public List<MesaCraps> MesasCraps
		{
			get { return mesas_craps; }
		}
		public List<MesaTragamonedas> MesasTragamonedas
		{
			get { return mesas_tragamonedas; }
		}

		#endregion


		#region Metodos Publicos
		/// 
		/// <param name="id"></param>
		public MesaCraps ObtenerMesaCraps(IdMesa id)
		{
			return mesas_craps.Single(m => m.Id == id);
		}

		/// 
		/// <param name="id"></param>
		public MesaTragamonedas ObtenerMesaTragamonedas(IdMesa id)
		{
			throw new NotImplementedException();
		}

		/// 
		/// <param name="observador"></param>
		public void Inicializar(MensajeroDeSalida.IMesaObserver observador)
		{
			// Me guardo el observador para futuras mesas
			this.observador_cambios_craps = observador;
		}

		public MesaCraps CrearMesaCraps()
		{
			MesaCraps nuevaMesa = new MesaCraps(contador_idmesa++, observador_cambios_craps);
			mesas_craps.Add(nuevaMesa);
			return nuevaMesa;
		}

		public MesaTragamonedas CrearMesaTragamonedas()
		{
			throw new NotImplementedException();
		}

		/// 
		/// <param name="mesa"></param>
		public void BorrarMesaCraps(IdMesa idmesa)
		{
			mesas_craps.Remove(ObtenerMesaCraps(idmesa));
		}

		/// 
		/// <param name="mesa"></param>
		public void BorrarMesaTragamonedas(IdMesa idmesa)
		{
			throw new NotImplementedException();
		}
		
		#endregion
	}
}
