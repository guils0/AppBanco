using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace AppBanco
{
    public partial class FormCadastro : Form
    {
        private MySqlConnection conexao;
        private DataTable dataTable;

        public FormCadastro()
        {
            InitializeComponent();
            InitializeDatabaseConnection();
            InitializeDataGridView();
            LoadData(); // Carrega os dados inicialmente ao abrir o formulário
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

        private void InitializeDataGridView()
        {
            // Configuração inicial do DataGridView
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.Columns.Add("Id", "ID");
            dataGridView1.Columns.Add("Usuario", "Usuário");
            dataGridView1.Columns.Add("Senha", "Senha");
        }

        private void LoadData()
        {
            try
            {
                if (conexao.State == ConnectionState.Closed)
                {
                    conexao.Open();
                }

                // Consulta SQL para carregar os dados
                string query = "SELECT id, usuario, senha FROM usuarios";
                MySqlCommand comando = new MySqlCommand(query, conexao);
                MySqlDataAdapter adapter = new MySqlDataAdapter(comando);
                dataTable = new DataTable();
                adapter.Fill(dataTable);

                // Limpa o DataGridView antes de carregar os novos dados
                dataGridView1.Rows.Clear();

                // Adiciona os dados do DataTable ao DataGridView
                foreach (DataRow row in dataTable.Rows)
                {
                    dataGridView1.Rows.Add(row.ItemArray);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar dados: " + ex.Message);
            }
            finally
            {
                if (conexao.State == ConnectionState.Open)
                {
                    conexao.Close();
                }
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text;
            string senha = txtSenha.Text;

            try
            {
                if (conexao.State == ConnectionState.Closed)
                {
                    conexao.Open();
                }

                // Consulta SQL para inserir um novo registro
                string query = "INSERT INTO usuarios (usuario, senha) VALUES (@Usuario, @Senha)";
                MySqlCommand comando = new MySqlCommand(query, conexao);
                comando.Parameters.AddWithValue("@Usuario", usuario);
                comando.Parameters.AddWithValue("@Senha", senha);
                comando.ExecuteNonQuery();

                // Recarrega os dados no DataGridView após inserção
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao inserir registro: " + ex.Message);
            }
            finally
            {
                if (conexao.State == ConnectionState.Open)
                {
                    conexao.Close();
                }
            }
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            // O carregamento dos dados já é feito ao abrir o formulário
            // Pode ser apenas um refresh do DataGridView se necessário
            LoadData();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string id = txtId.Text;
            string usuario = txtUsuario.Text;
            string senha = txtSenha.Text;

            try
            {
                if (conexao.State == ConnectionState.Closed)
                {
                    conexao.Open();
                }

                // Consulta SQL para atualizar um registro
                string query = "UPDATE usuarios SET usuario = @Usuario, senha = @Senha WHERE id = @Id";
                MySqlCommand comando = new MySqlCommand(query, conexao);
                comando.Parameters.AddWithValue("@Usuario", usuario);
                comando.Parameters.AddWithValue("@Senha", senha);
                comando.Parameters.AddWithValue("@Id", id);
                comando.ExecuteNonQuery();

                // Recarrega os dados no DataGridView após atualização
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao atualizar registro: " + ex.Message);
            }
            finally
            {
                if (conexao.State == ConnectionState.Open)
                {
                    conexao.Close();
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string id = txtId.Text;

            try
            {
                if (conexao.State == ConnectionState.Closed)
                {
                    conexao.Open();
                }

                // Consulta SQL para excluir um registro
                string query = "DELETE FROM usuarios WHERE id = @Id";
                MySqlCommand comando = new MySqlCommand(query, conexao);
                comando.Parameters.AddWithValue("@Id", id);
                comando.ExecuteNonQuery();

                // Recarrega os dados no DataGridView após exclusão
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao excluir registro: " + ex.Message);
            }
            finally
            {
                if (conexao.State == ConnectionState.Open)
                {
                    conexao.Close();
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ao clicar em uma célula do DataGridView, preenche os campos de texto (txtId, txtUsuario, txtSenha)
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                txtId.Text = row.Cells["Id"].Value.ToString();
                txtUsuario.Text = row.Cells["Usuario"].Value.ToString();
                txtSenha.Text = row.Cells["Senha"].Value.ToString();
            }
        }
    }
}
