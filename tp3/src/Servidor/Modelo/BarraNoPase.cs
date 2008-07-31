using System;
using Servidor.Modelo;

namespace CasinoOnline.Servidor.Modelo
{
	public class BarraNoPase : ApuestaCraps
	{


		/// 
		/// <param name="fichas"></param>
		/// <param name="apostador"></param>
		/// <param name="estado"></param>
		public BarraNoPase(Diccionario<Creditos, Entero> fichas, Jugador apostador, EstadoApuestaCraps estado)
		{
			throw new NotImplementedException();
		}

		/// 
		/// <param name="resultado"></param>
		public override Creditos Resolverse(Resultado resultado)
		{
			throw new NotImplementedException();
		}

		public override Texto ObtenerNombreTipoApuesta()
		{
			throw new NotImplementedException();
		}

		public override Entero ObtenerPuntajeApostado()
		{
			throw new NotImplementedException();
		}

	}
}
