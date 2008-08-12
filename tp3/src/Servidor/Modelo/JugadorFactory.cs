using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CasinoOnline.Servidor.Modelo
{
	using Nombre = String;
	using Creditos = Decimal;

	abstract class JugadorFactory
	{
		public abstract Jugador CrearJugador(Nombre nombre, Creditos saldo);
		public abstract string Tipo { get; }
	}
}
