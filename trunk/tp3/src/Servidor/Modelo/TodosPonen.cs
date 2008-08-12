using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CasinoOnline.Servidor.Modelo
{
	using Creditos = Decimal;

	class TodosPonen : TipoJugada
	{
		public override List<Premio> Resolverse(Jugada jugada)
		{
			List<Premio> premios = new List<Premio>();
            Creditos perdidaTotal = 0;

			// Hago que cada apuesta se resuelva
			foreach (Apuesta apuesta in jugada.Apuestas)
			{
				// Veo cuanto gano y cuanto tiene que pagar por ser una jugada TodosPonen
				Creditos gananciaNormal = apuesta.Resolverse(jugada.Resultado);
				Creditos perdidaTodosPonen = gananciaNormal * ConfiguracionCasino.ObtenerInstancia().PorcentajeDescuentoTodosponen;
                perdidaTotal += perdidaTodosPonen;

				// Pago las ganancias y cobro las apuestas
				apuesta.Apostador.Saldo += gananciaNormal - perdidaTodosPonen;
				ConfiguracionCasino.ObtenerInstancia().SaldoCasino -= gananciaNormal - perdidaTodosPonen;

				// Armo el premio
				Premio nuevoPremio = new Premio(
					apuesta.Apostador,
					apuesta.ObtenerNombreTipoApuesta(),
					apuesta.Valor,
					gananciaNormal,
					0,
					perdidaTodosPonen);

				premios.Add(nuevoPremio);
			}

			// Actualizo el pozo feliz
            Pozos.ObtenerInstancia().PozoFeliz.Monto = Pozos.ObtenerInstancia().PozoFeliz.Monto + perdidaTotal;

			return premios;
		}

		public override string ObtenerNombreTipoJugada()
		{
			return "todosponen";
		}
	}
}
