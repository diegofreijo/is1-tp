using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using CasinoOnline.AdminClient.Comunication;

namespace CasinoOnline.AdminClient.Comunication.Ports
{
    using Nombre = String;
    using IdTerminalVirtual = Int32;

    class AccesoYVistaCasino
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

        #region Manejadores

        public XElement PedirEstadoCasino(Nombre nombre)
        {
            // Obtengo el id de la terminal
            IdTerminalVirtual idt = TerminalInfo.ObtenerInstancia().Id;

            // Genero el XML de salida
            XElement parametros = new XElement("estadoCasino", new object[]{
				new XAttribute("vTerm", idt),
				new XAttribute("usuario", nombre)
			});

            // Genero el pedido
            Pedido pedido = new Pedido(parametros, "pedidoEstadoCasino", idt);

            // Envio el XML de salida
            DespachadorPedidosGlobal.ObtenerInstancia().DespacharPedido(pedido);

            // Bloqueo hasta obtener una respuesta
            return ReceptorMensajesGlobal.ObtenerInstancia().ObtenerNuevoMensajeSync("respuestaEstadoCasino",idt);
        }

        public XElement EntrarCasino(Nombre nombre, ModoUsuario modo)
        {
            // Obtengo el id de la terminal
            IdTerminalVirtual idt = TerminalInfo.ObtenerInstancia().Id;

            // Genero el XML de salida
            XElement parametros = new XElement("entradaCasino", new object[]{
				new XAttribute("vTerm", idt),
				new XAttribute("usuario", nombre),
    			new XElement("modoAcceso", modo == ModoUsuario.eObservador? "observador" : "jugador")
			});

            // Genero el pedido
            Pedido pedido = new Pedido(parametros, "entradaCasino", idt);

            // Envio el XML de salida
            DespachadorPedidosGlobal.ObtenerInstancia().DespacharPedido(pedido);

            // Bloqueo hasta obtener una respuesta
            return ReceptorMensajesGlobal.ObtenerInstancia().ObtenerNuevoMensajeSync("respuestaEntradaCasino", idt);
        }

        public XElement SalirCasino(Nombre nombre)
        {
            // Obtengo el id de la terminal
            IdTerminalVirtual idt = TerminalInfo.ObtenerInstancia().Id;

            // Genero el XML de salida
            XElement parametros = new XElement("salidaCasino", new object[]{
				new XAttribute("vTerm", idt),
				new XAttribute("usuario", nombre)
			});

            // Genero el pedido
            Pedido pedido = new Pedido(parametros, "salidaCasino", idt);

            // Envio el XML de salida
            DespachadorPedidosGlobal.ObtenerInstancia().DespacharPedido(pedido);

            // Bloqueo hasta obtener una respuesta
            return ReceptorMensajesGlobal.ObtenerInstancia().ObtenerNuevoMensajeSync("respuestaSalidaCasino", idt);
        }

        #endregion
    }
}
