﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CasinoOnline.Servidor.Modelo
{
	class ApuestaTragamonedas : Apuesta
	{
		private int cant_fichas;


		#region Metodos Publicos

		public ApuestaTragamonedas(int cant_fichas, Creditos valor)
		{
			this.cant_fichas = cant_fichas;
			this.valor = valor;
		}
		public override void Resolverse(Resultado resultado)
		{
			throw new NotImplementedException();
		}

		public override string ObtenerNombreTipoApuesta()
		{
			throw new NotImplementedException();
		}

		#endregion
	}
}