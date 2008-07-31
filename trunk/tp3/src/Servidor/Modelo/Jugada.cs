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


		#region Metodos Publicos

		public abstract void Resolverse();

		#endregion
	}
}
