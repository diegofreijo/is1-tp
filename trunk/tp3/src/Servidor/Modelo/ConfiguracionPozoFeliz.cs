using System;

namespace CasinoOnline.Servidor.Modelo
{
	using Creditos = Decimal;

	public class ConfiguracionPozoFeliz
	{

		private Decimal porcentaje_descuento_todosponen;
		private Decimal probabilidad_ocurrencia_feliz;
		private Decimal probabilidad_ocurrencia_todosponen;
		private Creditos monto_minimo;

	
		public Decimal PorcentajeDescuentoTodosponen
		{
			get { return porcentaje_descuento_todosponen; }
		}
		public Decimal ProbabilidadOcurrenciaFeliz
		{
			get { return probabilidad_ocurrencia_feliz; }
		}
		public Decimal ProbabilidadOcurrenciaTodosponen
		{
			get { return probabilidad_ocurrencia_todosponen; }
		}
		public Creditos MontoMinimo
		{
			get { return monto_minimo; }
		}



		/// 
		/// <param name="porc_descuento_tp"></param>
		/// <param name="prob_ocurr_feliz"></param>
		/// <param name="prob_ocurr_tp"></param>
		/// <param name="monto_minimo"></param>
		public ConfiguracionPozoFeliz(Decimal porc_descuento_tp, Decimal prob_ocurr_feliz, Decimal prob_ocurr_tp, Creditos monto_minimo)
		{
			this.porcentaje_descuento_todosponen = porc_descuento_tp;
			this.probabilidad_ocurrencia_feliz = prob_ocurr_feliz;
			this.probabilidad_ocurrencia_todosponen = prob_ocurr_tp;
			this.monto_minimo = monto_minimo;
		}
	}
}
