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
    public partial class CrapsCfgDlg : Form
    {
        public CrapsCfgDlg()
        {
            InitializeComponent();

            Dado1ComboBox.Items.Add(ValorDado.Uno);
            Dado1ComboBox.Items.Add(ValorDado.Dos);
            Dado1ComboBox.Items.Add(ValorDado.Tres);
            Dado1ComboBox.Items.Add(ValorDado.Cuatro);
            Dado1ComboBox.Items.Add(ValorDado.Cinco);
            Dado1ComboBox.Items.Add(ValorDado.Seis);
            Dado1ComboBox.SelectedItem = Dado1ComboBox.Items[0];

            Dado2ComboBox.Items.Add(ValorDado.Uno);
            Dado2ComboBox.Items.Add(ValorDado.Dos);
            Dado2ComboBox.Items.Add(ValorDado.Tres);
            Dado2ComboBox.Items.Add(ValorDado.Cuatro);
            Dado2ComboBox.Items.Add(ValorDado.Cinco);
            Dado2ComboBox.Items.Add(ValorDado.Seis);
            Dado2ComboBox.SelectedItem = Dado2ComboBox.Items[0];
        }

        private void SetNewConfig()
        {
            EnterPasswordDlg passwordDlg = new EnterPasswordDlg();
            if (passwordDlg.ShowDialog() != DialogResult.OK)
                return;

            ResultadoCraps resultadoCraps = null;
            TipoJugada? tipoJugada = null;

            if (m_ControlarResultadoCheckBox.Checked)
            {
                resultadoCraps = new ResultadoCraps((ValorDado)Dado1ComboBox.SelectedItem, (ValorDado)Dado2ComboBox.SelectedItem);                
            }

            if (m_ControlarTipoJugadaCheckBox.Checked)
            {
                if (m_NormalRadioButton.Checked)
                    tipoJugada = TipoJugada.eNormal;
                else if (m_TodosPonenRadioButton.Checked)
                    tipoJugada = TipoJugada.eTodosPonen;
                else if (m_NoTodosPonenRadioButton.Checked)
                    tipoJugada = TipoJugada.eNoTodosPonen;
                else if (m_NoFelizRadioButton.Checked)
                    tipoJugada = TipoJugada.eNoFeliz;
            }

            XElement res = AccesoYManejoAdministrador.ObtenerInstancia().ConfigurarModoDirigidoCraps(passwordDlg.GetPassword(), resultadoCraps, tipoJugada);

            if (String.Compare(res.Attribute("aceptado").Value, "no", true) == 0)
            {
                MessageBox.Show(this, res.Element("descripcion").Value, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void m_ApplyButton_Click(object sender, EventArgs e)
        {
            SetNewConfig();
        }

        private void m_OKButton_Click(object sender, EventArgs e)
        {
            SetNewConfig();
            Close();
        }
    }
}
