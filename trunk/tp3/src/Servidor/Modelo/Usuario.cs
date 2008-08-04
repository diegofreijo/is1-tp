using System;
using CasinoOnline.Servidor.Modelo;

namespace CasinoOnline.Servidor.Modelo
{
	using Nombre = String;

	public abstract class Usuario
	{
		protected Nombre nombre;

		public Nombre Nombre
		{
			get { return nombre; }
			set { nombre = value; }
		}
	}
}