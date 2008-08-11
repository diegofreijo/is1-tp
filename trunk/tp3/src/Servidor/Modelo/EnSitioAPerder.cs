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
            if (valorDados == puntaje) // perdió
            {
                estado = EstadoApuestaCraps.Cerrada;
            }
            else if (valorDados == 7) // ganó
            {
                if (puntaje == 4 ||
                    puntaje == 10)
                {  // paga 5 a 11
                    aPagar = CalcularPagoApuesta(fichas, 5, 11);
                }
                else if (puntaje == 5 ||
                         puntaje == 9) // paga 5 a 8
                {
                    aPagar = CalcularPagoApuesta(fichas, 5, 8);
                }
                else if (puntaje == 6 ||
                         puntaje == 8) // paga 4 a 5
                {
                    aPagar = CalcularPagoApuesta(fichas, 4, 5);
                }

                estado = EstadoApuestaCraps.Cerrada;
            }
            else // si no se resolvió
            {
                estado = EstadoApuestaCraps.EnTranscurso;
            }

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
