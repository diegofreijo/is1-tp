using System;
using CasinoOnline.Servidor.Modelo;
using System.Collections.Generic;

namespace CasinoOnline.Servidor.Modelo
{
	using Creditos = Decimal;

	class Venir : ApuestaCraps
	{

		private int puntaje_venir;

		/// 
		/// <param name="fichas"></param>
		/// <param name="apostador"></param>
		/// <param name="estado"></param>
		public Venir(Dictionary<Creditos, int> fichas, Jugador apostador)
		{
            this.fichas = fichas;
            this.apostador = apostador;
		}

		/// 
		/// <param name="resultado"></param>
		public override Creditos Resolverse(Resultado resultado)
		{

            ResultadoCraps resultadoCraps = (ResultadoCraps)resultado;

            int valorDados = resultadoCraps.Dado1.Numero + resultadoCraps.Dado2.Numero;
            
            Creditos aPagar = 0;

            if (estado == EstadoApuestaCraps.Iniciada)
            {

                if (valorDados == 7 ||
                    valorDados == 11) //ganó
                {
                    estado = EstadoApuestaCraps.Cerrada;
                    aPagar = CalcularPagoApuesta(fichas, 1, 1); // paga 1 a 1
                }                       
                if (valorDados == 2 ||
                    valorDados == 3 ||
                    valorDados == 12) // perdió
                {
                    estado = EstadoApuestaCraps.Cerrada;

                }
                if (valorDados == 4 ||
                    valorDados == 5 ||
                    valorDados == 6 ||
                    valorDados == 8 ||
                    valorDados == 9 ||
                    valorDados == 10) // puntaje venir
                {
                    puntaje_venir = valorDados;
                    estado = EstadoApuestaCraps.EnTranscurso;
                }
            }
            else { // la apuesta se desplaza al espacio de puntaje NO venir correspondiente
                if (estado == EstadoApuestaCraps.EnTranscurso)
                {
                    if (valorDados == puntaje_venir)
                    {
                        aPagar = CalcularPagoApuesta(fichas, 1, 1); // paga 1 a 1
                        estado = EstadoApuestaCraps.Cerrada;
                    }
                }
            }
            return aPagar;

		}

		public override String ObtenerNombreTipoApuesta()
		{
            return "venir";
		}

        public override int? ObtenerPuntajeApostado()
        {
            return puntaje_venir;
        }

	}
}
