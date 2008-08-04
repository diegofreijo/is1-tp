using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CasinoOnline.Servidor.Modelo
{
	using Creditos = Decimal;

	class Premio
	{
		#region Miembros
		private Creditos monto_normal;
		private Creditos monto_feliz;
		private Creditos monto_todosponen;
		private Creditos monto_apostado;
		private String nombre_tipo_apuesta;
		private Jugador apostador;
		#endregion


		#region Propiedades

		public Creditos MontoNormal
		{
			get { return monto_normal; }
		}
		public Creditos Monto_feliz
		{
			get { return monto_feliz; }
		}
		public Creditos Monto_todosponen
		{
			get { return monto_todosponen; }
		}
		public Creditos Monto_apostado
		{
			get { return monto_apostado; }
		}
		public String Nombre_tipo_apuesta
		{
			get { return nombre_tipo_apuesta; }
		}
		public Jugador Apostador
		{
			get { return apostador; }
		}

		#endregion


		public Premio(Jugador apostador, String nombre_tipo_apuesta, Creditos monto_apostado, Creditos monto_normal, 
			Creditos monto_feliz, Creditos monto_todosponen)
		{
			this.apostador = apostador;
			this.nombre_tipo_apuesta = nombre_tipo_apuesta ;
			this.monto_apostado = monto_apostado ;
			this.monto_normal = monto_normal ;
			this.monto_feliz = monto_feliz ;
			this.monto_todosponen = monto_todosponen;
		}
	}
}
