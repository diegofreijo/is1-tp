using System;
using CasinoOnline.Servidor.Modelo;

namespace CasinoOnline.Servidor.Modelo
{
	using Creditos = Decimal;
	using Nombre = String;

	class JugadorVip : Jugador
	{
		public JugadorVip(Nombre nombre, Creditos saldo) : base(nombre, saldo)
		{ 
		}
		public override bool PuedePagar(decimal cantidad)
		{
			return true;
		}
	}
}