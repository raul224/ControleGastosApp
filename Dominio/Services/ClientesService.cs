using Dominio.Entidades;
using Dominio.IRepositorios;

namespace Dominio.Services
{
    public class ClientesService : IClientesService
    {
        private readonly IClientesRepositorio _clientesRepositorio;

        public ClientesService(IClientesRepositorio clientesRepositorio)
        {
            _clientesRepositorio = clientesRepositorio;
        }
        

       
        
        

        public async Task<Cliente> GetCliente(string clientId)
        {
            return await _clientesRepositorio.GetClienteAsync(clientId);
        }
    }
}
