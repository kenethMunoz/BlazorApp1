namespace BlazorApp1.Data
{
    public class SqlConfiguration
    {
        private string _connectionString;
        public string ConnectionString { get => _connectionString; }
        public SqlConfiguration(string conexion) { 
            _connectionString = conexion;   
        }
    }
}
