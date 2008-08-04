using System;
using CasinoOnline.Servidor.Modelo;

namespace CasinoOnline.Servidor.Modelo
{
	using Creditos = Decimal;
	using Nombre = String;

	class JugadorNormal : Jugador
	{
		public JugadorNormal(Nombre nombre, Creditos saldo)
			: base(nombre, saldo)
		{
		}
		public override bool PuedePagar(decimal cantidad)
		{
			return cantidad <= this.saldo;
		}
	}
}