using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;

namespace TrabalhoFinalDeModulo10
{
    public class ContaBancaria_Class
    {
        public struct Movimentos
        {
            public double valor;
            public DateTime data;
            public string tipo;
            public int id;

            public Movimentos(double valor, DateTime data, string tipo, int id)
            {
                this.valor = valor;
                this.data = data;
                this.tipo = tipo;
                this.id = id;
            }
        };

        public double saldoConta { get; set; } = 0.0;
        public string nomeCliente { get; set; }
        private string profissaoCliente { get; set; }
        private int NIFCliente { get; set; } = 999999999;
        public string numContaCliente { get; set; } = "000000000-00-0";
        private DateTime dataAbertura { get; set; }

        // Lista de movimentos da conta, pode ser uma lista de depósitos/saques em formato double
        public List<Movimentos> ListaMovimentos { get; set; } = new List<Movimentos>();
        private int movimentoId = 1;

        public ContaBancaria_Class(string nomeCliente, string profissaoCliente, int NIFCliente, string numContaCliente, DateTime dataAbertura)
        {
            this.nomeCliente = nomeCliente;
            this.profissaoCliente = profissaoCliente;
            this.NIFCliente = NIFCliente;
            this.numContaCliente = numContaCliente;
            this.dataAbertura = dataAbertura;
            this.saldoConta = 0.0;  // Inicializando o saldo como 0
        }

        // Método para retornar a data de abertura formatada
        public string getDataAberturaFormatada()
        {
            return dataAbertura.ToString("dd/MM/yyyy");
        }

        // Método para retornar o saldo formatado em moeda
        public string getSaldoFormatado()
        {
            var cultureInfo = new CultureInfo("pt-PT");
            return saldoConta.ToString("C", cultureInfo);
        }

        // Método para adicionar um movimento à lista (exemplo: saque, transferência)
        public void adicionarMovimento(double valor, string tipo)
        {
            if (valor != 0) //Não adiciona 0, para evitar movimentos inválidos
            {
                Movimentos movimento = new Movimentos(valor, DateTime.Now, tipo, movimentoId);
                ListaMovimentos.Add(movimento);
                movimentoId++;
            }
        }

        public void Depositar(double deposito)
        {
            if (deposito <= 0)
            {
                MessageBox.Show("Não pode depositar valores negativos.");
            }
            else
            {
                saldoConta += deposito;
                adicionarMovimento(deposito, "deposito");
                MessageBox.Show("Depósito realizado com sucesso.");
            }
        }

        public void Levantar(double levantamento)
        {
            if (levantamento <= 0)
            {
                MessageBox.Show("Impossível fazer um levantamento inferior ou igual a zero.");
            }
            else if (levantamento > saldoConta)
            {
                MessageBox.Show("Levantamento superior ao saldo atual.");
            }
            else
            {
                saldoConta -= levantamento;
                adicionarMovimento(levantamento, "levantamento");
                MessageBox.Show("Levantamento realizado com sucesso.");
            }
        }
    }
}