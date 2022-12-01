using FiaponSmartCity.Models;
using System.Data;
using System.Data.SqlClient;

namespace FiaponSmartCity.Repository
{
    public class PessoasRepository
    {
        public IList<TipoPessoa> Listar()
        {
            IList<TipoPessoa> lista = new List<TipoPessoa>();

            var connectionString = new ConfigurationBuilder()
                                        .SetBasePath(Directory.GetCurrentDirectory())
                                        .AddJsonFile("appsettings.json")
                                        .Build().GetConnectionString("FiapSmartCityConnection");
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                String query =
                    "SELECT * FROM TIPOPESSOA  ";

                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    TipoPessoa tipoPess = new TipoPessoa();
                    tipoPess.IdTipo = Convert.ToInt32(dataReader["IDTIPO"]);
                    tipoPess.Nome = dataReader["NOME"].ToString();
                    tipoPess.Endereco = dataReader["ENDERECO"].ToString();
                    lista.Add(tipoPess);
                }

                connection.Close();

            } 

            return lista;
        }

        public TipoPessoa Consultar(int id)
        {

            TipoPessoa tipoPess = new TipoPessoa();

            var connectionString = new ConfigurationBuilder()
                                        .SetBasePath(Directory.GetCurrentDirectory())
                                        .AddJsonFile("appsettings.json")
                                        .Build().GetConnectionString("FiapSmartCityConnection");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                String query =
                    "SELECT * FROM TIPOPESSOA WHERE IDTIPO = @IDTIPO ";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.Add("@IDTIPO", SqlDbType.Int);
                command.Parameters["@IDTIPO"].Value = id;
                connection.Open();

                SqlDataReader dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    tipoPess.IdTipo = Convert.ToInt32(dataReader["IDTIPO"]);
                    tipoPess.Nome = dataReader["NOME"].ToString();
                    tipoPess.Endereco = dataReader["ENDERECO"].ToString();
                }

                connection.Close();
            } 

            return tipoPess;
        }

        public void Inserir(TipoPessoa tipoPessoa)
        {
            var connectionString = new ConfigurationBuilder()
                                        .SetBasePath(Directory.GetCurrentDirectory())
                                        .AddJsonFile("appsettings.json")
                                        .Build().GetConnectionString("FiapSmartCityConnection");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                String query =
                    "INSERT INTO TIPOPESSOA (  NOME, ENDERECO ) VALUES ( @nome, @endereco) ";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.Add("@nome", SqlDbType.Text);
                command.Parameters["@nome"].Value = tipoPessoa.Nome;
                command.Parameters.Add("@endereco", SqlDbType.Text);
                command.Parameters["@endereco"].Value = tipoPessoa.Endereco;

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public void Alterar(TipoPessoa tipoPessoa)
        {
            var connectionString = new ConfigurationBuilder()
                                        .SetBasePath(Directory.GetCurrentDirectory())
                                        .AddJsonFile("appsettings.json")
                                        .Build().GetConnectionString("FiapSmartCityConnection");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                String query =
                    "UPDATE TIPOPESSOA SET NOME = @nome, ENDERECO = @endereco WHERE IDTIPO = @id  ";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.Add("@nome", SqlDbType.Text);
                command.Parameters.Add("@id", SqlDbType.Int);
                command.Parameters.Add("@endereco", SqlDbType.Text);
                command.Parameters["@nome"].Value = tipoPessoa.Nome;
                command.Parameters["@id"].Value = tipoPessoa.IdTipo;
                command.Parameters["@endereco"].Value = tipoPessoa.Endereco;

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public void Excluir(int id)
        {
            var connectionString = new ConfigurationBuilder()
                                        .SetBasePath(Directory.GetCurrentDirectory())
                                        .AddJsonFile("appsettings.json")
                                        .Build().GetConnectionString("FiapSmartCityConnection");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                String query =
                    "DELETE TIPOPESSOA WHERE IDTIPO = @id  ";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.Add("@id", SqlDbType.Int);
                command.Parameters["@id"].Value = id;

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }

        }
    }
}