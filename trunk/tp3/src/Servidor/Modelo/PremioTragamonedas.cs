using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CasinoOnline.Servidor.Modelo
{
	using Creditos = Decimal;

	class PremioTragamonedas : Premio
	{
		private Creditos monto_progresivo;

		public PremioTragamonedas(Jugador apostador, String nombre_tipo_apuesta, Creditos monto_apostado, 
			Creditos monto_normal, Creditos monto_feliz, Creditos monto_todosponen, Creditos monto_progresivo) 
			: base(apostador, nombre_tipo_apuesta, monto_apostado, monto_normal, monto_feliz, monto_todosponen)
		{
			this.monto_progresivo = monto_progresivo;
		}
	}
}
