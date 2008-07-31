using System;
using Servidor.Modelo;
using Servidor.Comunicacion;

namespace CasinoOnline.Servidor.MensajeroDeSalida
{
	public interface IMesaObserver
	{
		/// 
		/// <param name="mesa"></param>
		public void NotificarCambio(IdMesa mesa)
		{

		}
	}
}
