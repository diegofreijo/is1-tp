﻿using System;
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

			// Para saber si reseteo o no el pozo
			bool alguienCobro = false;

			Dictionary<Apuesta, Creditos> gananciasNormal = new Dictionary<Apuesta,decimal>();
			foreach(Apuesta apuesta in jugada.Apuestas)
			{
				// Veo cuanto gano
				gananciasNormal.Add(apuesta, apuesta.Resolverse(jugada.Resultado));
			}

			// Averiguo el monto total apostado
			Creditos apuestasTotales = gananciasNormal.Keys.Where(a => gananciasNormal[a] > 0).Sum(a => a.Valor);

			// Hago que cada apuesta se resuelva
			foreach (Apuesta apuesta in gananciasNormal.Keys)
			{	
				// Si gano, le pago feliz
				Creditos gananciaFeliz = 0;
				if (gananciasNormal[apuesta] > 0)
				{
					 gananciaFeliz = apuesta.Valor / apuestasTotales *
						Pozos.ObtenerInstancia().PozoFeliz.Monto;

					 alguienCobro = true;
				}
				else
				{
					gananciaFeliz = 0;
				}

				// Pago las ganancias
				apuesta.Apostador.Saldo += gananciasNormal[apuesta] + gananciaFeliz;
				ConfiguracionCasino.ObtenerInstancia().SaldoCasino -= gananciasNormal[apuesta];

				// Armo el premio
				Premio nuevoPremio = new Premio(
					apuesta.Apostador,
					apuesta.ObtenerNombreTipoApuesta(),
					apuesta.Valor,
					gananciasNormal[apuesta],
					gananciaFeliz,
					0);

				premios.Add(nuevoPremio);
			}

			// Reseteo el pozo feliz si es que alguien/es se lo llevo/aron
			if (alguienCobro)
			{
				Pozos.ObtenerInstancia().PozoFeliz.Resetear();
			}

			return premios;
		}

		public override string ObtenerNombreTipoJugada()
		{
			return "feliz";
		}
	}
}
