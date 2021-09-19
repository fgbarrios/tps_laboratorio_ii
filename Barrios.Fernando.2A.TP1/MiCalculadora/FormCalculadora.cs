using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        public FormCalculadora()
        {
            InitializeComponent();
        }

        private void FormCalculadora_Load(object sender, EventArgs e)
        {

            lstOperaciones.Items.Add("");

            //El evento Load del formulario deberá llamar al método Limpiar.
            Limpiar();

        }

        private void Limpiar()
        {
            txtNumero1.Text = "";
            txtNumero2.Text = "";
            cmbOperador.SelectedIndex = -1;
            lblResultado.Text = "";
            lstOperaciones.Items.Clear();
            txtNumero1.Focus();
        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
            double resultado;
            if (cmbOperador.Text == "" || cmbOperador.Text == " ")
            {
                resultado = Operar(txtNumero1.Text, txtNumero2.Text, "+");
            }
            else 
            {
                resultado = Operar(txtNumero1.Text, txtNumero2.Text, cmbOperador.Text);
            }        
            this.lblResultado.Text = resultado.ToString();

            // agrega el resultado al ListBox
            lstOperaciones.Items.Add(lblResultado.Text);

        }

        static private double Operar(string numero1, string numero2, string operador)
        {
            double resultado = 0;
            char charOperador = ' ';
            if (operador != " ")
            {
                charOperador = Char.Parse(operador);
            }

            Operando operandoNumero1 = new Operando(numero1);
            Operando operandoNumero2 = new Operando(numero2);
            resultado = Calculadora.Operar(operandoNumero1, operandoNumero2, charOperador);
            
            return resultado;
        }

        private void cmbOperador_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            this.lblResultado.Text = new Operando().DecimalBinario(this.lblResultado.Text);
        }

        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            Operando numeroADecimal = new Operando();
            string resultado = numeroADecimal.BinarioDecimal(lblResultado.Text);
            lblResultado.Text = resultado;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void FormCalculadora_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("¿Seguro de querer salir?",
                      "Salir",
                       MessageBoxButtons.YesNo,
                       MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }

        }
    }
}
