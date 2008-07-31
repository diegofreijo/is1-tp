using System;
using Servidor.Modelo;

namespace CasinoOnline.Servidor.Modelo
{
	public abstract class ApuestaCraps : Apuesta
	{
		private EstadoApuestaCraps estado;

		protected EstadoApuestaCraps Estado
		{
			get { return estado; }
			set { estado = value; }
		}

		public Entero ObtenerPuntajeApostado()
		{
			throw new NotImplementedException();
		}
	}
}
