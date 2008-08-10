using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CasinoOnline.AdminClient.GUI
{
    public partial class EnterPasswordDlg : Form
    {
        private string m_password;

        public EnterPasswordDlg()
        {
            InitializeComponent();
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            m_password = PasswordTextBox.Text;
        }

        public string GetPassword()
        {
            return m_password;
        }
    }
}
