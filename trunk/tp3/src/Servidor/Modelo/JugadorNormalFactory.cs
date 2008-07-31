using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CasinoOnline.Servidor.Modelo
{
	using Nombre = String;
	using Creditos = Decimal;

	class JugadorNormalFactory : JugadorFactory
	{
		public override Jugador CrearJugador(Nombre nombre, Creditos saldo)
		{
			return new JugadorNormal(nombre, saldo);
		}
	}
}
