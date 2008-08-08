using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CasinoOnline.Servidor.Modelo
{
	class Normal : TipoJugada
	{
		public override List<Premio> Resolverse(Jugada jugada)
		{
			List<Premio> premios = new List<Premio>();

			// Hago que cada apuesta se resuelva
			foreach (Apuesta apuesta in jugada.Apuestas)
			{
				// Armo el premio y pago
				Premio nuevoPremio = new Premio(
					apuesta.Apostador,
					apuesta.ObtenerNombreTipoApuesta(),
					apuesta.Valor,
					apuesta.Resolverse(jugada.Resultado),
					0,
					0);
				apuesta.Apostador.Saldo += nuevoPremio.MontoNormal;

				premios.Add(nuevoPremio);
			}

			return premios;
		}

		public override string ObtenerNombreTipoJugada()
		{
			return "normal";
		}
	}
}
