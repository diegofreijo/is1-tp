using System;
using Servidor.Modelo;

namespace CasinoOnline.Servidor.Modelo
{
	using Creditos = Decimal;
	using Nombre = String;

	public abstract class Jugador : Usuario
	{
		#region Miembros
		protected Creditos saldo;
		private Mesa mesa_elegida;
		#endregion

		#region Propiedades
		protected Creditos Saldo
		{
			get { return saldo; }
			set { saldo = value; }
		}

		public Mesa MesaElegida
		{
			get { return mesa_elegida; }
		}
		#endregion

		#region Metodos Publicos
		public Jugador(Nombre nombre, Creditos saldo)
		{
			this.nombre = nombre;
			this.saldo = saldo;
		}

		public abstract bool PuedePagar(Creditos cantidad);

		public void ElegirMesa(Mesa mesa)
		{
			mesa_elegida = mesa;
		}
		#endregion


	}
}