using System;
using CasinoOnline.Servidor.Modelo;
using System.Collections.Generic;

namespace CasinoOnline.Servidor.Modelo
{
	using Creditos = Decimal;

	class Venir : ApuestaCraps
	{

		private int puntaje_venir;

		/// 
		/// <param name="fichas"></param>
		/// <param name="apostador"></param>
		/// <param name="estado"></param>
		public Venir(Dictionary<Creditos, int> fichas, Jugador apostador, EstadoApuestaCraps estado)
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
