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
		public EnSitioAPerder(Dictionary<Creditos, int> fichas, Jugador apostador, int puntaje)
		{
			this.fichas = fichas;
			this.apostador = apostador;
			this.puntaje = puntaje;
			this.estado = EstadoApuestaCraps.Iniciada;
		}

		/// 
		/// <param name="resultado"></param>
		public override Creditos Resolverse(Resultado resultado)
		{
			throw new NotImplementedException();
		}

		public override String ObtenerNombreTipoApuesta()
		{
			return "a perder";
		}

		public override int? ObtenerPuntajeApostado()
		{
			return puntaje;
		}

	}
}
