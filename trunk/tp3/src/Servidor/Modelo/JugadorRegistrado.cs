using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CasinoOnline.Servidor.Modelo
{
	using Nombre = String;
	using Creditos = Decimal;

	class JugadorRegistrado
	{
		private Nombre nombre;
		private Creditos saldo;
		private JugadorFactory constructor_jugador = null;

		public JugadorFactory ConstructorJugador
		{
			get { return constructor_jugador; }
			set { constructor_jugador = value; }
		}

		public Nombre Nombre
		{
			get { return nombre; }
			set { nombre = value; }
		}

		public Creditos Saldo
		{
			get { return saldo; }
			set { saldo = value; }
		}

		public JugadorRegistrado(Nombre nombre, Creditos saldo, JugadorFactory constructor_jugador)
		{
			this.nombre = nombre;
			this.saldo = saldo;
			this.constructor_jugador = constructor_jugador;
		}
	}
}
