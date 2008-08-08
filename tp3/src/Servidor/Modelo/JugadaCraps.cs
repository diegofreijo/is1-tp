using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CasinoOnline.Servidor.Modelo
{
	class JugadaCraps : Jugada
	{
		#region Miembros

		private EstadoRondaCraps estado_ronda;
		private int? punto;
		private List<ApuestaCraps> apuestas;
		private List<Premio> premios = null;
		
		#endregion


		#region Propiedades

		public List<Premio> Premios
		{
			get { return premios; }
		}
		public override List<Apuesta> Apuestas
		{
			get { return apuestas.Cast<Apuesta>().ToList(); }
		}

		#endregion


		#region Metodos Publicos

		public JugadaCraps(Jugador tirador, ResultadoCraps resultado, TipoJugada tipo_jugada, PozoFeliz pozo_feliz,
			EstadoRondaCraps estado_ronda, int? punto, List<ApuestaCraps> apuestas)
			: base(tirador, resultado, tipo_jugada, pozo_feliz)
		{
			this.estado_ronda = estado_ronda;
			this.punto = punto;
			this.apuestas = apuestas;
		}
		public override void Resolverse()
		{
			this.premios = tipo_jugada.Resolverse(this);
		}
		public List<ApuestaCraps> ApuestasNoResueltas()
		{
			return apuestas.Where(a => a.Estado == EstadoApuestaCraps.EnTranscurso).ToList();
		}

		#endregion
	}
}
