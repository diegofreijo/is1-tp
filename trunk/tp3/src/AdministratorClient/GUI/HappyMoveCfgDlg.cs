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
    public partial class HappyMoveCfgDlg : Form
    {
        public HappyMoveCfgDlg()
        {
            InitializeComponent();
        }

        public bool FinishConstruction()
        {
            bool succeded = false;

            int i = 0;
            string loginName = "";
            /* para poder pedir el estado del casino nos logueamos por un ratito 
               como un usuario con un nombre random hasta que nos dan el ok (puaj!) */
            while (!succeded)
            {
                loginName = i.ToString();
                XElement res = AccesoYVistaCasino.ObtenerInstancia().EntrarCasino(loginName, ModoUsuario.eObservador);
                if (String.Compare(res.Element("aceptado").Value, "no", true) == 0)
                    i++;
                else
                    succeded = true;
            }

            // pedimos el estado del casino para obtener los ids de mesas disponibles
            XElement estadoCasino = AccesoYVistaCasino.ObtenerInstancia().PedirEstadoCasino(loginName);

            // logout para no dejear lockeado el nombre de observador
            XElement respuestaSalida = AccesoYVistaCasino.ObtenerInstancia().SalirCasino(loginName);
            if (String.Compare(respuestaSalida.Element("aceptado").Value, "no", true) == 0)
            {
                // feliz navidad, queda lockeado forever :P
                // esperemos que no pase...
            }

            // obtenemos las mesas de craps
            IEnumerable<XElement> mesasCraps = estadoCasino.Element("juegos").Element("craps").Element("mesasCraps").Elements("mesaCraps");
            foreach (XElement mesaCraps in mesasCraps)
                MesaCrapsComboBox.Items.Add(int.Parse(mesaCraps.Attribute("id").Value));

            if (MesaCrapsComboBox.Items.Count != 0)
                MesaCrapsComboBox.SelectedItem = MesaCrapsComboBox.Items[0];
            else
                return false;

            return true;                
        }

        private void SetNewConfig()
        {
            EnterPasswordDlg passwordDlg = new EnterPasswordDlg();
            if (passwordDlg.ShowDialog() != DialogResult.OK)
                return;

            int idMesa = (int)MesaCrapsComboBox.SelectedItem;

            XElement res = AccesoYManejoAdministrador.ObtenerInstancia().ConfigurarModoDirigidoJugadaFeliz(passwordDlg.GetPassword(), idMesa);

            if (String.Compare(res.Attribute("aceptado").Value, "no", true) == 0)
            {
                MessageBox.Show(this, res.Element("descripcion").Value, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void m_OKButton_Click(object sender, EventArgs e)
        {
            SetNewConfig();
            Close();
        }

        private void m_ApplyButton_Click(object sender, EventArgs e)
        {
            SetNewConfig();
        }

        private void m_CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
