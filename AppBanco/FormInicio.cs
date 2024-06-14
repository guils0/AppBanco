using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace AppBanco
{
    public partial class FormInicio : Form
    {
        private MySqlConnection conexao;

        public FormInicio()
        {
            InitializeComponent();
            InitializeDatabaseConnection();
        }

        private void InitializeDatabaseConnection()
        {
            string servidor = "localhost"; // ou o endereço do seu servidor MySQL
            string bancoDeDados = "meu_banco"; // nome do seu banco de dados
            string usuario = "root"; // usuário do banco de dados
            string senha = "uninove2024"; // senha do banco de dados

            string connectionString = $"Server={servidor};Database={bancoDeDados};Uid={usuario};Pwd={senha};";

            conexao = new MySqlConnection(connectionString);
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text;
            string senha = txtSenha.Text;

            // Monta a consulta SQL parametrizada
            string query = "SELECT COUNT(*) FROM usuarios WHERE usuario = @Usuario AND senha = @Senha";

            // Prepara o comando SQL
            MySqlCommand comando = new MySqlCommand(query, conexao);
            comando.Parameters.AddWithValue("@Usuario", usuario);
            comando.Parameters.AddWithValue("@Senha", senha);

            try
            {
                // Abre a conexão com o banco de dados
                conexao.Open();

                // Executa o comando e obtém o resultado
                int count = Convert.ToInt32(comando.ExecuteScalar());

                // Verifica se encontrou um usuário com a senha correta
                if (count > 0)
                {
                    // Se o usuário e senha estão corretos, abre o FormBanco
                    FormBanco formBanco = new FormBanco();
                    formBanco.ShowDialog();
                }
                else
                {
                    // Caso contrário, exibe mensagem de erro
                    lblErro.Visible = true;
                }
            }
            catch (Exception ex)
            {
                // Em caso de erro, exibe mensagem de erro
                MessageBox.Show("Erro ao conectar ao banco de dados: " + ex.Message);
            }
            finally
            {
                // Fecha a conexão com o banco de dados
                conexao.Close();
            }
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            FormCadastro formCadastro = new FormCadastro();
            formCadastro.ShowDialog();
        }
    }
}
