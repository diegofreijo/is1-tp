using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace CasinoOnline.PlayerClient.GUI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                MessageBox.Show("Debe especificarse el IdTerminalVirtual como parámetro", "Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }

            // Inicializo el id de la terminal
            Comunication.TerminalInfo.ObtenerInstancia().Id = int.Parse(args[0]);

            // Inicializo el despachador de respuestas
            Comunication.DespachadorPedidosGlobal.ObtenerInstancia().Despachador = new Comunication.DespachadorPedidosArchivo();

            // Inicializo el receptor de mensajes
            Comunication.ReceptorMensajesGlobal.ObtenerInstancia().Receptor = new Comunication.ReceptorMensajesArchivo();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new SignInDlg());
        }
    }
}
