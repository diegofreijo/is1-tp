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
		protected Jugador apostador = null;
		protected Dictionary<Creditos, int> fichas = new Dictionary<decimal, int>();
		protected Creditos valor;
		#endregion

		
		#region Propiedades

		public Creditos Valor
		{
			get { return valor; }
		}
		public Dictionary<Creditos, int> Fichas
		{
			get { return fichas; }
		}
		public Jugador Apostador
		{
			get { return apostador; }
		}

		#endregion


		#region Metodos Publicos

		public abstract Creditos Resolverse(Resultado resultado);
		public abstract string ObtenerNombreTipoApuesta();

		#endregion
	}
}
