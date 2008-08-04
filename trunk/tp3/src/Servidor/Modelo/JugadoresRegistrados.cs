using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace CasinoOnline.Servidor.Modelo
{
	using Creditos = Decimal;

	class JugadoresRegistrados
	{
		#region Singleton
		/// <summary>
		/// La instancia de la clase
		/// </summary>
		private static JugadoresRegistrados instancia = null;

		/// <summary>
		/// Constructor privado para no permitir crear mas instancias que las necesarias
		/// </summary>
		private JugadoresRegistrados()
		{
		}

		/// <summary>
		/// Devuelve la instancia de la clase
		/// </summary>
		public static JugadoresRegistrados ObtenerInstancia()
		{
			if (instancia == null)
			{
				instancia = new JugadoresRegistrados();
			}
			return instancia;
		}
		#endregion

		private List<JugadorRegistrado> jugadores = null;


		#region Metodos Publicos

		public List<JugadorRegistrado> Jugadores
		{
			get 
			{
				if (jugadores == null)
				{
					throw new Exception("JugadoresRegistrados no fue inicializado");
				}
				return jugadores; 
			}
		}

		public void Inicializar(XElement lista)
		{
			// Levanto la lista de jugadores con sus atributos
			jugadores = lista.Elements("jugador").Select(j => 
				new JugadorRegistrado(
					j.Attribute("nombre").Value, 
					Creditos.Parse(j.Attribute("saldo").Value), 
					TextoAFactoryJugador(j.Attribute("tipo").Value))).ToList();
		}

		#endregion


		#region Metodos Privados

		private JugadorFactory TextoAFactoryJugador(string texto)
		{
			// Veo que factory es
			switch (texto)
			{
				case "normal":	return new JugadorNormalFactory();
				case "vip":		return new JugadorVipFactory();
				default: throw new ArgumentNullException("No logro machear el texto que me vino con una factory");
			}
		}

		#endregion
	}
}
