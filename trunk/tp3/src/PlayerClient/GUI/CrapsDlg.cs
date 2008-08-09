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
    using IdMesa = Int32;
    using ValorFicha = Decimal;

    public partial class CrapsDlg : Form
    {
        private Session m_session;
        private IdMesa m_idMesa;
        private Dictionary<ValorFicha, int> m_fichasEnMano;

        private System.Windows.Forms.Timer m_timer;

        public CrapsDlg(ref Session session, int idMesa)
        {
            InitializeComponent();
            m_session = session;
            m_idMesa = idMesa;

            InitGUI();

            // inicializo el timer para polleo
            m_timer = new System.Windows.Forms.Timer();
            m_timer.Tick += new EventHandler(OnTimer);
            m_timer.Interval = 1000;
            m_timer.Start();
        }

        private void OnTimer(object sender, EventArgs e)
        {
            XElement estadoCraps = new XElement("tmp");
            if (AccesoYVistaCraps.ObtenerInstancia().EstadoCraps(ref estadoCraps) == true)
            {
                UpdateGUI(ref estadoCraps);
            }
        }

        private void OnFormClosing(object sender, FormClosingEventArgs e)
        {
            m_timer.Stop();
        }

        private void InitGUI()
        {
            m_historyTextBox.Text = "";

            XElement estadoCasino = AccesoYVistaCasino.ObtenerInstancia().PedirEstadoCasino(m_session.Nombre);

            foreach (ValorFicha ficha in m_session.Fichas)
                m_coinsComboBox.Items.Add("€" + ficha.ToString());

            m_coinsComboBox.SelectedItem = m_coinsComboBox.Items[0];

            m_fichasEnMano = new Dictionary<ValorFicha, int>();
            DropAllCoinsInHand();
        }

        private void UpdateGUI(ref XElement estadoCraps)
        {
            // actualizar la lista de jugadores
            {
                m_jugadoresEnLaMesaTextBox.Text = "";
                IEnumerable<XElement> jugadores = estadoCraps.Element("jugadores").Elements("jugador");
                foreach (XElement jugador in jugadores)
                {
                    m_jugadoresEnLaMesaTextBox.Text += jugador.Value;
                    m_jugadoresEnLaMesaTextBox.Text += Environment.NewLine;
                }
            }

            // actualizar información de próximo tiro
            {
                XElement proximoTiro = estadoCraps.Element("proximoTiro");
                bool esTiroDeSalida = String.Compare(proximoTiro.Element("tiroSalida").Value, "si", true) == 0;
                m_rondaTiradorTextBox.Text = proximoTiro.Element("tirador").Value;
                m_rondaTiroTextBox.Text = esTiroDeSalida ? "Salida" : "Punto";
                m_rondaPuntoTextBox.Text = esTiroDeSalida ? "-" : proximoTiro.Element("punto").Value;
            }

            // actualizar información de último tiro
            {
                XElement ultimoTiro = estadoCraps.Element("ultimoTiro");
                if (!ultimoTiro.IsEmpty)
                {
                    m_lastResultTiradorTextBox.Text = ultimoTiro.Element("tirador").Value;
                    XElement resultado = ultimoTiro.Element("resultado");
                    string dado1 = resultado.Element("dado1").Value;
                    string dado2 = resultado.Element("dado2").Value;
                    m_lastResultDado1TextBox.Text = dado1;
                    m_lastResultDado2TextBox.Text = dado2;
                    m_historyTextBox.Text = "<" + dado1 + "," + dado2 + "> " + m_historyTextBox.Text;
                    IEnumerable<XElement> todosLosPremios = ultimoTiro.Element("premios").Elements("premio");
                    try
                    {
                        XElement premios = todosLosPremios.Single(delegate(XElement elem) { return elem.Element("apostador").Value == m_session.Nombre; });
                        string normalPaid = premios.Element("montoPremioJugada").Value;
                        string happyBonusPaid = premios.Element("montoPremioJugadaFeliz").Value;
                        string todosPonenReduction = premios.Element("montoRetenidoJugadaTodosponen").Value;
                        m_normalPaidTextBox.Text = "€" + normalPaid;
                        m_happyBonusTextBox.Text = "€" + happyBonusPaid;
                        m_todosPonenReductionTextBox.Text = "€" + todosPonenReduction;
                        m_session.Saldo += decimal.Parse(normalPaid);
                        m_session.Saldo += decimal.Parse(happyBonusPaid);
                        m_session.Saldo -= decimal.Parse(todosPonenReduction);
                        RefreshSaldo();
                    }
                    catch (Exception)
                    {
                    }
                }
            }

            // actualizar información de apuestas
            {
                IEnumerable<XElement> apuestasVigentes = estadoCraps.Element("apuestasVigentes").Elements("apuesta");

                m_LineaDePaseTextBox.Text = "";
                m_BarraNoPaseTextBox.Text = "";
                m_VenirTextBox.Text = "";
                m_NoVenirTextBox.Text = "";
                m_CampoTextBox.Text = "";
                m_AGanarTextBox.Text = "";
                m_EnContraTextBox.Text = "";

                foreach (XElement apuesta in apuestasVigentes)
                {
                    /*m_LineaDePaseTextBox.Text += apuesta.Element("apostador").Value;
                    m_LineaDePaseTextBox.Text += Environment.NewLine;*/
                }
            }
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            XElement res = AccesoYVistaCraps.ObtenerInstancia().SalirCraps(m_session.Nombre, m_idMesa);

            if (String.Compare(res.Element("aceptado").Value, "no", true) == 0)
            {
                MessageBox.Show(this, res.Element("descripcion").Value, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Close();
        }

        private void m_RollButton_Click(object sender, EventArgs e)
        {
            XElement res = JuegoCraps.ObtenerInstancia().TirarCraps(m_session.Nombre, m_idMesa);

            if (String.Compare(res.Element("aceptado").Value, "no", true) == 0)
            {
                MessageBox.Show(this, res.Element("descripcion").Value, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        void RefreshSaldo()
        {
            m_cashTextBox.Text = "€" + m_session.Saldo.ToString();
        }

        #region CoinsInHandRelated

        private void m_pickButton_Click(object sender, EventArgs e)
        {
            ValorFicha ficha = ValorFicha.Parse(m_coinsComboBox.SelectedItem.ToString().Substring(1));
            m_fichasEnMano[ficha] = m_fichasEnMano[ficha] + 1;
            RefreshCoinsInHand();
        }

        private void m_dropAllButton_Click(object sender, EventArgs e)
        {
            DropAllCoinsInHand();
        }

        private void DropAllCoinsInHand()
        {
            foreach (ValorFicha ficha in m_session.Fichas)
                m_fichasEnMano[ficha] = 0;

            RefreshCoinsInHand();
        }

        private void RefreshCoinsInHand()
        {
            m_moneyInYourHandTextBox.Text = "";
            foreach (KeyValuePair<ValorFicha, int> elem in m_fichasEnMano)
            {
                if (elem.Value == 0)
                    continue;
                m_moneyInYourHandTextBox.Text += "<Ficha: €";
                m_moneyInYourHandTextBox.Text += elem.Key;
                m_moneyInYourHandTextBox.Text += " Cantidad: ";
                m_moneyInYourHandTextBox.Text += elem.Value;
                m_moneyInYourHandTextBox.Text += "> ";
            }
        }

        #endregion // CoinsInHandRelated

        #region BetButtons

        private void m_LineaDePaseBetButton_Click(object sender, EventArgs e)
        {
            Apostar(TipoApuestaCraps.eLineaDePase, new PuntoEnSitioCraps());
        }

        private void m_BarraNoPaseBetButton_Click(object sender, EventArgs e)
        {
            Apostar(TipoApuestaCraps.eBarraNoPase, new PuntoEnSitioCraps());
        }

        private void m_VenirBetButton_Click(object sender, EventArgs e)
        {
            Apostar(TipoApuestaCraps.eVenir, new PuntoEnSitioCraps());
        }

        private void m_NoVenirBetButton_Click(object sender, EventArgs e)
        {
            Apostar(TipoApuestaCraps.eNoVenir, new PuntoEnSitioCraps());
        }

        private void m_CampoBetButton_Click(object sender, EventArgs e)
        {
            Apostar(TipoApuestaCraps.eDeCampo, new PuntoEnSitioCraps());
        }

        private void m_EnSitioAGanar4BetButton_Click(object sender, EventArgs e)
        {
            Apostar(TipoApuestaCraps.eEnSitioAGanar, PuntoEnSitioCraps.e4);
        }

        private void m_EnSitioAGanar5BetButton_Click(object sender, EventArgs e)
        {
            Apostar(TipoApuestaCraps.eEnSitioAGanar, PuntoEnSitioCraps.e5);
        }

        private void m_EnSitioAGanar6BetButton_Click(object sender, EventArgs e)
        {
            Apostar(TipoApuestaCraps.eEnSitioAGanar, PuntoEnSitioCraps.eSEIS);
        }

        private void m_EnSitioAGanar8BetButton_Click(object sender, EventArgs e)
        {
            Apostar(TipoApuestaCraps.eEnSitioAGanar, PuntoEnSitioCraps.e8);
        }

        private void m_EnSitioAGanar9BetButton_Click(object sender, EventArgs e)
        {
            Apostar(TipoApuestaCraps.eEnSitioAGanar, PuntoEnSitioCraps.eNUEVE);
        }

        private void m_EnSitioAGanarXBetButton_Click(object sender, EventArgs e)
        {
            Apostar(TipoApuestaCraps.eEnSitioAGanar, PuntoEnSitioCraps.e10);
        }

        private void m_EnSitioEnContra4BetButton_Click(object sender, EventArgs e)
        {
            Apostar(TipoApuestaCraps.eEnSitioEnContra, PuntoEnSitioCraps.e4);
        }

        private void m_EnSitioEnContra5BetButton_Click(object sender, EventArgs e)
        {
            Apostar(TipoApuestaCraps.eEnSitioEnContra, PuntoEnSitioCraps.e5);
        }

        private void m_EnSitioEnContra6BetButton_Click(object sender, EventArgs e)
        {
            Apostar(TipoApuestaCraps.eEnSitioEnContra, PuntoEnSitioCraps.eSEIS);
        }

        private void m_EnSitioEnContra8BetButton_Click(object sender, EventArgs e)
        {
            Apostar(TipoApuestaCraps.eEnSitioEnContra, PuntoEnSitioCraps.e8);
        }

        private void m_EnSitioEnContra9BetButton_Click(object sender, EventArgs e)
        {
            Apostar(TipoApuestaCraps.eEnSitioEnContra, PuntoEnSitioCraps.eNUEVE);
        }

        private void m_EnSitioEnContraXBetButton_Click(object sender, EventArgs e)
        {
            Apostar(TipoApuestaCraps.eEnSitioEnContra, PuntoEnSitioCraps.e10);
        }

        void Apostar(TipoApuestaCraps tipo, PuntoEnSitioCraps punto)
        {
            XElement res = JuegoCraps.ObtenerInstancia().ApostarCraps(
                m_session.Nombre,
                m_idMesa,
                m_fichasEnMano.ToList(),
                tipo,
                punto
            );

            if (String.Compare(res.Element("aceptado").Value, "no", true) == 0)
            {
                MessageBox.Show(this, res.Element("descripcion").Value, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                ActualizarSaldo();
            }
        }

        void ActualizarSaldo()
        {
            foreach (KeyValuePair<ValorFicha, int> elem in m_fichasEnMano)
                m_session.Saldo -= elem.Key * elem.Value;

            RefreshSaldo();
            DropAllCoinsInHand();
        }

        #endregion // BetButtons
    }
}
