using System.Xml.Linq;
using CasinoOnline.Servidor;
using CasinoOnline.Servidor.Controlador;

namespace CasinoOnline.Servidor.Controlador.Controladores
{
	public class AccesoYVistaCasino
	{
		#region Singleton
		/// <summary>
		/// La instancia de la clase
		/// </summary>
		private static AccesoYVistaCasino instancia = null;

		/// <summary>
		/// Constructor privado para no permitir crear mas instancias que las necesarias
		/// </summary>
		private AccesoYVistaCasino()
		{
		}

		/// <summary>
		/// Devuelve la instancia de la clase
		/// </summary>
		public static AccesoYVistaCasino ObtenerInstancia()
		{
			if (instancia == null)
			{
				instancia = new AccesoYVistaCasino();
			}
			return instancia;
		}
		#endregion

		public void EntrarCasino(XElement parametros)
		{
			Vista.Vistas.AccesoYVistaCasino.ObtenerInstancia().ResponderEntrada(9999, "pepe", "como te va", true);
		}

		public void PedirEstadoCasino(XElement parametros)
		{

		}

		public void SalirCasino(XElement parametros)
		{

		}
	}
}