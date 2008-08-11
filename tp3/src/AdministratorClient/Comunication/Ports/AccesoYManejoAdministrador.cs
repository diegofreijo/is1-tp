using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using CasinoOnline.AdminClient.Comunication;

namespace CasinoOnline.AdminClient.Comunication.Ports
{
    using Password = String;
    using IdTerminalVirtual = Int32;
    using IdMesa = Int32;

    class AccesoYManejoAdministrador
    {
        #region Singleton
		/// <summary>
		/// La instancia de la clase
		/// </summary>
		private static AccesoYManejoAdministrador instancia = null;

		/// <summary>
		/// Constructor privado para no permitir crear mas instancias que las necesarias
		/// </summary>
        private AccesoYManejoAdministrador()
		{
		}

		/// <summary>
		/// Devuelve la instancia de la clase
		/// </summary>
        public static AccesoYManejoAdministrador ObtenerInstancia()
		{
			if (instancia == null)
			{
                instancia = new AccesoYManejoAdministrador();
			}
			return instancia;
		}
		#endregion

        #region Manejadores

        public XElement PedirReporteEstadoActual(Password pass)
        {
            // Obtengo el id de la terminal
            IdTerminalVirtual idt = TerminalInfo.ObtenerInstancia().Id;

            // Genero el XML de salida
            XElement parametros = new XElement("pedidoReporteEstadoActual", new object[]{
				new XAttribute("vTerm", idt),
				new XAttribute("password", pass)
			});

            // Genero el pedido
            Pedido pedido = new Pedido(parametros, "pedidoReporteEstadoActual", idt);

            // Envio el XML de salida
            DespachadorPedidosGlobal.ObtenerInstancia().DespacharPedido(pedido);

            // Bloqueo hasta obtener una respuesta
            return ReceptorMensajesGlobal.ObtenerInstancia().ObtenerNuevoMensajeSync("respuestaReporteEstadoActual", idt);
        }

        public XElement PedirReporteRankingDeJugadores(Password pass)
        {
            // Obtengo el id de la terminal
            IdTerminalVirtual idt = TerminalInfo.ObtenerInstancia().Id;

            // Genero el XML de salida
            XElement parametros = new XElement("pedidoReporteRankingDeJugadores", new object[]{
				new XAttribute("vTerm", idt),
				new XAttribute("password", pass)
			});

            // Genero el pedido
            Pedido pedido = new Pedido(parametros, "pedidoReporteRankingDeJugadores", idt);

            // Envio el XML de salida
            DespachadorPedidosGlobal.ObtenerInstancia().DespacharPedido(pedido);

            // Bloqueo hasta obtener una respuesta
            return ReceptorMensajesGlobal.ObtenerInstancia().ObtenerNuevoMensajeSync("respuestaReporteRankingDeJugadores", idt);
        }

        public XElement PedirReporteMovimientos(Password pass)
        {
            // Obtengo el id de la terminal
            IdTerminalVirtual idt = TerminalInfo.ObtenerInstancia().Id;

            // Genero el XML de salida
            XElement parametros = new XElement("pedidoReporteMovimientos", new object[]{
				new XAttribute("vTerm", idt),
				new XAttribute("password", pass)
			});

            // Genero el pedido
            Pedido pedido = new Pedido(parametros, "pedidoReporteMovimientos", idt);

            // Envio el XML de salida
            DespachadorPedidosGlobal.ObtenerInstancia().DespacharPedido(pedido);

            // Bloqueo hasta obtener una respuesta
            return ReceptorMensajesGlobal.ObtenerInstancia().ObtenerNuevoMensajeSync("respuestaReporteMovimientos", idt);
        }

        public XElement ConfigurarModoDirigidoCraps(
            Password pass,
            bool bEstablecerTipoResultado, 
            ResultadoCraps resultado, 
            bool bEstablecerTipoJugada, 
            TipoJugada? tipoJugada)
        {
            // Obtengo el id de la terminal
            IdTerminalVirtual idt = TerminalInfo.ObtenerInstancia().Id;

            // Genero el XML de salida
            XElement controlResultados = new XElement("controlResultados", new object[]{
                new XAttribute("azar", (bEstablecerTipoResultado && resultado == null) ? "si" : "no"),
                new XElement("dado1", (bEstablecerTipoResultado && resultado != null) ? ValorDado2String(resultado.Dado1) : ""),
                new XElement("dado2", (bEstablecerTipoResultado && resultado != null) ? ValorDado2String(resultado.Dado2) : "")
            });

            XElement controlTipoJugada = new XElement("controlTipoJugadas", new object[]{
                new XElement("tipo", tipoJugada != null ? TipoJugada2String(tipoJugada.Value) : "")
            });

            XElement parametros = new XElement("configurarModoDirigidoCraps", new object[]{
				new XAttribute("vTerm", idt),
				new XAttribute("password", pass),
                controlResultados,
                controlTipoJugada
			});

            // Genero el pedido
            Pedido pedido = new Pedido(parametros, "configurarModoDirigidoCraps", idt);

            // Envio el XML de salida
            DespachadorPedidosGlobal.ObtenerInstancia().DespacharPedido(pedido);

            // Bloqueo hasta obtener una respuesta
            return ReceptorMensajesGlobal.ObtenerInstancia().ObtenerNuevoMensajeSync("respuestaConfigurarModoDirigidoCraps", idt);
        }

        public XElement ConfigurarModoDirigidoJugadaFeliz(Password pass, IdMesa idMesa)
        {
            // Obtengo el id de la terminal
            IdTerminalVirtual idt = TerminalInfo.ObtenerInstancia().Id;

            // Genero el XML de salida
            XElement parametros = new XElement("configurarModoDirigidoJugadaFeliz", new object[]{
				new XAttribute("vTerm", idt),
				new XAttribute("password", pass),
                new XElement("mesa", idMesa.ToString())
			});

            // Genero el pedido
            Pedido pedido = new Pedido(parametros, "configurarModoDirigidoJugadaFeliz", idt);

            // Envio el XML de salida
            DespachadorPedidosGlobal.ObtenerInstancia().DespacharPedido(pedido);

            // Bloqueo hasta obtener una respuesta
            return ReceptorMensajesGlobal.ObtenerInstancia().ObtenerNuevoMensajeSync("respuestaConfigurarModoDirigidoJugadaFeliz", idt);
        }

        #endregion

        #region helper functions

        private String TipoJugada2String(TipoJugada tipo)
        {
            Dictionary<TipoJugada, String> tipoJugada2String = new Dictionary<TipoJugada, String>();
            tipoJugada2String[TipoJugada.eAzar] = "Azar";
            tipoJugada2String[TipoJugada.eNormal] = "Normal";
            tipoJugada2String[TipoJugada.eTodosPonen] = "TodosPonen";
            tipoJugada2String[TipoJugada.eNoTodosPonen] = "NoTodosPonen";
            tipoJugada2String[TipoJugada.eNoFeliz] = "NoFeliz";
            return tipoJugada2String[tipo];
        }

        private String ValorDado2String(ValorDado valorDado)
        {
            Dictionary<ValorDado, String> valorDado2String = new Dictionary<ValorDado, String>();
            valorDado2String[ValorDado.Uno] = "1";
            valorDado2String[ValorDado.Dos] = "2";
            valorDado2String[ValorDado.Tres] = "3";
            valorDado2String[ValorDado.Cuatro] = "4";
            valorDado2String[ValorDado.Cinco] = "5";
            valorDado2String[ValorDado.Seis] = "6";
            return valorDado2String[valorDado];
        }

        #endregion // helper functions
    }
}
