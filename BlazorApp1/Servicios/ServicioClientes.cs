using BlazorApp1.Data;
using BlazorApp1.Interfaces;
using BlazorApp1.Repositorio;

namespace BlazorApp1.Servicios
{
    public class ServicioClientes:IClienteServices
    {
        private IRepositorioCliente clienteRepositorio;
        private SqlConfiguration configuracion;


        public ServicioClientes(SqlConfiguration c) {
            configuracion = c;
            clienteRepositorio = new ClienteRepositorio(configuracion.ConnectionString);
        }
        public Task<bool> GuardarCliente(Cliente cliente) => (cliente.Id == 0) ? clienteRepositorio.GuardarCliente(cliente) : null;



    }
}
