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
		private int punto;
		private List<ApuestaCraps> apuestas;
		private List<Premio> premios;
		#endregion


		#region Propiedades

		public List<Premio> Premios
		{
			get { return premios; }
		}

		#endregion


		#region Metodos Publicos

		public JugadaCraps(List<ApuestaCraps> apuestas, ResultadoCraps reultado, 
			TipoJugada tipo, EstadoRondaCraps estado_ronda, int punto)
		{
			this.apuestas = apuestas;
			this.resultado = resultado;
			this.tipo_jugada = tipo;
			this.estado_ronda = estado_ronda;
			this.punto = punto;
		}
		public override void Resolverse()
		{
			throw new NotImplementedException();
		}
		public List<ApuestaCraps> ApuestasNoResueltas()
		{
			throw new NotImplementedException();
		}

		#endregion
	}
}
