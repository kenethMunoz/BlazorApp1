using BlazorApp1.Data;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;




namespace BlazorApp1.Repositorio
{
    public class ClienteRepositorio : IRepositorioCliente
    {
        private string _connectionString;
        public ClienteRepositorio(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("SQL");
        }
        private SqlConnection conexion()
        {
            return new SqlConnection(_connectionString);
        }
        public Task<bool> GuardarCliente(Cliente cliente)
        {
            bool clienteCreado = false;
            SqlConnection sqlConnection = conexion();
            SqlCommand comm = null;

            try
            {
                sqlConnection.Open();
                comm = sqlConnection.CreateCommand();
                comm.CommandText = "SP_INS_Cliente";
                comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.Add("@nombre", SqlDbType.NVarChar, 200);
                comm.Parameters.Add("@email", SqlDbType.NVarChar, 200);
                comm.Parameters.Add("@Telefono", SqlDbType.NVarChar, 12);
                comm.Parameters.Add("@FechaAlta", SqlDbType.DateTime);

                await comm.ExecuteNonQueryAsync();
                clienteCreado = true;


            }
            catch (SqlException error)
            {
                throw new Exception("Error guardando el cliente " + error.Message);


            }
            finally
            {
                comm.Dispose();
            }

        }
    }
        
       
 
}
