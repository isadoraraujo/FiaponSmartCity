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
                    "SELECT IDTIPO, ENDERECO, RESIDENTE FROM TIPOPESSOA  ";

                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    TipoPessoa tipoPess = new TipoPessoa();
                    tipoPess.IdTipo = Convert.ToInt32(dataReader["IDTIPO"]);
                    tipoPess.Endereco = dataReader["RESIDENTE"].ToString();
                    tipoPess.Residente = dataReader["RESIDENTE"].Equals("1");

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
                    "SELECT IDTIPO, ENDERECO, RESIDENTE FROM TIPOPESSOA WHERE IDTIPO = @IDTIPO ";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.Add("@IDTIPO", SqlDbType.Int);
                command.Parameters["@IDTIPO"].Value = id;
                connection.Open();

                SqlDataReader dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    tipoPess.IdTipo = Convert.ToInt32(dataReader["IDTIPO"]);
                    tipoPess.Endereco = dataReader["ENDERECO"].ToString();
                    tipoPess.Residente = dataReader["RESIDENTE"].Equals("1");
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
                    "INSERT INTO TIPOPESSOA ( ENDERECO, RESIDENTE ) VALUES ( @endereco, @resid ) ";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.Add("@endereco", SqlDbType.Text);
                command.Parameters["@endereco"].Value = tipoPessoa.Endereco;
                command.Parameters.Add("@redid", SqlDbType.Text);
                command.Parameters["@resid"].Value = Convert.ToInt32(tipoPessoa.Residente);

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
                    "UPDATE TIPOPESSOA SET ENDERECO = @endereco , RESIDENTE = @resid WHERE IDTIPO = @id  ";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.Add("@endereco", SqlDbType.Text);
                command.Parameters.Add("@resid", SqlDbType.Text);
                command.Parameters.Add("@id", SqlDbType.Int);
                command.Parameters["@endereco"].Value = tipoPessoa.Endereco;
                command.Parameters["@resid"].Value = Convert.ToInt32(tipoPessoa.Residente);
                command.Parameters["@id"].Value = tipoPessoa.IdTipo;

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