using System;

namespace CasinoOnline.Servidor.Modelo
{
	using Creditos = Decimal;

	class ConfiguracionPozoProgresivo
	{
		private int cant_apuestas_jugada_maxima_gordo_progresivo;
		private Decimal porcentaje_descuento_por_apuesta;
		private Creditos monto_minimo;


		public int CantApuestasJugadaMaximaGordoProgresivo
		{
			get { return cant_apuestas_jugada_maxima_gordo_progresivo; }
		}
		public Decimal PorcentajeDescuentoPorApuesta
		{
			get { return porcentaje_descuento_por_apuesta; }
		}
		public Creditos MontoMinimo
		{
			get { return monto_minimo; }
		}

	
		/// 
		/// <param name="can_apuestas_max_gp"></param>
		/// <param name="porc_des_xa"></param>
		/// <param name="monto_minimo"></param>
		public ConfiguracionPozoProgresivo(int can_apuestas_max_gp, Decimal porc_des_xa, Creditos monto_minimo)
		{
			this.cant_apuestas_jugada_maxima_gordo_progresivo = can_apuestas_max_gp;
			this.porcentaje_descuento_por_apuesta = porc_des_xa;
			this.monto_minimo = monto_minimo;
		}
	}
}
