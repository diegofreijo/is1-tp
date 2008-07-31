using System;
using Servidor.Modelo;

namespace CasinoOnline.Servidor.Modelo
{
	using Creditos = Decimal;

	public class JugadorVip : Jugador
	{
		public override bool PuedePagar(decimal cantidad)
		{
			return true;
		}
	}
}