﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CasinoOnline.Servidor.Modelo
{
	class TodosPonen : TipoJugada
	{
		public override List<Premio> Resolverse(Jugada jugada)
		{
			throw new NotImplementedException();
		}

		public override string ObtenerNombreTipoJugada()
		{
			return "todosponen";
		}
	}
}
