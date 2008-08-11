using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CasinoOnline.AdminClient
{
    enum ValorDado { Uno, Dos, Tres, Cuatro, Cinco, Seis };
    enum TipoJugada { eAzar, eNormal, eTodosPonen, eNoTodosPonen, eNoFeliz };
    enum ModoUsuario { eJugador, eObservador }

    class ResultadoCraps
    {
        private ValorDado m_dado1;
        private ValorDado m_dado2;

        public ResultadoCraps(ValorDado dado1, ValorDado dado2)
        {
            m_dado1 = dado1;
            m_dado2 = dado2;
        }

        public ValorDado Dado1
        {
            set { m_dado1 = value; }
            get { return m_dado1; }
        }

        public ValorDado Dado2
        {
            set { m_dado2 = value; }
            get { return m_dado2; }
        }
    }
}
