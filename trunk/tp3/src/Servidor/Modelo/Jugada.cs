using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CasinoOnline.Servidor.Modelo
{
	abstract class Jugada
	{
		#region Miembros

		protected Jugador tirador;
		protected Resultado resultado;
		protected TipoJugada tipo_jugada;
		protected PozoFeliz pozo_feliz;

		#endregion


		#region Propiedades

		public Jugador Tirador
		{
			get { return tirador; }
		}
		public Resultado Resultado
		{
			get { return resultado; }
		}
		public TipoJugada TipoJugada
		{
			get { return tipo_jugada; }
		}
		public PozoFeliz PozoFeliz
		{
			get { return pozo_feliz; }
		}
		public abstract List<Apuesta> Apuestas
		{
			get;
		}

		#endregion


		#region Metodos Publicos

		public Jugada(Jugador tirador, Resultado resultado, TipoJugada tipo_jugada, PozoFeliz pozo_feliz)
		{
			this.tirador = tirador;
			this.resultado = resultado;
			this.tipo_jugada = tipo_jugada;
			this.pozo_feliz = pozo_feliz;
		}

		public abstract void Resolverse();

		#endregion
	}
}
