using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Login_senha_bd
{
    public partial class FrmCadastro : Form
    {
        public FrmCadastro()
        {
            InitializeComponent();
        }

        private void Btn_cadastrar_Click(object sender, EventArgs e)
        {
            Informacoes_db.nome = TxtNome.Text;
            Informacoes_db.gmail = TxtGmail.Text;
            Informacoes_db.senha = TxtSenha2.Text;
            Informacoes_db.estado = Cmb_Estado.Text;

            if (TxtNome.Text != "" && TxtGmail.Text != "" && TxtSenha2.Text != "" && Cmb_Estado.Text != ""
             && TxtSenha1.Text == TxtSenha2.Text) 
            {
                Informacoes_db.cadastro(); 
            }
            else
            {
                MessageBox.Show("Por favor preencha todos os campos corretamente","Aviso",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }

            
        }

        private void FrmCadastro_Load(object sender, EventArgs e)
        {

        }

        private void TxtNome_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar)&&!char.IsControl(e.KeyChar)&&e.KeyChar!= 8)
            {
                MessageBox.Show("Insira apenas letras e nomes sem acento", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                TxtNome.Focus();
                TxtNome.Text = string.Empty;
            }
        }

      

        private void ChkMostrar_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkMostrar.Checked == true)
            {
                TxtSenha1.PasswordChar = '\0';
                TxtSenha2.PasswordChar = '\0';
            }
            else
            {
                TxtSenha1.PasswordChar = '*';
                TxtSenha2.PasswordChar = '*';
            }
        }

        private void TxtSenha1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar)&&!char.IsControl(e.KeyChar)&&e.KeyChar !=8)
            {
                e.Handled = true;
                MessageBox.Show("Insira apenas numeros", "Caractere Invalida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //TxtSenha1.Text = string.Empty;
                TxtSenha1.Focus();
                TxtSenha1.Clear();
            }
        }

        private void TxtSenha2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)&&!char.IsNumber(e.KeyChar)&&e.KeyChar !=8 )
            {
                e.Handled = true;
                MessageBox.Show("Insira apenas numeros", "Caractere Invalida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TxtSenha2.Clear();
                TxtSenha2.Focus();
            }
        }

        private void TxtSenha2_TextChanged(object sender, EventArgs e)
        {
            if (TxtSenha2.Text == TxtSenha1.Text)
            {
                LblCompare.Text = "";
            }
            else
            {
                LblCompare.Text = "Gigite a mesma Senha";
            }
        }

        private void Btn_Sair_Click(object sender, EventArgs e)
        {
            FrmLogin tela1 = new FrmLogin();
            tela1.Show();
            Hide();
        }

        private void Btn_Minimizar_Click(object sender, EventArgs e)
        {

            WindowState = FormWindowState.Minimized;
        }
    }
}
