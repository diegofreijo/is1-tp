using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CasinoOnline.Servidor.Modelo
{
	class JugadaTragamonedas : Jugada
	{
		#region Miembros
		private PozoProgresivo pozo_progresivo = null;
		private PremioTragamonedas premio = null;
		private ApuestaTragamonedas apuesta;
		#endregion


		#region Propiedades

		public PremioTragamonedas Premio
		{
			get { return premio; }
		}

		#endregion


		#region Metodos Publicos

		public JugadaTragamonedas(Jugador tirador, ResultadoTragamonedas resultado, TipoJugada tipo_jugada, PozoFeliz pozo_feliz,
			ApuestaTragamonedas apuesta)
			: base(tirador, resultado, tipo_jugada, pozo_feliz)
		{
			this.apuesta = apuesta;
		}
		public override void Resolverse()
		{
			throw new NotImplementedException();
		}


		#endregion
	}
}
