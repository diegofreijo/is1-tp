using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace CasinoOnline.AdminClient.Comunication
{
    using MessageId = String;
    using IdTerminalVirtual = Int32;

    interface ISyncReceptorMensajes
    {
        XElement ObtenerNuevoMensajeSync(MessageId msgId, IdTerminalVirtual termId);
    }
}
