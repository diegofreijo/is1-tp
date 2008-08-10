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
    public partial class ReportDlg : Form
    {
        public ReportDlg(string text)
        {
            InitializeComponent();
            ReporteRichTextBox.Text = text;
        }

        private void m_OKButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
