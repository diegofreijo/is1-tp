using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CasinoOnline.Servidor.Modelo
{
	using Creditos = Decimal;

	abstract class Pozo
	{
		protected Creditos monto;
		protected Creditos monto_minimo;


		public Creditos Monto
		{
            set { monto = value; }
			get { return monto; }
		}
		
		public Pozo(Creditos monto_minimo)
		{
			this.monto_minimo = monto_minimo;
			this.Resetear();
		}
		public void Resetear()
		{
			// Reseteo el monto
			this.monto = monto_minimo;

			// El monto inicial lo garpa el casino
			ConfiguracionCasino.ObtenerInstancia().SaldoCasino -= this.monto;
		}
	}
}
