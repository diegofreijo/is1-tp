using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CasinoOnline.Servidor.Comunicacion
{
	interface IDespachadorRespuestasEspecifico
	{
		public void DespacharRespuesta(Respuesta respuesta);
	}
}
