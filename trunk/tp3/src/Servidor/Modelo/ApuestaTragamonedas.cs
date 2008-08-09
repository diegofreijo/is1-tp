using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CasinoOnline.Servidor.Modelo
{
	using Creditos = Decimal;
	using Nombre = String;

	class ApuestaTragamonedas : Apuesta
	{
		private int cant_fichas;
		private Creditos valor_ficha;


		#region Metodos Publicos

		public ApuestaTragamonedas(int cant_fichas, Creditos valor)
		{
			this.cant_fichas = cant_fichas;
			this.valor_ficha = valor;
		}
		public override Creditos Resolverse(Resultado resultado)
		{
			throw new NotImplementedException();
		}

		public override string ObtenerNombreTipoApuesta()
		{
			throw new NotImplementedException();
		}

		#endregion
	}
}
