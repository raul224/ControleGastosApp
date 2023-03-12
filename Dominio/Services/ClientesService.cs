using System.Linq;
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
        public List<Lancamento> GetLancamentos(int id)
        {
            return _clientesRepositorio.GetLancamentos(id).ToList();
        }

        public async Task CadastraLancamento(Lancamento lancamento)
        {
            await _clientesRepositorio.cadastraLancamento(lancamento);
        }

        public Cliente GetCliente(int clientId)
        {
            return _clientesRepositorio.GetCliente(clientId);
        }
    }
}
