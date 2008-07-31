using System;
using Servidor.Modelo;

namespace CasinoOnline.Servidor.Modelo
{
	public class JuegoCraps
	{
		#region Singleton
		/// <summary>
		/// La instancia de la clase
		/// </summary>
		private static JuegoCraps instancia = null;

		/// <summary>
		/// Constructor privado para no permitir crear mas instancias que las necesarias
		/// </summary>
		private JuegoCraps()
		{
		}

		/// <summary>
		/// Devuelve la instancia de la clase
		/// </summary>
		public static JuegoCraps ObtenerInstancia()
		{
			if (instancia == null)
			{
				instancia = new JuegoCraps();
			}
			return instancia;
		}
		#endregion

		#region Miembros
		private String detalle_ultima_accion;
		#endregion

		#region Metodos Publicos
		/// 
		/// <param name="jug"></param>
		/// <param name="mesa"></param>
		public Boolean EntrarCraps(Nombre jug, IdMesa mesa)
		{

			throw new NotImplementedException();
		}

		/// 
		/// <param name="jugador"></param>
		/// <param name="mesa"></param>
		/// <param name="tipo_apuesta"></param>
		/// <param name="fichas"></param>
		/// <param name="puntaje_apostado"></param>
		public Boolean ApostarCraps(Nombre jugador, IdMesa mesa, String tipo_apuesta, Diccionario<Creditos, Entero> fichas, Entero puntaje_apostado)
		{
			throw new NotImplementedException();
		}

		/// 
		/// <param name="jugador"></param>
		/// <param name="mesa"></param>
		public Boolean TirarCraps(Nombre jugador, IdMesa mesa)
		{

			throw new NotImplementedException();
		}

		/// 
		/// <param name="mesa"></param>
		public Entero Dado1UltimoTiro(IdMesa mesa)
		{

			throw new NotImplementedException();
		}

		/// 
		/// <param name="mesa"></param>
		public Entero Dado2UltimoTiro(IdMesa mesa)
		{

			throw new NotImplementedException();
		}

		public String TipoJugadaUltimoTiro()
		{

			throw new NotImplementedException();
		}

		/// 
		/// <param name="mesa"></param>
		public List<Nombre> JugadoresEnMesa(IdMesa mesa)
		{

			throw new NotImplementedException();
		}

		/// 
		/// <param name="mesa"></param>
		public Nombre TiradorProximoTiro(IdMesa mesa)
		{

			throw new NotImplementedException();
		}

		/// 
		/// <param name="mesa"></param>
		public Boolean EsProximoTiroDeSalida(IdMesa mesa)
		{

			throw new NotImplementedException();
		}

		/// 
		/// <param name="mesa"></param>
		public Entero ValorPuntoProximoTiro(IdMesa mesa)
		{

			throw new NotImplementedException();
		}

		/// 
		/// <param name="mesa"></param>
		public Nombre TiradorUltimoTiro(IdMesa mesa)
		{

			throw new NotImplementedException();
		}

		/// 
		/// <param name="mesa"></param>
		public Lista<Tupla<Nombre, Creditos, Creditos, Creditos>> PremiosUltimoTiro(IdMesa mesa)
		{

			throw new NotImplementedException();
		}

		/// 
		/// <param name="mesa"></param>
		public Lista<Tupla<Nombre, String, String, DIccionario<Creditos, Entero>>> ApuestasVigentes(IdMesa mesa)
		{

			throw new NotImplementedException();
		}

		public String DetalleUltimaAccion()
		{

			throw new NotImplementedException();
		}

		public List<IdMesa> ObtenerMesasCraps()
		{

			throw new NotImplementedException();
		}
		#endregion

		#region Metodos Privados
		private MesaCraps CrearMesaCraps()
		{
			throw new NotImplementedException();
		}
		#endregion
	}
}
