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
		private List<MesaCraps> mesas_craps;
		private List<MesaTragamonedas> mesas_tragamonedas;
		#endregion

		#region Metodos Publicos
		/// 
		/// <param name="id"></param>
		public MesaCraps ObtenerMesaCraps(IdMesa id)
		{
			throw new NotImplementedException();
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

			throw new NotImplementedException();
		}

		public MesaTragamonedas CrearMesaTragamonedas()
		{

			throw new NotImplementedException();
		}

		/// 
		/// <param name="mesa"></param>
		public void BorrarMesaCraps(IdMesa mesa)
		{

		}

		/// 
		/// <param name="mesa"></param>
		public void BorrarMesaTragamonedas(IdMesa mesa)
		{

		}


		#endregion
	}
}
