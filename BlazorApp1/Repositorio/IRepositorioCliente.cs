using BlazorApp1.Data;

namespace BlazorApp1.Repositorio
{
    public interface IRepositorioCliente
    {


         Task<bool> GuardarCliente(Cliente cliente);
    }
}
