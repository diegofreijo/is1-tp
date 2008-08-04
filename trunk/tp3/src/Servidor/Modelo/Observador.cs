using System;
using CasinoOnline.Servidor.Modelo;

namespace CasinoOnline.Servidor.Modelo
{
	using Nombre = String;

	class Observador : Usuario 
	{
		public Observador(Nombre nombre)
		{
			this.nombre = nombre;
		}
	}
}
