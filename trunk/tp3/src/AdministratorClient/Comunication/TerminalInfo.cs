using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CasinoOnline.AdminClient.Comunication
{
    public class TerminalInfo
    {
        #region Singleton
		/// <summary>
		/// La instancia de la clase
		/// </summary>
		private static TerminalInfo instancia = null;

		/// <summary>
		/// Constructor privado para no permitir crear mas instancias que las necesarias
		/// </summary>
        private TerminalInfo()
		{
		}

		/// <summary>
		/// Devuelve la instancia de la clase
		/// </summary>
        public static TerminalInfo ObtenerInstancia()
		{
			if (instancia == null)
			{
                instancia = new TerminalInfo();
			}
			return instancia;
		}
		#endregion

        private Int32 m_id;

        public Int32 Id
        {
            get { return m_id; }
            set { m_id = value; }
        }

        void EstablecerId(Int32 id)
        {
            m_id = id;
        }

        Int32 ObtenerId()
        {
            return m_id;
        }
    }
}
