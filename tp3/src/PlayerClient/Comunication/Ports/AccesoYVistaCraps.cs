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

    class AccesoYVistaCraps
    {
        #region Singleton
		/// <summary>
		/// La instancia de la clase
		/// </summary>
		private static AccesoYVistaCraps instancia = null;

		/// <summary>
		/// Constructor privado para no permitir crear mas instancias que las necesarias
		/// </summary>
        private AccesoYVistaCraps()
		{
		}

		/// <summary>
		/// Devuelve la instancia de la clase
		/// </summary>
        public static AccesoYVistaCraps ObtenerInstancia()
		{
			if (instancia == null)
			{
                instancia = new AccesoYVistaCraps();
			}
			return instancia;
		}
		#endregion

        #region Manejadores

        public XElement EntrarCraps(Nombre nombre, IdMesa idMesa)
        {
            // Obtengo el id de la terminal
            IdTerminalVirtual idt = TerminalInfo.ObtenerInstancia().Id;

            // Genero el XML de salida
            XElement parametros = new XElement("entradaCraps", new object[]{
				new XAttribute("vTerm", idt),
				new XAttribute("usuario", nombre),
    			new XAttribute("mesa", idMesa == -1? "" : idMesa.ToString())
			});

            // Genero el pedido
            Pedido pedido = new Pedido(parametros, "entradaCraps", idt);

            // Envio el XML de salida
            DespachadorPedidosGlobal.ObtenerInstancia().DespacharPedido(pedido);

            // Bloqueo hasta obtener una respuesta
            return ReceptorMensajesGlobal.ObtenerInstancia().ObtenerNuevoMensajeSync("respuestaEntradaCraps", idt);
        }

        public XElement SalirCraps(Nombre nombre, IdMesa idMesa)
        {
            // Obtengo el id de la terminal
            IdTerminalVirtual idt = TerminalInfo.ObtenerInstancia().Id;

            // Genero el XML de salida
            XElement parametros = new XElement("salidaCraps", new object[]{
				new XAttribute("vTerm", idt),
				new XAttribute("usuario", nombre),
    			new XAttribute("mesa", idMesa.ToString())
			});

            // Genero el pedido
            Pedido pedido = new Pedido(parametros, "salidaCraps", idt);

            // Envio el XML de salida
            DespachadorPedidosGlobal.ObtenerInstancia().DespacharPedido(pedido);

            // Bloqueo hasta obtener una respuesta
            return ReceptorMensajesGlobal.ObtenerInstancia().ObtenerNuevoMensajeSync("respuestaSalidaCraps", idt);
        }

        public bool EstadoCraps(ref XElement msg)
        {
            // Obtengo el id de la terminal
            IdTerminalVirtual idt = TerminalInfo.ObtenerInstancia().Id;

            // Intento obtener una respuesta (no bloqueante)
            return ReceptorMensajesGlobal.ObtenerInstancia().ObtenerNuevoMensajeAsync("estadoCraps", idt, ref msg);
        }

        #endregion
    }
}
