using System;
using CasinoOnline.Servidor.Modelo;

namespace CasinoOnline.Servidor.Modelo
{
	using Creditos = Decimal;
	using System.Collections.Generic;

	class BarraNoPase : ApuestaCraps
	{


		/// 
		/// <param name="fichas"></param>
		/// <param name="apostador"></param>
		/// <param name="estado"></param>
		public BarraNoPase(Dictionary<Creditos, int> fichas, Jugador apostador)
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


            if (resultadoCraps.EstadoRonda == EstadoRondaCraps.EstanSaliendo)
            {
                if (valorDados == 7 ||
                    valorDados == 11) // ganó
                {
                    aPagar = CalcularPagoApuesta(fichas, 1, 1); // paga 1 a 1
                }
                if (valorDados == 2 ||
                    valorDados == 3 ||
                    valorDados == 12) // perdio
                {
                    estado = EstadoApuestaCraps.Cerrada;
                }
                if (valorDados == 12) // empató
                {
                    aPagar = CalcularPagoApuesta(fichas, 1, 1); // paga 1 a 1
                    aPagar = aPagar / 2;
                    estado = EstadoApuestaCraps.Cerrada;
                }
                if (valorDados == 4 ||
                     valorDados == 5 ||
                     valorDados == 6 ||
                     valorDados == 8 ||
                     valorDados == 9 ||
                     valorDados == 10)
                {
                    estado = EstadoApuestaCraps.EnTranscurso;
                }


            }
            else 
            {
                if (resultadoCraps.EstadoRonda == EstadoRondaCraps.PuntoEstablecido)
                {
                    if (valorDados == 7)// perdió
                    {
                        aPagar = CalcularPagoApuesta(fichas, 1, 1); // paga 1 a 1
                        estado = EstadoApuestaCraps.Cerrada;

                    }
                    if (valorDados == resultadoCraps.Punto) // ganó
                    {
                        estado = EstadoApuestaCraps.Cerrada;
                    }
                }
            }

            return aPagar;

        }

		public override String ObtenerNombreTipoApuesta()
		{
            return "no pase";
		}

        //public override int? ObtenerPuntajeApostado()
        //{
        //    throw new NotImplementedException();
        //}

	}
}
