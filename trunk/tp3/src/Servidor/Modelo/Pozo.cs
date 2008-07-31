﻿using System;
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
			get { return monto; }
		}

		
		public virtual Pozo(Creditos monto_minimo)
		{
			this.monto_minimo = monto_minimo;
			this.Resetear();
		}
		public void Resetear()
		{
			this.monto = monto_minimo;
		}
	}
}
