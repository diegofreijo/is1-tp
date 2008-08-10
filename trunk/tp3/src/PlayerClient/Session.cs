using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CasinoOnline.PlayerClient
{
    using Nombre = String;
    using Creditos = Decimal;
    using ValorFicha = Decimal;
    
    public enum ModoUsuario { eJugador, eObservador }

    public class Session
    {
        private Nombre m_nombreUsuario;
        private ModoUsuario m_modo;
        private Creditos? m_saldo;
        private List<ValorFicha> m_fichasHabilitadas;

        public Session(Nombre nombreUsuario, ModoUsuario modo, Creditos? saldo, List<ValorFicha> fichasHabilitadas)
        {
            m_nombreUsuario = nombreUsuario;
            m_modo = modo;
            m_saldo = saldo;
            m_fichasHabilitadas = fichasHabilitadas;
        }

        public Nombre Nombre
        {
            set { m_nombreUsuario = value; }
            get { return m_nombreUsuario; }
        }

        public ModoUsuario Modo
        {
            set { m_modo = value; }
            get { return m_modo; }
        }

        public Creditos? Saldo
        {
            set { m_saldo = value; }
            get { return m_saldo; }
        }

        public List<ValorFicha> Fichas
        {
            set { m_fichasHabilitadas = value; }
            get { return m_fichasHabilitadas; }
        }
    }
}
