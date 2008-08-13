using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;
using CasinoOnline.PlayerClient.Utils;
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
            UpdateControls();
            this.ActiveControl = m_playerName;
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
                nombre = m_playerName.Text;
                modo = ModoUsuario.eJugador;
            }

            XElement res = AccesoYVistaCasino.ObtenerInstancia().EntrarCasino(nombre,modo);
            KeyValuePair<bool, string> val = Helpers.ValidateAndLogResponse(ref res);
            if (!val.Key)
            {
                MessageBox.Show(this, val.Value, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);                
                return;
            }

            // actualizamos la barra de título de la consola
            if (Program.bShowConsole)
                Console.Title += (" - " + nombre);

            Creditos? saldo = null;
            if (modo == ModoUsuario.eJugador)
                saldo = Creditos.Parse(res.Element("saldo").Value);

            IEnumerable<XElement> fichasHabilitadas = res.Element("fichasHabilitadas").Elements("valorFicha");
            List<ValorFicha> fichas = new List<ValorFicha>();
            foreach (XElement valorFicha in fichasHabilitadas)
                fichas.Add(decimal.Parse(valorFicha.Value));

            Session session = new Session(nombre, modo, saldo, fichas);

            // escondemos esta ventana para que no moleste
            this.Visible = false;

            // damos el control al lobby
            LobbyDlg dlg = new LobbyDlg(ref session);
            dlg.ShowDialog(this);

            // mostramos nuevamente la ventana
            this.Visible = true;

            // actualizamos la barra de título de la consola
            if (Program.bShowConsole)
                Console.Title = "CasinoOnline - PlayerClient Log - Grupo 05";
        }

        private void QuitButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void m_joinAsMemberRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            UpdateControls();
            this.ActiveControl = m_playerName;
        }

        private void m_joinAsGuestRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            UpdateControls();
            this.ActiveControl = m_guestName;
        }

        private void UpdateControls()
        {
            m_playerName.Enabled = m_joinAsMemberRadioButton.Checked;
            m_guestName.Enabled = m_joinAsGuestRadioButton.Checked;
        }
    }
}
