using System.Xml.Linq;
using CasinoOnline.Servidor;
using CasinoOnline.Servidor.MensajeroDeEntrada;

namespace CasinoOnline.Servidor.MensajeroDeEntrada.Mensajeros
{
	using Nombre = String;

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

		#region Metodos Manejadores

		public void EntrarCasino(XElement parametros)
		{
			try
			{
				// Recorro el Xml y busco las variables que necesito
				Nombre usuario = parametros.Attribute("usuario").Value;
				int id_terminal = int.Parse(parametros.Attribute("vTerm").Value);

				// Informo la accion que se esta realizando
				Log.Mensaje("Procesando EntrarCasino: " + id_terminal + ", " + usuario + ", " + id_mesa);


				// Validaciones
				// El usuario es observador o (es jugador y esta registrado como jugador)?
				// El usuario ya entro al casino?

				// Envio la respuesta
				MensajeroDeSalida.Mensajeros.AccesoYVistaCasino.ObtenerInstancia().ResponderEntradaCasino(id_terminal, usuario, "Bienvenido al CasinoOnlie Grupo 05! Esperamos que gastes mucha plata.", true);
			}
			catch (Exception ex)
			{
				Log.Error("Ocurrio un error procesando un pedido de EntrarCasino: " + ex.ToString());
			}
		}

		public void SalirCasino(XElement parametros)
		{
			try
			{
				// Recorro el Xml y busco las variables que necesito
				Nombre usuario = parametros.Attribute("usuario").Value;
				int id_terminal = int.Parse(parametros.Attribute("vTerm").Value);

				// Informo la accion que se esta realizando
				Log.Mensaje("Procesando SalirCasino: " + id_terminal + ", " + usuario + ", " + id_mesa);


				// Validaciones
				// El usuario es observador o (es jugador y esta registrado como jugador)?
				// El usuario ya entro al casino?

				// Envio la respuesta
				MensajeroDeSalida.Mensajeros.AccesoYVistaCasino.ObtenerInstancia().ResponderSalidaCasino(id_terminal, usuario, "Esperamos que la proximas traigas mas plata para gastar! Chau!", true);
			}
			catch (Exception ex)
			{
				Log.Error("Ocurrio un error procesando un pedido de SalirCasino: " + ex.ToString());
			}
		}

		public void PedirEstadoCasino(XElement parametros)
		{
			try
			{
				// Recorro el Xml y busco las variables que necesito
				Nombre usuario = parametros.Attribute("usuario").Value;
				int id_terminal = int.Parse(parametros.Attribute("vTerm").Value);

				// Informo la accion que se esta realizando
				Log.Mensaje("Procesando PedirEstadoCasino: " + id_terminal + ", " + usuario + ", " + id_mesa);


				// Validaciones
				// El usuario existe y entro al casino?

				// Envio la respuesta
				MensajeroDeSalida.Mensajeros.AccesoYVistaCasino.ObtenerInstancia().ResponderEstadoCasino(id_terminal, usuario);
			}
			catch (Exception ex)
			{
				Log.Error("Ocurrio un error procesando un pedido de PedirEstadoCasino: " + ex.ToString());
			}
		}

		#endregion
	}
}