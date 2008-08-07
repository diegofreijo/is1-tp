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

		public override int? ObtenerPuntajeApostado()
		{
			throw new NotImplementedException();

		}

	}
}
