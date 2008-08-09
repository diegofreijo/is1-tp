using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace CasinoOnline.PlayerClient.Comunication.Ports
{
    using Nombre = String;
    using IdMesa = Int32;
    using IdTerminalVirtual = Int32;
    using ValorFicha = Decimal;

    class JuegoCraps
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

        #region helper functions

        private String TipoApuestaCraps2String(ref TipoApuestaCraps tipo)
        {
            Dictionary<TipoApuestaCraps, String> tipoApuestaCraps2String = new Dictionary<TipoApuestaCraps, String>();
            tipoApuestaCraps2String[TipoApuestaCraps.eLineaDePase] = "pase";
            tipoApuestaCraps2String[TipoApuestaCraps.eBarraNoPase] = "no pase";
            tipoApuestaCraps2String[TipoApuestaCraps.eVenir] = "venir";
            tipoApuestaCraps2String[TipoApuestaCraps.eNoVenir] = "no venir";
            tipoApuestaCraps2String[TipoApuestaCraps.eDeCampo] = "campo";
            tipoApuestaCraps2String[TipoApuestaCraps.eEnSitioAGanar] = "a ganar";
            tipoApuestaCraps2String[TipoApuestaCraps.eEnSitioEnContra] = "en contra";
            return tipoApuestaCraps2String[tipo];
        }

        private String PuntoEnSitioCraps2String(ref PuntoEnSitioCraps punto)
        {
            /*if (punto == null)
                return "";*/

            Dictionary<PuntoEnSitioCraps, String> puntoEnSitioCraps2String = new Dictionary<PuntoEnSitioCraps, String>();
            puntoEnSitioCraps2String[PuntoEnSitioCraps.e4] = "4";
            puntoEnSitioCraps2String[PuntoEnSitioCraps.e5] = "5";
            puntoEnSitioCraps2String[PuntoEnSitioCraps.eSEIS] = "6";
            puntoEnSitioCraps2String[PuntoEnSitioCraps.e8] = "8";
            puntoEnSitioCraps2String[PuntoEnSitioCraps.eNUEVE] = "9";
            puntoEnSitioCraps2String[PuntoEnSitioCraps.e10] = "10";
            return puntoEnSitioCraps2String[punto];
        }

        private XElement FichasApostadas2XElement(ref List<KeyValuePair<ValorFicha, int>> fichasApostadas)
        {
            XElement valorApuesta = new XElement("valorApuesta");
            for (int i = 0; i < fichasApostadas.Count; ++i)
            {
                valorApuesta.Add(
                    new XElement("fichaValor", new object[]{
                        new XElement("cantidad",fichasApostadas[i].Value),
                        new XElement("valor",fichasApostadas[i].Key)
                    })
                );
            }
            return valorApuesta;
        }

        #endregion // helper functions

        #region Manejadores

        public XElement TirarCraps(Nombre nombre, IdMesa idMesa)
        {
            // Obtengo el id de la terminal
            IdTerminalVirtual idt = TerminalInfo.ObtenerInstancia().Id;

            // Genero el XML de salida
            XElement parametros = new XElement("tiroCraps", new object[]{
				new XAttribute("vTerm", idt),
				new XAttribute("usuario", nombre),
    			new XAttribute("mesa", idMesa.ToString())
			});

            // Genero el pedido
            Pedido pedido = new Pedido(parametros, "tiroCraps", idt);

            // Envio el XML de salida
            DespachadorPedidosGlobal.ObtenerInstancia().DespacharPedido(pedido);

            // Bloqueo hasta obtener una respuesta
            return ReceptorMensajesGlobal.ObtenerInstancia().ObtenerNuevoMensajeSync("respuestaTiroCraps", idt);
        }

        public XElement ApostarCraps(Nombre nombre, IdMesa idMesa, List<KeyValuePair<ValorFicha,int>> fichasApostadas, TipoApuestaCraps tipoApuesta, PuntoEnSitioCraps punto)
        {
            // Obtengo el id de la terminal
            IdTerminalVirtual idt = TerminalInfo.ObtenerInstancia().Id;

            // Genero el XML de salida
            XElement parametros = new XElement("apuestaCraps", new object[]{
				new XAttribute("vTerm", idt),
				new XAttribute("usuario", nombre),
    			new XAttribute("mesa", idMesa.ToString()),
                new XElement("opcionApuesta", new object[]{
                    new XElement("tipoApuesta", TipoApuestaCraps2String(ref tipoApuesta)),
                    new XElement("puntajeApostado", PuntoEnSitioCraps2String(ref punto))
                }),
                FichasApostadas2XElement(ref fichasApostadas)
			});

            // Genero el pedido
            Pedido pedido = new Pedido(parametros, "apuestaCraps", idt);

            // Envio el XML de salida
            DespachadorPedidosGlobal.ObtenerInstancia().DespacharPedido(pedido);

            // Bloqueo hasta obtener una respuesta
            return ReceptorMensajesGlobal.ObtenerInstancia().ObtenerNuevoMensajeSync("respuestaApuestaCraps", idt);
        }

        #endregion
    }
}
