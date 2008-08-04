using System;
using CasinoOnline.Servidor.Modelo;

namespace CasinoOnline.Servidor.Modelo
{
	using Creditos = Decimal;
	using Nombre = String;

	abstract class Jugador : Usuario
	{
		#region Miembros
		protected Creditos saldo;
		private Mesa mesa_elegida;
		#endregion

		
		#region Propiedades
		
		public Creditos Saldo
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
		public void ElegirMesa(Mesa mesa)
		{
			mesa_elegida = mesa;
		}
		public abstract bool PuedePagar(Creditos cantidad);
		
		#endregion


	}
}