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
    public partial class LobbyDlg : Form
    {
        private Session m_session;

        public LobbyDlg(ref Session session)
        {
            InitializeComponent();
            m_session = session;

            // nombre del jugador/observador en barra de título
            this.Text += " <";
            this.Text += m_session.Modo == ModoUsuario.eJugador ? "Jugador" : "Observador";
            this.Text += ": ";
            this.Text += m_session.Nombre;
            this.Text += ">";

            if (m_session.Modo == ModoUsuario.eObservador)
                PlayCrapsButton.Text = "View Craps";
        }

        private void m_logoutButton_Click(object sender, EventArgs e)
        {
            XElement res = AccesoYVistaCasino.ObtenerInstancia().SalirCasino(m_session.Nombre);

            if (String.Compare(res.Element("aceptado").Value, "no", true) == 0)
            {
                MessageBox.Show(this, res.Element("descripcion").Value, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Close();
        }

        private void PlayCrapsButton_Click(object sender, EventArgs e)
        {
            // pedimos el estado del casino para obtener los ids de mesas disponibles
            XElement estadoCasino = AccesoYVistaCasino.ObtenerInstancia().PedirEstadoCasino(m_session.Nombre);

            IEnumerable<XElement> mesasCraps = estadoCasino.Element("juegos").Element("craps").Element("mesasCraps").Elements("mesaCraps");
            List<int> idsMesasCraps = new List<int>();
            foreach (XElement mesaCraps in mesasCraps)
            {
                idsMesasCraps.Add(int.Parse(mesaCraps.Attribute("id").Value));
            }

            if (m_session.Modo == ModoUsuario.eObservador && idsMesasCraps.Count == 0)
            {
                MessageBox.Show(this, "No hay mesas de craps disponibles para observar en este momento", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            SelectTableDlg selectTableIdDlg = new SelectTableDlg();
            selectTableIdDlg.FinishConstruction(m_session.Modo, idsMesasCraps);
            if (selectTableIdDlg.ShowDialog() == DialogResult.OK)
            {
                CrapsDlg crapsDlg;
                if (m_session.Modo == ModoUsuario.eJugador)
                {
                    XElement res = AccesoYVistaCraps.ObtenerInstancia().EntrarCraps(m_session.Nombre, selectTableIdDlg.GetSelectedId());

                    if (String.Compare(res.Element("aceptado").Value, "no", true) == 0)
                    {
                        MessageBox.Show(this, res.Element("descripcion").Value, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    crapsDlg = new CrapsDlg(ref m_session, int.Parse(res.Attribute("mesa").Value));
                }
                else
                {
                    crapsDlg = new CrapsDlg(ref m_session, selectTableIdDlg.GetSelectedId());
                }

                // escondemos esta ventana para que no moleste
                this.Visible = false;

                crapsDlg.ShowDialog(this);

                // mostramos nuevamente la ventana
                this.Visible = true;
            }
        }
    }
}
