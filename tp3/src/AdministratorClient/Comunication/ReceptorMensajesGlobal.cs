using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace CasinoOnline.AdminClient.Comunication
{
    using MessageId = String;
    using IdTerminalVirtual = Int32;

    class ReceptorMensajesGlobal
    {
        #region Singleton
		/// <summary>
		/// La instancia de la clase
		/// </summary>
		private static ReceptorMensajesGlobal instancia = null;

		/// <summary>
		/// Constructor privado para no permitir crear mas instancias que las necesarias
		/// </summary>
        private ReceptorMensajesGlobal()
		{
		}

		/// <summary>
		/// Devuelve la instancia de la clase
		/// </summary>
        public static ReceptorMensajesGlobal ObtenerInstancia()
		{
			if (instancia == null)
			{
                instancia = new ReceptorMensajesGlobal();
			}
			return instancia;
		}
		#endregion

        private ISyncReceptorMensajes m_receptor;

        public ISyncReceptorMensajes Receptor
		{
            set { m_receptor = value; }
		}

        public XElement ObtenerNuevoMensajeSync(MessageId msgId, IdTerminalVirtual termId)
        {
            return m_receptor.ObtenerNuevoMensajeSync(msgId, termId);
        }
    }
}
