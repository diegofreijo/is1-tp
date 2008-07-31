using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CasinoOnline.Servidor.Comunicacion
{
	abstract class DespachadorRespuestas
	{
		public abstract void DespacharRespuesta(Respuesta respuesta);
	}
}
