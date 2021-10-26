using SoilCorrectionNET.Correcoes;
using SoilCorrectionNET.Fontes;
using StringExtensionLibrary;
using System;
using System.Windows.Forms;

namespace SoilCorrectionNET
{
    public partial class FrmPrincipal : Form
    {
        readonly EquilibrioCorrecaoCtc equilibrioCorrecaoCtc;
        FonteFosforo fonteFosforoSelecionada;
        FontePotassio fontePotassioSelecionada;

        public FrmPrincipal()
        {
            InitializeComponent();

            cbTexturaSolo.SelectedIndex = 0;
            cbSistemaCultivo.SelectedIndex = 0;

            equilibrioCorrecaoCtc = new EquilibrioCorrecaoCtc();
        }

        private void cbTexturaSolo_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(cbTexturaSolo.SelectedIndex)
            {
                case 0:
                    {
                        lblTextura.Text = "+ 40% de argila";

                        lblIdealFosforo.Text = "9,0";
                        lblIdealPotassio.Text = "0,35";
                        lblIdealCalcio.Text = "6,0";
                        lblIdealMagnesio.Text = "9,0";
                        lblIdealEnxofre.Text = "9,0";
                        lblIdealAluminio.Text = "0,0";
                    }
                    break;
                case 1:
                    {
                        lblTextura.Text = "25 a 40% de argila";

                        lblIdealFosforo.Text = "12,0";
                        lblIdealPotassio.Text = "0,25";
                        lblIdealCalcio.Text = "4,0";
                        lblIdealMagnesio.Text = "1,0";
                        lblIdealEnxofre.Text = "6,0";
                        lblIdealAluminio.Text = "0,0";
                    }
                    break;
            }
        }

        private void cbSistemaCultivo_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbSistemaCultivo.SelectedIndex)
            {
                case 0: lblCultivo.Text = "Plantio Direto"; break;
                case 1: lblCultivo.Text = "Convencional"; break;
            }
        }

        private void numericTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != ','))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == ',') && ((sender as TextBox).Text.IndexOf(',') > -1))
            {
                e.Handled = true;
            }
        }

        private void ctcTextBox_Leave(object sender, EventArgs e)
        {
            decimal potassio = txtTeorPotassio.Text.ToDecimal();
            decimal calcio = txtTeorCalcio.Text.ToDecimal();
            decimal magnesio = txtTeorMagnesio.Text.ToDecimal();
            decimal hidrogenioAluminio = txtTeorHal.Text.ToDecimal();

            lblScmol.Text = $"{equilibrioCorrecaoCtc.CalculaSCmol(potassio, calcio, magnesio):N2}";
            lblCtcCmol.Text = $"{equilibrioCorrecaoCtc.CalculaCTCCmol(potassio, calcio, magnesio, hidrogenioAluminio):N2}";
            lblVPorcentagem.Text = $"{equilibrioCorrecaoCtc.CalculaVPercentual(lblScmol.Text.ToDecimal(), lblCtcCmol.Text.ToDecimal()):N2}";
        }

        private void txtValorMO_Leave(object sender, EventArgs e)
        {
            decimal mo = txtValorMO.Text.ToDecimal();

            lblMoPorcentagem.Text = $"{equilibrioCorrecaoCtc.CalculaMOPercentual(mo):N2}";
            lblCarbonoValor.Text = $"{equilibrioCorrecaoCtc.CalculaCarbono(lblMoPorcentagem.Text.ToDecimal()):N2}";
        }

        private void cbFonteFosforo_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(cbFonteFosforo.SelectedIndex)
            {
                case 0: fonteFosforoSelecionada = FonteFosforo.SUPERFOSFATO_SIMPLES; break;
                case 1: fonteFosforoSelecionada = FonteFosforo.SUPERFOSFATO_TRIPLO; break;
                case 2: fonteFosforoSelecionada = FonteFosforo.MAP; break;
                default:
                    {
                        MessageBox.Show("Fonte não implementada!");
                        fonteFosforoSelecionada = null;
                    }
                    break;
            }

            correcaoFosforoTextBox_Leave(sender, e);
        }

        private void correcaoFosforoTextBox_Leave(object sender, EventArgs e)
        {
            if(fonteFosforoSelecionada != null)
            {
                try
                {
                    var correcaoFosforo = new CorrecaoNutriente<FonteFosforo>();
                    decimal qtdNutrienteAdicionar = textBox1.Text.ToDecimal() - txtTeorFosforo.Text.ToDecimal();
                    decimal qtdAplicar = correcaoFosforo.CalculaQuantidadeAplicar(qtdNutrienteAdicionar, txtEficienciaFosforo.Text.ToDecimal(), fonteFosforoSelecionada);

                    lblCorrecaoFosforoAdicional.Text = "";
                    lblQtdFosforoAplicar.Text = $"{qtdAplicar:N2} - kg/hectare";
                    lblCustoFosforoHa.Text = $"{correcaoFosforo.CalculaCusto(txtFosforoValorTonelada.Text.ToDecimal(), qtdAplicar):N2}";
                    lblCorrecaoFosforo.Text = $"{txtTeorFosforo.Text.ToDecimal():N2}";

                    correcaoFosforo.ObterNutrientesAdicionais(qtdAplicar, fonteFosforoSelecionada)
                        .ForEach(item => lblCorrecaoFosforoAdicional.Text += $"{item.CorrecaoAdicional:N2} - {item.Nome}\n");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void cbFontePotassio_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbFontePotassio.SelectedIndex)
            {
                case 0: fontePotassioSelecionada = FontePotassio.CLORETO_POTASSIO; break;
                case 1: fontePotassioSelecionada = FontePotassio.SULFATO_POTASSIO; break;
                case 2: fontePotassioSelecionada = FontePotassio.SULFATO_POTASSIO_MAGNESIO; break;
                default:
                    {
                        MessageBox.Show("Fonte não implementada!");
                        fontePotassioSelecionada = null;
                    }
                    break;
            }

            correcaoPotassioTextBox_Leave(sender, e);
        }

        private void correcaoPotassioTextBox_Leave(object sender, EventArgs e)
        {
            if (fontePotassioSelecionada != null)
            {
                try
                {
                    var correcaoPotassio = new CorrecaoNutriente<FontePotassio>();

                    decimal potassioDesejado = txtPotassioDesejado.Text.ToDecimal();
                    decimal potassioParticipacao = txtTeorPotassio.Text.ToDecimal() / ((txtTeorPotassio.Text.ToDecimal() + txtTeorCalcio.Text.ToDecimal() + txtTeorMagnesio.Text.ToDecimal() + txtTeorHal.Text.ToDecimal()) / 100);
                    decimal correcaoPotassioValor = correcaoPotassio.CalculaQuantidadeAplicar(txtTeorPotassio.Text.ToDecimal(), potassioParticipacao, fontePotassioSelecionada, potassioDesejado);

                    lblCorrecaoPotassioAtual.Text = $"{potassioParticipacao:N2} %";
                    lblCorrecaoPotassioApos.Text = $"{potassioDesejado:N2} %";
                    lblParticipacaoPotassioIdeal.Text = cbTexturaSolo.SelectedIndex == 0 ? "3,00%" : "3,00%";
                    lblCorrecaoPotassio.Text = $"{(txtTeorPotassio.Text.ToDecimal() > 0.5m ? txtTeorPotassio.Text.ToDecimal() : correcaoPotassioValor)}";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
