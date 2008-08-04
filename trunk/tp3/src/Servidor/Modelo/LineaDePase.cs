using System;
using System.Collections.Generic;
using CasinoOnline.Servidor.Modelo;

namespace CasinoOnline.Servidor.Modelo
{
	using Creditos = Decimal;
	using Nombre = String;

	class LineaDePase : ApuestaCraps
	{

		/// 
		/// <param name="fichas"></param>
		/// <param name="apostador"></param>
		/// <param name="estado"></param>
		public LineaDePase(Dictionary<Creditos, int> fichas, Jugador apostador, EstadoApuestaCraps estado)
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
