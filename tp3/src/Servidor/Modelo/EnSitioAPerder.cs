using System;
using CasinoOnline.Servidor.Modelo;

namespace CasinoOnline.Servidor.Modelo
{
	using Creditos = Decimal;
	using System.Collections.Generic;

	class EnSitioAPerder : ApuestaCraps
	{

		private int puntaje;

		/// 
		/// <param name="fichas"></param>
		/// <param name="apostador"></param>
		/// <param name="puntaje"></param>
		/// <param name="estado"></param>
		public EnSitioAPerder(Dictionary<Creditos, int> fichas, Jugador apostador, int puntaje)
		{
			this.fichas = fichas;
			this.apostador = apostador;
			this.puntaje = puntaje;
			this.estado = EstadoApuestaCraps.Iniciada;
		}

		/// 
		/// <param name="resultado"></param>
		public override Creditos Resolverse(Resultado resultado)
		{

            ResultadoCraps resultadoCraps = (ResultadoCraps)resultado;
            int valorDados = resultadoCraps.Dado1.Numero + resultadoCraps.Dado2.Numero;
            Creditos aPagar = 0;
            if (valorDados == 7)
            { // termino la apuesta
                estado = EstadoApuestaCraps.Cerrada;
            }
            if (valorDados == puntaje)
            {
                if (valorDados == 4 ||
                    valorDados == 10)
                {  // gano paga 5 a 11
                    aPagar = CalcularPagoApuesta(fichas, 5, 11);
                    estado = EstadoApuestaCraps.Cerrada;
                }
                if (valorDados == 5 ||
                    valorDados == 9) // ganó paga 5 a 8
                {
                    aPagar = CalcularPagoApuesta(fichas, 5, 8);
                    estado = EstadoApuestaCraps.Cerrada;
                }

                if (valorDados == 6 ||
                    valorDados == 8) // ganó paga 4 a 5
                {
                    aPagar = CalcularPagoApuesta(fichas, 4, 5);
                    estado = EstadoApuestaCraps.Cerrada;

                }
            }
            // no hacer nada en 2 3 5 6 8 9 10 11 12

            return aPagar;
		}

		public override String ObtenerNombreTipoApuesta()
		{
            return "en contra";
		}

		public override int? ObtenerPuntajeApostado()
		{
			return puntaje;
		}

	}
}
