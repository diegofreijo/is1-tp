using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CasinoOnline.Servidor.Modelo
{
	class ResultadoCraps : Resultado
	{
		#region Miembros

		private EstadoRondaCraps estado_ronda;
		private Dado dado1;
		private Dado dado2;
		private int? punto;

		#endregion


		#region Propiedades

		public Dado Dado1
		{
			get { return dado1; }
		}
		public Dado Dado2
		{
			get { return dado2; }
		}
		public EstadoRondaCraps EstadoRonda
		{
			get { return estado_ronda; }
		}
		public int? Punto
		{
			get { return punto; }
		}

		#endregion


		public ResultadoCraps(Dado dado1, Dado dado2, EstadoRondaCraps estado_ronda, int? punto)
		{
			this.dado1 = dado1;
			this.dado2 = dado2;
			this.estado_ronda = estado_ronda;
			this.punto = punto;
		}
	}
}
