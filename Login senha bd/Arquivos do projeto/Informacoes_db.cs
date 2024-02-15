using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace Login_senha_bd
{
    static class Informacoes_db
    {
        static string db = "SERVER=localhost;USER=root;DATABASE=bd_cadastro";// colocando as informações da conecxão

        static public MySqlConnection conexao;// estabelecendo a conecxão

        static public string nome, senha, gmail, estado;// variaveis que vão receber as informações

        static public void conectar()// metodo para conectar
        {
            try
            {
                conexao = new MySqlConnection(db);// juntando as informações da conecxão e instanciando ela para abrir
                conexao.Open();// abrindo a conecxão
            }
            catch (Exception erro)
            {
                MessageBox.Show("Não foi possivél conectar ao banco de dados", erro.Message);
            }
        }

        static public void desconectar()// metodo para fechar a conecxão
        {
            try
            {
                conexao = new MySqlConnection(db);
                conexao.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Não foi possivél desconectar do banco de dados");
            }
        }

        static public void cadastro()//metodo para cadastrar
        {
            try
            {
                conectar();//Abrindo a conecxão

                string comando = "INSERT INTO tb_usuario (Id_Usuario,Nome,gmail,senha,estado) VALUE (DEFAULT,@Nome,@gmail,@senha,@estado)";// comando para inserir os dados no bd

                MySqlCommand liga_cmd = new MySqlCommand(comando, conexao);// aqui esta a conexão junto com os comando para inserir
                liga_cmd.Parameters.AddWithValue("@Nome", nome);
                liga_cmd.Parameters.AddWithValue("@senha", senha);
                liga_cmd.Parameters.AddWithValue("@gmail", gmail);
                liga_cmd.Parameters.AddWithValue("@estado", estado);

                liga_cmd.ExecuteNonQuery();// execultando a busca
                desconectar();// desconectando do banco

                MessageBox.Show("Seu Cadastro feito com sucesso", "Parabéns", MessageBoxButtons.OK, MessageBoxIcon.Information);
                FrmLogin tela1 = new FrmLogin();
                tela1.Show();
                FrmCadastro tela2 = new FrmCadastro();
                tela2.Hide();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Não foi possivél cadastrar ao banco de dados", ex.Message);
            }
        }

        static public bool verificalogin(string nomeusuario, string senhausuario)
        {
            using (MySqlConnection conexao2 = new MySqlConnection(db))
            {
                conexao2.Open();

                string comando2 = "SELECT COUNT(*) FROM tb_usuario WHERE Nome = @Nome AND senha = @senha";
                MySqlCommand command = new MySqlCommand(comando2, conexao2); 
                
                    command.Parameters.AddWithValue("@Nome", nomeusuario);
                    command.Parameters.AddWithValue("@senha", senhausuario);

                    int count = Convert.ToInt32(command.ExecuteScalar());

                    return count > 0;
            }
        }
    }

}
