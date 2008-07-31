using System;
using Servidor.Modelo;

namespace CasinoOnline.Servidor.Modelo
{
	public class NoVenir : ApuestaCraps
	{

		private Entero puntaje_no_venir;

		/// 
		/// <param name="fichas"></param>
		/// <param name="apostador"></param>
		/// <param name="estado"></param>
		public NoVenir(Diccionario<Creditos, Entero> fichas, Jugador apostador, EstadoApuestaCraps estado)
		{
			throw new NotImplementedException();
		}

		/// 
		/// <param name="resultado"></param>
		public override Creditos Resolverse(Resultado resultado)
		{
			throw new NotImplementedException();
			return null;
		}

		public override Texto ObtenerNombreTipoApuesta()
		{
			throw new NotImplementedException();
			return null;
		}

		public override Entero ObtenerPuntajeApostado()
		{
			throw new NotImplementedException();
			return null;
		}

	}
}
