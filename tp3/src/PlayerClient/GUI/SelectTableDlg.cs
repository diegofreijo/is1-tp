using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CasinoOnline.PlayerClient.GUI
{
    using IdMesa = Int32;

    public partial class SelectTableDlg : Form
    {
        const string newTableString = "<New Table>";
        private int m_selectedId;

        public SelectTableDlg()
        {
            InitializeComponent();
        }

        public void FinishConstruction(ModoUsuario modo, List<IdMesa> idMesas)
        {
            if (modo == ModoUsuario.eJugador)
                m_tablesComboBox.Items.Add(newTableString);

            foreach (IdMesa mesaId in idMesas)
            {
                m_tablesComboBox.Items.Add(mesaId.ToString());
            }

            m_tablesComboBox.SelectedItem = m_tablesComboBox.Items[0];
        }

        public int GetSelectedId()
        {
            return m_selectedId;
        }

        private void m_OKButton_Click(object sender, EventArgs e)
        {
            string selection = m_tablesComboBox.SelectedItem.ToString();
            m_selectedId = selection == newTableString ? -1 : int.Parse(selection);
        }
    }
}
