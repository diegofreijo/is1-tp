using System;
using Servidor.Modelo;

namespace CasinoOnline.Servidor.Modelo
{
	public class AdministradorDeCasino
	{
		#region Singleton
		/// <summary>
		/// La instancia de la clase
		/// </summary>
		private static AdministradorDeCasino instancia = null;

		/// <summary>
		/// Constructor privado para no permitir crear mas instancias que las necesarias
		/// </summary>
		private AdministradorDeCasino()
		{
		}

		/// <summary>
		/// Devuelve la instancia de la clase
		/// </summary>
		public static AdministradorDeCasino ObtenerInstancia()
		{
			if (instancia == null)
			{
				instancia = new AdministradorDeCasino();
			}
			return instancia;
		}
		#endregion

		#region Miembros
		private String detalle_ultima_accion;
		#endregion

		#region Metodos Publicos
		/// 
		/// <param name="pass"></param>
		public Boolean PuedePedirReporteRankingDeJugadores(String pass)
		{

			throw new NotImplementedException();
		}

		/// 
		/// <param name="pass"></param>
		public Boolean PuedePedirReporteEstadoActual(String pass)
		{

			throw new NotImplementedException();
		}

		/// 
		/// <param name="pass"></param>
		public Boolean PuedePedirReporteDetalleMovimientosPorJugador(String pass)
		{

			throw new NotImplementedException();
		}

		public String DetalleUltimaAccion()
		{

			throw new NotImplementedException();
		}

		/// 
		/// <param name="rueda1"></param>
		/// <param name="rueda2"></param>
		/// <param name="rueda3"></param>
		/// <param name="tipo_jugada"></param>
		/// <param name="pass"></param>
		public Boolean ConfigurarModoDirigidoTragamonedas(String rueda1, String rueda2, String rueda3, String tipo_jugada, String pass)
		{

			throw new NotImplementedException();
		}

		/// 
		/// <param name="dado1"></param>
		/// <param name="dado2"></param>
		/// <param name="tipo_jugada"></param>
		/// <param name="pass"></param>
		public Boolean ConfigurarModoDirigidoCraps(Entero dado1, Entero dado2, String tipo_jugada, String pass)
		{

			throw new NotImplementedException();
		}

		/// 
		/// <param name="mesa"></param>
		/// <param name="pass"></param>
		public Boolean ConfigurarModoDirigidoJugadaFeliz(IdMesa mesa, String pass)
		{

			throw new NotImplementedException();
		}

		/// 
		/// <param name="configuracion"></param>
		public void InicializarConfiguracion(Xml configuracion)
		{

		}

		/// 
		/// <param name="lista_clientes"></param>
		public void InicializarJugadoresRegistrados(Xml lista_clientes)
		{

		}

		/// 
		/// <param name="observador"></param>
		public void InicializarMesas(MesaCrapsObserver observador)
		{

		}

		public Lista<Nombre> ObtenerJugadoresMasGanadores()
		{

			throw new NotImplementedException();
		}

		public Lista<Nombre> ObtenerJugadoresMasPerdedores()
		{

			throw new NotImplementedException();
		}

		public Creditos ObtenerSaldoCasino()
		{

			throw new NotImplementedException();
		}

		public List<Tupla<Nombre, Creditos>> ObtenerJugadoresConSaldo()
		{

			throw new NotImplementedException();
		}

		public List<Tupla<Nombre, String, Creditos, Creditos, Creditos, Creditos>> DetalleMovimientoJugadores()
		{

			throw new NotImplementedException();
		}
		#endregion
	}
}
