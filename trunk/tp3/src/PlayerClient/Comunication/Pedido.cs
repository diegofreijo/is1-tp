using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace CasinoOnline.PlayerClient.Comunication
{
    using MessageId = String;
    using IdTerminalVirtual = Int32;

    public class Pedido
    {
        private XElement m_parametros = null;
        private MessageId m_tipo = "";
        private IdTerminalVirtual m_idTerminalVirtual = 0;

        /// <summary>
        /// Informacion detallada del pedido
        /// </summary>
        public XElement Parametros
        {
            get { return m_parametros; }
            set { m_parametros = value; }
        }

        /// <summary>
        /// Tipo de pedido
        /// </summary>
        public MessageId Tipo
        {
            get { return m_tipo; }
            set { m_tipo = value; }
        }

        /// <summary>
        /// Id de terminal virtual que envía el pedido
        /// </summary>
        public IdTerminalVirtual TermId
        {
            get { return m_idTerminalVirtual; }
            set { m_idTerminalVirtual = value; }
        }

        /// <summary>
        /// Constructor completo
        /// </summary>
        public Pedido(XElement parametros, MessageId tipo, IdTerminalVirtual termId)
        {
            this.m_parametros = parametros;
            this.m_tipo = tipo;
            this.m_idTerminalVirtual = termId;
        }


        /// <summary>
        /// Muestra al pedido en forma bonita
        /// </summary>
        public override string ToString()
        {
            string ret;

            // Muestro el tipo
            ret = this.Tipo + " - Term: " + this.m_idTerminalVirtual + " - " + this.m_parametros.ToString();

            return ret;
        }
    }
}
