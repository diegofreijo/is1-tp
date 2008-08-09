﻿using System;
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

        private System.Windows.Forms.Timer m_updateCrapsStateTimer;
        private System.Windows.Forms.Timer m_updatePozoFelizTimer;

        public CrapsDlg(ref Session session, int idMesa)
        {
            InitializeComponent();
            m_session = session;
            m_idMesa = idMesa;

            InitGUI();

            // inicializo el timer para polleo del estado craps
            m_updateCrapsStateTimer = new System.Windows.Forms.Timer();
            m_updateCrapsStateTimer.Tick += new EventHandler(OnUpdateCrapsStateTimer);
            m_updateCrapsStateTimer.Interval = 1000;
            m_updateCrapsStateTimer.Start();

            // inicializo el timer para la actualización del pozo feliz
            m_updatePozoFelizTimer = new System.Windows.Forms.Timer();
            m_updatePozoFelizTimer.Tick += new EventHandler(OnUpdatePozoFelizTimer);
            m_updatePozoFelizTimer.Interval = 5000;
            m_updatePozoFelizTimer.Start();
        }

        private void OnUpdateCrapsStateTimer(object sender, EventArgs e)
        {
            XElement estadoCraps = new XElement("tmp");
            if (AccesoYVistaCraps.ObtenerInstancia().EstadoCraps(ref estadoCraps) == true)
            {
                UpdateGUI(ref estadoCraps);
            }
        }

        private void OnUpdatePozoFelizTimer(object sender, EventArgs e)
        {
            UpdatePozoFeliz();
        }        

        private void OnFormClosing(object sender, FormClosingEventArgs e)
        {
            m_updateCrapsStateTimer.Stop();
            m_updatePozoFelizTimer.Stop();
        }

        private void InitGUI()
        {
            this.Text += " <Jugador: ";
            this.Text += m_session.Nombre;
            this.Text += ">";

            XElement estadoCasino = AccesoYVistaCasino.ObtenerInstancia().PedirEstadoCasino(m_session.Nombre);
            XElement mesaCraps = estadoCasino.Element("juegos").Element("craps").Element("mesasCraps").Elements("mesaCraps").Single(delegate(XElement elem) { return int.Parse(elem.Attribute("id").Value) == m_idMesa; });

            SetBetButtonsState(false);
            RefreshSaldo();
            m_historyTextBox.Text = "";

            UpdateJugadoresEnMesa(mesaCraps.Element("jugadores"));
            UpdateProximoTiro(mesaCraps.Element("proximoTiro"));
            UpdateUltimoTiro(mesaCraps.Element("ultimoTiro"));

            m_normalPaidTextBox.Text = "€0";
            m_happyBonusTextBox.Text = "€0";
            m_todosPonenReductionTextBox.Text = "€0";

            // fichas disponibles
            foreach (ValorFicha ficha in m_session.Fichas)
                m_coinsComboBox.Items.Add("€" + ficha.ToString());
            m_coinsComboBox.SelectedItem = m_coinsComboBox.Items[0];

            // pozo feliz
            HappyPozoTextBox.Text = "€" + estadoCasino.Element("pozosCasino").Element("pozoFeliz").Value;

            // fichas en mano
            m_fichasEnMano = new Dictionary<ValorFicha, int>();
            DropAllCoinsInHand();
        }

        private void SetBetButtonsState(bool bEnable)
        {
            m_LineaDePaseBetButton.Enabled = bEnable;
            m_BarraNoPaseBetButton.Enabled = bEnable;
            m_VenirBetButton.Enabled = bEnable;
            m_NoVenirBetButton.Enabled = bEnable;
            m_CampoBetButton.Enabled = bEnable;
            m_EnSitioAGanar4BetButton.Enabled = bEnable;
            m_EnSitioAGanar5BetButton.Enabled = bEnable;
            m_EnSitioAGanar6BetButton.Enabled = bEnable;
            m_EnSitioAGanar8BetButton.Enabled = bEnable;
            m_EnSitioAGanar9BetButton.Enabled = bEnable;
            m_EnSitioAGanarXBetButton.Enabled = bEnable;
            m_EnSitioEnContra4BetButton.Enabled = bEnable;
            m_EnSitioEnContra5BetButton.Enabled = bEnable;
            m_EnSitioEnContra6BetButton.Enabled = bEnable;
            m_EnSitioEnContra8BetButton.Enabled = bEnable;
            m_EnSitioEnContra9BetButton.Enabled = bEnable;
            m_EnSitioEnContraXBetButton.Enabled = bEnable;
        }

        private void UpdateGUI(ref XElement estadoCraps)
        {
            // actualizar la lista de jugadores
            {
                UpdateJugadoresEnMesa(estadoCraps.Element("jugadores"));                
            }

            // actualizar información de próximo tiro
            {
                UpdateProximoTiro(estadoCraps.Element("proximoTiro"));
            }

            // actualizar información de último tiro
            {
                XElement ultimoTiro = estadoCraps.Element("ultimoTiro");
                UpdateUltimoTiro(ultimoTiro);
                
                if (!ultimoTiro.IsEmpty)
                {
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

                IEnumerable<XElement> apuestasLineaDePase = apuestasVigentes.Where(delegate(XElement elem) { return elem.Element("opcionApuesta").Element("tipoApuesta").Value == "pase"; });
                IEnumerable<XElement> apuestasBarraNoPase = apuestasVigentes.Where(delegate(XElement elem) { return elem.Element("opcionApuesta").Element("tipoApuesta").Value == "no pase"; });
                IEnumerable<XElement> apuestasVenir = apuestasVigentes.Where(delegate(XElement elem) { return elem.Element("opcionApuesta").Element("tipoApuesta").Value == "venir"; });
                IEnumerable<XElement> apuestasNoVenir = apuestasVigentes.Where(delegate(XElement elem) { return elem.Element("opcionApuesta").Element("tipoApuesta").Value == "no venir"; });
                IEnumerable<XElement> apuestasDeCampo = apuestasVigentes.Where(delegate(XElement elem) { return elem.Element("opcionApuesta").Element("tipoApuesta").Value == "campo"; });
                IEnumerable<XElement> apuestasEnSitioAGanar = apuestasVigentes.Where(delegate(XElement elem) { return elem.Element("opcionApuesta").Element("tipoApuesta").Value == "a ganar"; });
                IEnumerable<XElement> apuestasEnSitioEnContra = apuestasVigentes.Where(delegate(XElement elem) { return elem.Element("opcionApuesta").Element("tipoApuesta").Value == "en contra"; });

                UpdateApuestas(apuestasLineaDePase, ref m_LineaDePaseTextBox, false);
                UpdateApuestas(apuestasBarraNoPase, ref m_BarraNoPaseTextBox, false);
                UpdateApuestas(apuestasVenir, ref m_VenirTextBox, false);
                UpdateApuestas(apuestasNoVenir, ref m_NoVenirTextBox, false);
                UpdateApuestas(apuestasDeCampo, ref m_CampoTextBox, false);
                UpdateApuestas(apuestasEnSitioAGanar, ref m_AGanarTextBox, true);
                UpdateApuestas(apuestasEnSitioEnContra, ref m_EnContraTextBox, true);
            }
        }

        private void UpdateApuestas(IEnumerable<XElement> apuestas, ref TextBox box, bool bEnSitio)
        {
            box.Text = "";
            foreach (XElement apuesta in apuestas)
            {
                box.Text += apuesta.Element("apostador").Value;
                if (bEnSitio)
                {
                    box.Text += " <al ";
                    box.Text += apuesta.Element("opcionApuesta").Element("puntajeApostado").Value;
                    box.Text += ">";
                }
                box.Text += Environment.NewLine;
                IEnumerable<XElement> fichasApostadas = apuesta.Element("valorApuesta").Elements("fichaValor");
                foreach (XElement fichaValor in fichasApostadas)
                {
                    box.Text += "Ficha: €";
                    box.Text += fichaValor.Element("valor").Value;
                    box.Text += " Cantidad: ";
                    box.Text += fichaValor.Element("cantidad").Value;
                    box.Text += Environment.NewLine;
                }
            }
        }

        private void UpdateProximoTiro(XElement proximoTiro)
        {
            bool esTiroDeSalida = String.Compare(proximoTiro.Element("tiroSalida").Value, "si", true) == 0;
            m_rondaTiradorTextBox.Text = proximoTiro.Element("tirador").Value;
            m_rondaTiroTextBox.Text = esTiroDeSalida ? "Salida" : "Punto";
            m_rondaPuntoTextBox.Text = esTiroDeSalida ? "-" : proximoTiro.Element("punto").Value;
        }

        private void UpdateJugadoresEnMesa(XElement jugadoresEnMesa)
        {
            m_jugadoresEnLaMesaTextBox.Text = "";
            IEnumerable<XElement> jugadores = jugadoresEnMesa.Elements("jugador");
            foreach (XElement jugador in jugadores)
            {
                m_jugadoresEnLaMesaTextBox.Text += jugador.Value;
                m_jugadoresEnLaMesaTextBox.Text += Environment.NewLine;
            }
        }

        private void UpdateUltimoTiro(XElement ultimoTiro)
        {
            m_lastResultTiradorTextBox.Text = ultimoTiro.Element("tirador").Value;
            XElement resultado = ultimoTiro.Element("resultado");
            string dado1 = resultado.Element("dado1").Value;
            string dado2 = resultado.Element("dado2").Value;
            m_lastResultDado1TextBox.Text = dado1;
            m_lastResultDado2TextBox.Text = dado2;

            if (dado1 == "" || dado2 == "")
                return;

            m_historyTextBox.Text = "<" + dado1 + "," + dado2 + "> " + m_historyTextBox.Text;
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
                MessageBox.Show(this, "Tiro no aceptado. Razones desconocidas :P", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        void RefreshSaldo()
        {
            m_cashTextBox.Text = "€" + m_session.Saldo.ToString();
        }

        void UpdatePozoFeliz()
        {
            XElement res = AccesoYVistaCasino.ObtenerInstancia().PedirEstadoCasino(m_session.Nombre);
            HappyPozoTextBox.Text = "€" + res.Element("pozosCasino").Element("pozoFeliz").Value;
        }

        #region CoinsInHandRelated

        private void m_pickButton_Click(object sender, EventArgs e)
        {
            ValorFicha ficha = ValorFicha.Parse(m_coinsComboBox.SelectedItem.ToString().Substring(1));
            m_fichasEnMano[ficha] = m_fichasEnMano[ficha] + 1;
            RefreshCoinsInHand();
            SetBetButtonsState(true);
        }

        private void m_dropAllButton_Click(object sender, EventArgs e)
        {
            DropAllCoinsInHand();
        }

        private void DropAllCoinsInHand()
        {
            SetBetButtonsState(false);

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
            List<KeyValuePair<ValorFicha,int> > fichasApostadas = m_fichasEnMano.ToList();
            fichasApostadas.RemoveAll(delegate(KeyValuePair<ValorFicha,int> fichaCantidad) { return fichaCantidad.Value == 0; } );

            XElement res = JuegoCraps.ObtenerInstancia().ApostarCraps(
                m_session.Nombre,
                m_idMesa,
                fichasApostadas,
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