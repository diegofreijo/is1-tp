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
