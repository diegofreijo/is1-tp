using System;
using Servidor.Modelo;

namespace CasinoOnline.Servidor.Modelo
{
	using Creditos = Decimal;

	public class JugadorNormal : Jugador
	{
		public override bool PuedePagar(decimal cantidad)
		{
			return cantidad <= this.saldo;
		}
	}
}