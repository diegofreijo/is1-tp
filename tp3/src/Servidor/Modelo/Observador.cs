using System;
using Servidor.Modelo;

namespace CasinoOnline.Servidor.Modelo
{
	using Nombre = String;

	public class Observador : Usuario 
	{
		public Observador(Nombre nombre)
		{
			this.nombre = nombre;
		}
	}
}
