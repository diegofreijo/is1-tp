using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace CasinoOnline.PlayerClient.Comunication
{
    using MessageId = String;
    using IdTerminalVirtual = Int32;

    interface IReceptorMensajes
    {
        bool ObtenerNuevoMensajeAsync(MessageId msgId, IdTerminalVirtual termId, ref XElement xml);
        XElement ObtenerNuevoMensajeSync(MessageId msgId, IdTerminalVirtual termId);
    }
}
