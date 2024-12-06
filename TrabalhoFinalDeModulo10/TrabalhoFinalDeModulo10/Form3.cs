using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrabalhoFinalDeModulo10
{
    public partial class Form3 : Form
    {
        string utilizador = "adm";
        string password = "1234"; 
        public Form3()
        {
            InitializeComponent();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13) 
            {
                if (textBox1.Text == utilizador)
                {
                    MessageBox.Show("Utilizador Correto");
                }else
                {
                    MessageBox.Show("Digite o utlizador outra vez");
                }

            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13) 
            {
                if (textBox2.Text == password && textBox1.Text == utilizador) 
                {
                    MessageBox.Show("Utilizador e passwod corretos!");
                    Form2 form2 = new Form2();
                    form2.Show();
                }
                else
                {
                    MessageBox.Show("Utilizador ou Password incorretos");
                }
            }
        }
    }
}
