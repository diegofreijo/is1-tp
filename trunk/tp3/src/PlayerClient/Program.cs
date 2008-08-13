using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Runtime.InteropServices;
using CasinoOnline.PlayerClient.Utils;

namespace CasinoOnline.PlayerClient.GUI
{
    static class Program
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool AllocConsole();

        static public bool bShowConsole = false;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            // obtenemos el número de terminal virtual (obligatorio, sino quiteamos)
            int terminalId;
            try
            {
                terminalId = int.Parse(args.Single(a => a.Substring(0, 3) == "id=").Substring(3));
            }
            catch(Exception)
            {
                MessageBox.Show("Debe especificarse el IdTerminalVirtual como parámetro", "Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }

            // mostramos la consola de log?
            bShowConsole = args.Any(a => a == "-console");

            if (bShowConsole)
            {
                AllocConsole();
                Console.Title = "CasinoOnline - PlayerClient Log - Grupo 05";
            }

            Log.Mensaje("Inicializando cliente...");
            
            // Inicializo el id de la terminal
            Comunication.TerminalInfo.ObtenerInstancia().Id = terminalId;

            // Inicializo el despachador de respuestas
            Comunication.DespachadorPedidosGlobal.ObtenerInstancia().Despachador = new Comunication.DespachadorPedidosArchivo();

            // Inicializo el receptor de mensajes
            Comunication.ReceptorMensajesGlobal.ObtenerInstancia().Receptor = new Comunication.ReceptorMensajesArchivo();

            Log.Mensaje("Cliente de inicializado!" + Environment.NewLine +
            "=============================================");

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new SignInDlg());

            if (bShowConsole)
            {
                Log.Mensaje("Client finalizado, aprete ENTER para cerrar");
                Console.ReadLine();
            }
        }
    }
}
