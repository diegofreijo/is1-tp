using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CasinoOnline.Servidor.Modelo
{
	using Creditos = Decimal;

	class Feliz : TipoJugada
	{
		public override List<Premio> Resolverse(Jugada jugada)
		{
			List<Premio> premios = new List<Premio>();

			// Averiguo el monto total apostado
			Creditos apuestasTotales = jugada.Apuestas.Sum(a => a.Valor);

			// Hago que cada apuesta se resuelva
			foreach (Apuesta apuesta in jugada.Apuestas)
			{
				// Veo cuanto gano
				Creditos gananciaNormal = apuesta.Resolverse(jugada.Resultado);
				Creditos gananciaFeliz = apuesta.Valor / apuestasTotales * 
					Pozos.ObtenerInstancia().ProzoFeliz.Monto;

				// Pago las ganancias
				apuesta.Apostador.Saldo += gananciaNormal + gananciaFeliz;

				// Armo el premio
				Premio nuevoPremio = new Premio(
					apuesta.Apostador,
					apuesta.ObtenerNombreTipoApuesta(),
					apuesta.Valor,
					gananciaNormal,
					gananciaFeliz,
					0);

				premios.Add(nuevoPremio);
			}

			// Reseteo el pozo feliz
			Pozos.ObtenerInstancia().ProzoFeliz.Resetear();

			return premios;
		}

		public override string ObtenerNombreTipoJugada()
		{
			return "feliz";
		}
	}
}
