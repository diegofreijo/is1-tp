using System;
using CasinoOnline.Servidor.Modelo;
using System.Collections.Generic;

namespace CasinoOnline.Servidor.Modelo
{
	using Creditos = Decimal;

	class NoVenir : ApuestaCraps
	{
		private int puntaje_no_venir;

		/// 
		/// <param name="fichas"></param>
		/// <param name="apostador"></param>
		/// <param name="estado"></param>
		public NoVenir(Dictionary<Creditos, int> fichas, Jugador apostador)
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
                    valorDados == 11) //perdi�
                {
                    estado = EstadoApuestaCraps.Cerrada;
                }
                else if (valorDados == 2 ||
                    valorDados == 3) // gan�
                {
                    aPagar = CalcularPagoApuesta(fichas, 1, 1); // paga 1 a 1
                    estado = EstadoApuestaCraps.Cerrada;
                }
                else if (valorDados == 12) // empat� se le devuelve lo apostado
                {
                    aPagar = CalcularPagoApuesta(fichas,1,1) / 2; 
                    estado = EstadoApuestaCraps.Cerrada;
                }
                else if (valorDados == 4 ||
                    valorDados == 5 ||
                    valorDados == 6 ||
                    valorDados == 8 ||
                    valorDados == 9 ||
                    valorDados == 10) // puntaje venir
                {
                    puntaje_no_venir= valorDados;
                    estado = EstadoApuestaCraps.EnTranscurso;
                }
            }
            else // puntaje no venir establecido
            {
                if (valorDados == 7) // gan�
                {
                    aPagar = CalcularPagoApuesta(fichas, 1, 1); // paga 1 a 1
                    estado = EstadoApuestaCraps.Cerrada;
                }
                else if (valorDados == puntaje_no_venir) // perdi�
                {
                    estado = EstadoApuestaCraps.Cerrada;
                }
            }

            return aPagar;
		}

		public override String ObtenerNombreTipoApuesta()
		{
            return "no venir";
		}

		public override int? ObtenerPuntajeApostado()
		{
            return this.puntaje_no_venir;
		}
	}
}
