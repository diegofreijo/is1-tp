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
		public DeCampo(Dictionary<Creditos, int> fichas, Jugador apostador, EstadoApuestaCraps estado)
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

	}
}
