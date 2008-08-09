using System;
using CasinoOnline.Servidor.Modelo;
using System.Collections.Generic;

namespace CasinoOnline.Servidor.Modelo
{
    using Credito = Decimal;
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
		protected Credito CalcularPagoApuesta( Dictionary<Credito, int> fichas, int a, int b) 
        {
            Credito apostado = 0; 

            foreach (Credito valorFicha in fichas.Keys) // calculo valor de la apuesta
            {
                apostado += valorFicha * fichas[valorFicha];
            }

            return a / b * apostado + apostado ;     // calculo con los factores de pago
                                                     // la ganancia + la de
        }
	}
}
