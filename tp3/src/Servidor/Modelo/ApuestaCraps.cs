using System;
using System.Linq;
using CasinoOnline.Servidor.Modelo;
using System.Collections.Generic;

namespace CasinoOnline.Servidor.Modelo
{
    using Creditos = Decimal;
	abstract class ApuestaCraps : Apuesta
	{
		protected EstadoApuestaCraps estado;

		public EstadoApuestaCraps Estado
		{
			get { return estado; }
		}

		public virtual int? ObtenerPuntajeApostado()
		{
			return null;
		}

		/// <summary>
		/// Calcula el pago "a a b"
		/// </summary>
		protected Creditos CalcularPagoApuesta(Dictionary<Creditos, int> fichas, int a, int b) 
        {
			// Calculo la apuesta total
			Creditos apostado = fichas.Sum(f => f.Key * f.Value);

			// Devuelvo la ganancia  mas lo apostado
			return (Decimal)a / (Decimal)b * apostado + apostado;
        }
	}
}
