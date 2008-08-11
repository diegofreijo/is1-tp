using System;
using CasinoOnline.Servidor.Modelo;

namespace CasinoOnline.Servidor.Modelo
{
	using Creditos = Decimal;
	using System.Collections.Generic;

	class EnSitioAGanar : ApuestaCraps
	{
    	private int puntaje;

		/// 
		/// <param name="fichas"></param>
		/// <param name="apostador"></param>
		/// <param name="puntaje"></param>
		/// <param name="estado"></param>
		public EnSitioAGanar(Dictionary<Creditos, int> fichas, Jugador apostador, int puntaje)
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
            if (valorDados == 7) // perdió
            {
                estado = EstadoApuestaCraps.Cerrada;
            }
            else if (valorDados == puntaje) // ganó
            {
                if (puntaje == 4 ||
                    puntaje == 10) // paga 9 a 5
                {
                    aPagar = CalcularPagoApuesta(fichas, 9, 5);
                }
                else if (puntaje == 5 ||
                         puntaje == 9) // paga 7 a 5
                {
                    aPagar = CalcularPagoApuesta(fichas, 7, 5);
                }
                else if (puntaje == 6 ||
                         puntaje == 8) // paga 7 a 6
                {
                    aPagar = CalcularPagoApuesta(fichas, 7, 6);
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
            return "a ganar";
		}

		public override int? ObtenerPuntajeApostado()
		{
            return puntaje;
		}
	}
}
