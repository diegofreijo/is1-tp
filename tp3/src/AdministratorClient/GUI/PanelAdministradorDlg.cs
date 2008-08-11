using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;
using CasinoOnline.AdminClient.Comunication.Ports;

namespace CasinoOnline.AdminClient.GUI
{
    public partial class PanelAdministrador : Form
    {
        public PanelAdministrador()
        {
            InitializeComponent();
        }

        private void ControlCrapsButton_Click(object sender, EventArgs e)
        {
            CrapsCfgDlg crapsCfgDlg = new CrapsCfgDlg();
            crapsCfgDlg.ShowDialog();
        }

        private void ControlJugadaFelizButton_Click(object sender, EventArgs e)
        {
            HappyMoveCfgDlg happyMoveCfgDlg = new HappyMoveCfgDlg();
            if (happyMoveCfgDlg.FinishConstruction() == false)
            {
                MessageBox.Show(this, "En este momento no hay mesas disponibles, inténtelo nuevamente en un ratito.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            happyMoveCfgDlg.ShowDialog();
        }

        private void QueryEstadoActualButton_Click(object sender, EventArgs e)
        {
            EnterPasswordDlg passwordDlg = new EnterPasswordDlg();
            if (passwordDlg.ShowDialog() != DialogResult.OK)
                return;

            XElement res = AccesoYManejoAdministrador.ObtenerInstancia().PedirReporteEstadoActual(passwordDlg.GetPassword());

            if (String.Compare(res.Attribute("aceptado").Value, "no", true) == 0)
            {
                MessageBox.Show(this, "Password incorrecto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ReportDlg reportDlg = new ReportDlg(res.ToString());
            reportDlg.Show();
        }

        private void QueryRankingDeJugadoresButton_Click(object sender, EventArgs e)
        {
            EnterPasswordDlg passwordDlg = new EnterPasswordDlg();
            if (passwordDlg.ShowDialog() != DialogResult.OK)
                return;

            XElement res = AccesoYManejoAdministrador.ObtenerInstancia().PedirReporteRankingDeJugadores(passwordDlg.GetPassword());

            if (String.Compare(res.Attribute("aceptado").Value, "no", true) == 0)
            {
                MessageBox.Show(this, "Password incorrecto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ReportDlg reportDlg = new ReportDlg(res.ToString());
            reportDlg.Show();
        }

        private void QueryDetallesMovimientosButton_Click(object sender, EventArgs e)
        {
            EnterPasswordDlg passwordDlg = new EnterPasswordDlg();
            if (passwordDlg.ShowDialog() != DialogResult.OK)
                return;

            XElement res = AccesoYManejoAdministrador.ObtenerInstancia().PedirReporteMovimientos(passwordDlg.GetPassword());

            if (String.Compare(res.Attribute("aceptado").Value, "no", true) == 0)
            {
                MessageBox.Show(this, "Password incorrecto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ReportDlg reportDlg = new ReportDlg(res.ToString());
            reportDlg.Show();
        }

        private void m_ExitButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
