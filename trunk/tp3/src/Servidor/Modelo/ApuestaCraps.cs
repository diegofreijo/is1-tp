using System;
using CasinoOnline.Servidor.Modelo;

namespace CasinoOnline.Servidor.Modelo
{
	abstract class ApuestaCraps : Apuesta
	{
		protected EstadoApuestaCraps estado;

		public EstadoApuestaCraps Estado
		{
			get { return estado; }
		}

		public virtual int? ObtenerPuntajeApostado()
		{
			return null;
		}
	}
}
