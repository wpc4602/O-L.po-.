using System;
using System.Drawing.Text;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace TrabalhoFinalDeModulo10
{

    public partial class Form2 : Form
    {
        private ContaBancaria_Class contaBancaria;
        string nome;
        double deposito;
        double levantamento; 
        public Form2()
        {
            InitializeComponent();
        }

        private void LevantarVlrs_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

            if (double.TryParse(LevantarVlrs.Text, out levantamento))
            {
                contaBancaria.Levantar(levantamento);
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            label3.Text = contaBancaria.getDataAberturaFormatada();
        }

        private void LstMovimentos1_SelectedIndexChanged(object sender, EventArgs e)
        {
            LstMovimentos1.Items.Clear();

            foreach (var movimento in contaBancaria.ListaMovimentos)
            {
                LstMovimentos1.Items.Add(movimento.valor);
                LstMovimentos1.Items.Add(movimento.data);
                LstMovimentos1.Items.Add(movimento.tipo);
            }
        }

        private void CaixaDeTexto1_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == (char)13) 
            {
                CaixaDeTexto1.Text = contaBancaria.nomeCliente;
                contaBancaria.nomeCliente = nome;
            } 
            LstMovimentos1.Items.Add(nome);
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
        }

        private void Dinheiro__Click(object sender, EventArgs e)
        {
            if (contaBancaria != null) 
            {
                //Dinheiro_.Text == contaBancaria.getSaldoFormatado();
                Dinheiro_.Text = $"Capital depositada: {contaBancaria.saldoConta}";
            }

        }

        private void btn_Saida_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn2_Click(object sender, EventArgs e)
        {
           
        }

        private void DepositarVlrs_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (double.TryParse(DepositarVlrs.Text, out double deposito))
            {
                contaBancaria.Depositar(deposito);
                MessageBox.Show("Depósito realizado com sucesso.");
                // Atualize a label com o novo saldo
                Dinheiro_.Text = $"Capital depositada: {contaBancaria.saldoConta}";
            }
            else 
            {
                MessageBox.Show("Digite um valor real");
            }
        }
    }
}