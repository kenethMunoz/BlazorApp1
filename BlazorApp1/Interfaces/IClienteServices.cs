using BlazorApp1.Data;

namespace BlazorApp1.Interfaces
{
    public interface IClienteServices
    {
        Task<bool> GuardarCliente(Cliente cliente);
    }
}
