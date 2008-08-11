using System;
using CasinoOnline.Servidor.Modelo;
namespace CasinoOnline.Servidor.Modelo
{
	using Creditos = Decimal;
	using System.Collections.Generic;

	class DeCampo : ApuestaCraps
	{
		/// 
		/// <param name="fichas"></param>
		/// <param name="apostador"></param>
		/// <param name="estado"></param>
		public DeCampo(Dictionary<Creditos, int> fichas, Jugador apostador)
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

            if (valorDados == 3 ||
                valorDados == 4 ||
                valorDados == 9 ||
                valorDados == 10 ||
                valorDados == 11) // ganó 1 a 1
            {
                aPagar = CalcularPagoApuesta(fichas,1,1);
               
            }
            else if (valorDados == 2 ||                
                valorDados == 12) // ganó 2 a 1
            {
                aPagar = CalcularPagoApuesta(fichas,2,1);
            }
            //    valorDados == 5 ||                
            //    valorDados == 6 ||
            //    valorDados == 7 ||
            //    valorDados == 8              
            //                   perdió 
                
            estado = EstadoApuestaCraps.Cerrada;

            return aPagar;
		}

		public override String ObtenerNombreTipoApuesta()
		{
            return "campo";
		}
	}
}
