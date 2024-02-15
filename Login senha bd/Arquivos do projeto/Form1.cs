using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login_senha_bd
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void ChkMostrar_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkMostrar.Checked == true)
            {
                TxtSenha.PasswordChar = '\0';
            }
            else
            {
                TxtSenha.PasswordChar = '*';
            }
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            TxtNome.Focus();
        }

        private void TxtNome_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar)&&!char.IsControl(e.KeyChar)&&!char.IsWhiteSpace(e.KeyChar)&&e.KeyChar!=8 )
            {
                e.Handled = true;
                MessageBox.Show("Insira apenas letras e nomes sem acentos","Aviso caractere invalido",MessageBoxButtons.OK,MessageBoxIcon.Information);
                TxtNome.Clear();
                TxtNome.Focus();
            }
        }

        private void TxtSenha_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar)&&!char.IsControl(e.KeyChar)&&e.KeyChar!=8)
            {
                e.Handled = true;
                MessageBox.Show("Insira apenas numeros", "Avisoo caractere invalido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtSenha.Clear();
                TxtSenha.Focus();
            }
        }

        private void LblCadastrar_Click(object sender, EventArgs e)
        {
            FrmCadastro cadastro = new FrmCadastro();
            cadastro.Show();
            Hide();
        }

        private void BtnEntrar_Click(object sender, EventArgs e)
        {
            string nomelogin = TxtNome.Text;
            string senhalogin = TxtSenha.Text;

            try
            {
                if (Informacoes_db.verificalogin(nomelogin, senhalogin))
                {
                    MessageBox.Show("Entrada feita com sucesso");
                    Informacoes_db.desconectar();
                }
                else
                {
                    MessageBox.Show("Cadastro não encontrado\nTente colocar as informações corretamente","AViso",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    TxtNome.Clear();
                    TxtSenha.Clear();
                    Informacoes_db.desconectar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Banco de dados não encontrado", ex.Message);
            }



        }

        private void Btn_Sair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Btn_Minimizar_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
    }
}
