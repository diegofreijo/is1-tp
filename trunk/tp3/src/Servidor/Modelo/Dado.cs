using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CasinoOnline.Servidor.Modelo
{
	class Dado
	{
		private int numero;

		public int Numero
		{
			get { return numero; }
		}

		public Dado(int numero)
		{
			this.numero = numero;
		}
	}
}
