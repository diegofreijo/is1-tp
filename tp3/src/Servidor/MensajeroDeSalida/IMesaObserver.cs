using System;
using CasinoOnline.Servidor.Modelo;
using CasinoOnline.Servidor.Comunicacion;

namespace CasinoOnline.Servidor.MensajeroDeSalida
{
	using IdMesa = Int32;

	public interface IMesaObserver
	{
		/// 
		/// <param name="mesa"></param>
		void NotificarCambio(IdMesa mesa);
	}
}
