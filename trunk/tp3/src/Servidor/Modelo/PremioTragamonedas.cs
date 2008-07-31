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

		public PremioTragamonedas(Jugador jugador, Texto nombre_tipo_apuesta, Creditos monto_apostado, 
			Creditos monto_normal, Creditos monto_feliz, Creditos monto_todosponen, Creditos monto_progresivo)
		{
			this.jugador = jugador;
			this.nombre_tipo_apuesta = nombre_tipo_apuesta ;
			this.monto_apostado = monto_apostado ;
			this.monto_normal = monto_normal ;
			this.monto_feliz = monto_feliz ;
			this.monto_todosponen = monto_todosponen;
			this.monto_progresivo = monto_progresivo;
		}
	}
}
