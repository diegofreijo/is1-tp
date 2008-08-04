using System;
using CasinoOnline.Servidor.Modelo;

namespace CasinoOnline.Servidor.Modelo
{
	abstract class ApuestaCraps : Apuesta
	{
		private EstadoApuestaCraps estado;

		protected EstadoApuestaCraps Estado
		{
			get { return estado; }
			set { estado = value; }
		}

		public virtual int ObtenerPuntajeApostado()
		{
			throw new NotImplementedException();
		}
	}
}
