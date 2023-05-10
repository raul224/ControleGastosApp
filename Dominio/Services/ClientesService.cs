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
        public async Task<IEnumerable<Lancamento>> GetLancamentos(string id)
        {
            return await _clientesRepositorio.GetLancamentosAsync(id);
        }

        public Task<IEnumerable<Lancamento>> GetLancamentosComFiltro(DateTime dataInicio, DateTime dataFim)
        {
            return _clientesRepositorio.GetLancamentosComFiltroAsync(dataInicio, dataFim);
        }
        
        public async Task CadastraLancamento(Lancamento lancamento)
        {
            await _clientesRepositorio.cadastraLancamentoAsync(lancamento);
        }

        public async Task<Cliente> GetCliente(string clientId)
        {
            return await _clientesRepositorio.GetClienteAsync(clientId);
        }
    }
}
