using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CasinoOnline.Servidor.Modelo
{
	using Creditos = Decimal;

	abstract class Apuesta
	{
		#region Miembros
		protected Jugador apostador;
		protected Dictionary<Creditos, int> fichas;
		protected Creditos valor;
		#endregion

		
		#region Propiedades

		public Creditos Valor
		{
			get { return valor; }
		}

		#endregion


		#region Metodos Publicos

		public abstract void Resolverse(Resultado resultado);
		public abstract string ObtenerNombreTipoApuesta();

		#endregion
	}
}
