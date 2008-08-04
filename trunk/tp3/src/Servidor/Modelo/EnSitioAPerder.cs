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
		public EnSitioAPerder(Dictionary<Creditos, int> fichas, Jugador apostador, int puntaje, EstadoApuestaCraps estado)
		{
			throw new NotImplementedException();
		}

		/// 
		/// <param name="resultado"></param>
		public override Creditos Resolverse(Resultado resultado)
		{
			throw new NotImplementedException();
		}

		public override String ObtenerNombreTipoApuesta()
		{
			throw new NotImplementedException();
		}

		public override int ObtenerPuntajeApostado()
		{
			throw new NotImplementedException();
		}

	}
}
