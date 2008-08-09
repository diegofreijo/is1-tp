using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;
using CasinoOnline.PlayerClient.Comunication.Ports;

namespace CasinoOnline.PlayerClient.GUI
{
    using Creditos = Decimal;
    using ValorFicha = Decimal;

    public partial class SignInDlg : Form
    {
        public SignInDlg()
        {
            InitializeComponent();
        }

        private void SignInButton_Click(object sender, EventArgs e)
        {
            String nombre;
            ModoUsuario modo;
            if (m_joinAsGuestRadioButton.Checked)
            {
                nombre = m_guestName.Text;
                modo = ModoUsuario.eObservador;
            }
            else // join as member
            {
                nombre = m_userName.Text;
                modo = ModoUsuario.eJugador;
            }

            XElement res = AccesoYVistaCasino.ObtenerInstancia().EntrarCasino(nombre,modo);

            if (String.Compare(res.Element("aceptado").Value, "no", true) == 0)
            {
                MessageBox.Show(this, res.Element("descripcion").Value, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Creditos saldo = Creditos.Parse(res.Element("saldo").Value);

            IEnumerable<XElement> fichasHabilitadas = res.Element("fichasHabilitadas").Elements("valorFicha");
            List<ValorFicha> fichas = new List<ValorFicha>();
            foreach (XElement valorFicha in fichasHabilitadas)
                fichas.Add(decimal.Parse(valorFicha.Value));

            Session session = new Session(nombre, modo, saldo, fichas);

            LobbyDlg dlg = new LobbyDlg(ref session);
            dlg.ShowDialog(this);
        }

        private void QuitButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
