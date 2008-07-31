using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CasinoOnline.Servidor.Modelo
{
	class JugadaTragamonedas : Jugada
	{
		#region Miembros
		private PozoProgresivo pozo_progresivo;
		private PremioTragamonedas premio;
		private ApuestaTragamonedas apuesta;
		#endregion


		#region Propiedades

		public PremioTragamonedas Premio
		{
			get { return premio; }
		}

		#endregion


		#region Metodos Publicos

		public JugadaTragamonedas(ApuestaTragamonedas apuesta, ResultadoTragamonedas resultado,
			TipoJugada tipo_jugada)
		{
			this.apuesta = apuesta;
			this.resultado = resultado;
			this.tipo_jugada = tipo_jugada;
		}
		public override void Resolverse()
		{
			throw new NotImplementedException();
		}


		#endregion
	}
}
