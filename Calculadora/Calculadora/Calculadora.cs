using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculadora
{
    public partial class FrmCalculadora : Form
    {
        double valorVisor = 0, valorAnterior = 0;
        string operacao = "";
        bool primeiraOperacao = true, botaoIgual = false;
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                btnIgual.PerformClick();
                return true;
            }
            else if (keyData == Keys.Back)
            {
                btnBackspace.PerformClick();
                return true;
            }
            else if (keyData == Keys.Escape)
            {
                btnClear.PerformClick();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        public FrmCalculadora()
        {
            InitializeComponent();
        }
        private void ClickBtn_Click(object sender, EventArgs e)
        {
            if (txtVisor.Text == "0" || botaoIgual == true)
            {
                txtVisor.Clear();
                if (botaoIgual)
                {
                    txtHistorico.Clear();
                }
                botaoIgual = false;
            }
            Button buttonclick = (Button)sender;

            switch (buttonclick.Name)
            {
                case "btn1":
                    txtVisor.Text += "1";
                    break;
                case "btn2":
                    txtVisor.Text += "2";
                    break;
                case "btn3":
                    txtVisor.Text += "3";
                    break;
                case "btn4":
                    txtVisor.Text += "4";
                    break;
                case "btn5":
                    txtVisor.Text += "5";
                    break;
                case "btn6":
                    txtVisor.Text += "6";
                    break;
                case "btn7":
                    txtVisor.Text += "7";
                    break;
                case "btn8":
                    txtVisor.Text += "8";
                    break;
                case "btn9":
                    txtVisor.Text += "9";
                    break;
                case "btn0":
                    txtVisor.Text += "0";
                    break;
                case "btnVirgula":
                    if (!txtVisor.Text.Contains(","))
                    {
                        if (txtVisor.Text == "")
                        {
                            txtVisor.Text = "0,";
                        }
                        else
                        {
                            txtVisor.Text += ",";
                        }
                    }
                    break;
            }
            
        }

        private void BtnPlus_Click(object sender, EventArgs e)
        {
            if (primeiraOperacao)
            {

                if (botaoIgual)
                {
                    txtHistorico.Clear();
                    botaoIgual = false;
                }
                valorAnterior = Convert.ToDouble(txtVisor.Text);
                txtHistorico.Text += txtVisor.Text;
                txtVisor.Clear();
                operacao = "+";
                primeiraOperacao = false;
            }
            else
            {
                try
                {
                    valorVisor = Convert.ToDouble(txtVisor.Text);
                    txtHistorico.Text += operacao + txtVisor.Text;

                    ObjetoCalculo adicao = new ObjetoCalculo();

                    adicao.valorVisor = this.valorVisor;
                    adicao.valorAnterior = this.valorAnterior;
                    adicao.operacao = this.operacao;
                    txtVisor.Text = Convert.ToString(adicao.Calculo());

                    operacao = "+";
                    txtHistorico.Text += ($" = {txtVisor.Text}\r\n");
                    valorAnterior = Convert.ToDouble(txtVisor.Text);
                    botaoIgual = true;
                }

                catch (System.FormatException doubleopc)
                {
                    MessageBox.Show("Não repita operações", "erro", MessageBoxButtons.OK);
                }
            }

        }

        private void BtnDiv_Click(object sender, EventArgs e)
        {
            if (primeiraOperacao)
            {

                if (botaoIgual)
                {
                    txtHistorico.Clear();
                    botaoIgual = false;
                }
                valorAnterior = Convert.ToDouble(txtVisor.Text);
                txtHistorico.Text += txtVisor.Text;
                txtVisor.Clear();
                operacao = "/";
                primeiraOperacao = false;
            }
            else
            {
                try
                {
                    valorVisor = Convert.ToDouble(txtVisor.Text);
                    txtHistorico.Text += ($"{operacao} {txtVisor.Text}");

                    ObjetoCalculo divisao = new ObjetoCalculo();

                    divisao.valorVisor = this.valorVisor;
                    divisao.valorAnterior = this.valorAnterior;
                    divisao.operacao = this.operacao;
                    txtVisor.Text = Convert.ToString(divisao.Calculo());

                    operacao = "/";
                    txtHistorico.Text += ($" = {txtVisor.Text}");
                    valorAnterior = Convert.ToDouble(txtVisor.Text);
                    botaoIgual = true;
                }
                catch (System.FormatException doubleopc)
                {
                    MessageBox.Show("Não repita operações", "erro", MessageBoxButtons.OK);
                }
            }
        }

        private void BtnX_Click(object sender, EventArgs e)
        {
            if (primeiraOperacao)
            {

                if (botaoIgual)
                {
                    txtHistorico.Clear();
                    botaoIgual = false;
                }
                valorAnterior = Convert.ToDouble(txtVisor.Text);
                txtHistorico.Text += txtVisor.Text;
                txtVisor.Clear();
                operacao = "x";
                primeiraOperacao = false;
            }
            else
            {
                try
                {
                    valorVisor = Convert.ToDouble(txtVisor.Text);
                    txtHistorico.Text += ($"{operacao} {txtVisor.Text}");

                    ObjetoCalculo multiplicacao = new ObjetoCalculo();

                    multiplicacao.valorVisor = this.valorVisor;
                    multiplicacao.valorAnterior = this.valorAnterior;
                    multiplicacao.operacao = this.operacao;
                    txtVisor.Text = Convert.ToString(multiplicacao.Calculo());


                    operacao = "x";
                    txtHistorico.Text += ($" = {txtVisor.Text}");
                    valorAnterior = Convert.ToDouble(txtVisor.Text);
                    botaoIgual = true;
                }
                catch (System.FormatException doubleopc)
                {
                    MessageBox.Show("Não repita operações", "erro", MessageBoxButtons.OK);
                }
            }
        }

        private void BtnIgual_Click(object sender, EventArgs e)
        {
            try
            {
                valorVisor = Convert.ToDouble(txtVisor.Text);
                txtHistorico.Text += ($" {operacao} {txtVisor.Text}");

                ObjetoCalculo igual = new ObjetoCalculo();

                igual.valorVisor = this.valorVisor;
                igual.valorAnterior = this.valorAnterior;
                igual.operacao = this.operacao;
                txtVisor.Text = Convert.ToString(igual.Calculo());


                txtHistorico.Text += ($" = {txtVisor.Text}\r\n");

                valorAnterior = Convert.ToDouble(txtVisor.Text);

                botaoIgual = true;
                primeiraOperacao = true;
            }
            catch (System.FormatException doubleopc)
            {
                MessageBox.Show("Não repita operações", "erro", MessageBoxButtons.OK);
            }
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            txtVisor.Clear();
            txtHistorico.Clear();
            valorAnterior = 0;
            valorVisor = 0;
            operacao = "";
            primeiraOperacao = true;
            botaoIgual = true;

        }

        private void BtnSqrt_Click(object sender, EventArgs e)
        {
            if (primeiraOperacao)
            {
                operacao = "√";
            }
            else
            {
                try
                {
                    valorVisor = Convert.ToDouble(txtVisor.Text);
                    txtHistorico.Text += ($"{operacao} {txtVisor.Text}");

                    ObjetoCalculo sqrt = new ObjetoCalculo();

                    sqrt.valorVisor = this.valorVisor;
                    sqrt.valorAnterior = this.valorAnterior;
                    sqrt.operacao = this.operacao;
                    txtVisor.Text = Convert.ToString(sqrt.Calculo());


                    operacao = "x";
                    txtHistorico.Text += ($" = {txtVisor.Text}");
                    valorAnterior = Convert.ToDouble(txtVisor.Text);

                    if (sqrt.operacao != "√")
                    {
                        txtHistorico.Text += ($"{operacao} {txtVisor.Text}");
                        valorVisor = Convert.ToDouble(txtVisor.Text);
                        sqrt.operacao = this.operacao;
                        sqrt.valorVisor = this.valorVisor;
                        txtVisor.Text = Convert.ToString(sqrt.Calculo());
                        txtHistorico.Text += ($" = {txtVisor.Text}");
                        valorAnterior = Convert.ToDouble(txtVisor.Text);
                        botaoIgual = true;
                    }
                }
                catch (System.FormatException doubleopc)
                {
                    MessageBox.Show("Não repita operações", "erro", MessageBoxButtons.OK);
                }
            }
        }

        private void Teclado_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (botaoIgual && char.IsDigit(e.KeyChar))
            {
                txtVisor.Clear();
                botaoIgual = false;
            }
            if (char.IsDigit(e.KeyChar))
            {
                txtVisor.Text += e.KeyChar;
                e.Handled = true;
                return;
            }
            switch (e.KeyChar)
            {
                case '+':
                    btnPlus.PerformClick();
                    e.Handled = true;
                    break;
                case '-':
                    btnMinus.PerformClick();
                    e.Handled = true;
                    break;
                case '/':
                    btnDiv.PerformClick();
                    e.Handled = true;
                    break;
                case '*':
                case 'x':
                case 'X':
                    btnX.PerformClick();
                    e.Handled = true;
                    break;
                case (char)13:
                    btnIgual.PerformClick();
                    e.Handled = true;
                    break;
                case ',':
                    btnVirgula.PerformClick();
                    e.Handled = true;
                    break;
                case '\b':
                    btnBackspace.PerformClick();
                    e.Handled = true;
                    break;
            }
        }


        private void BtnMinus_Click(object sender, EventArgs e)
        {
            if (primeiraOperacao)
            {

                if (botaoIgual)
                {
                    txtHistorico.Clear();
                    botaoIgual = false;
                }
                valorAnterior = Convert.ToDouble(txtVisor.Text);
                txtHistorico.Text += txtVisor.Text;
                txtVisor.Clear();
                operacao = "-";
                primeiraOperacao = false;
            }
            else
            {
                try
                {
                    valorVisor = Convert.ToDouble(txtVisor.Text);

                    txtHistorico.Text += ($"{operacao} {txtVisor.Text}");

                    ObjetoCalculo subtracao = new ObjetoCalculo();

                    subtracao.valorVisor = this.valorVisor;
                    subtracao.valorAnterior = this.valorAnterior;
                    subtracao.operacao = this.operacao;
                    txtVisor.Text = Convert.ToString(subtracao.Calculo());


                    operacao = "-";
                    txtHistorico.Text += ($" = {txtVisor.Text}");
                    valorAnterior = Convert.ToDouble(txtVisor.Text);
                    botaoIgual = true;
                }
                catch (System.FormatException doubleopc)
                {
                    MessageBox.Show("Não repita operações", "erro", MessageBoxButtons.OK);
                }
            }
        }

        private void BtnBackspace_Click(object sender, EventArgs e)
        {
            if (txtVisor.Text.Length > 0)
            {
                txtVisor.Text = txtVisor.Text.Remove(txtVisor.Text.Length - 1);
            }
        }
    }
}
