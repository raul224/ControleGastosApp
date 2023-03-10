using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Entidades;

namespace Dominio.Services
{
    public class ClientesService : IClientesService
    {
        private readonly IClientesService _clientesService;

        public ClientesService(IClientesService clientesService)
        {
            _clientesService = clientesService;
        }
        public List<Lancamento> GetLancamentos(int id)
        {
            throw new NotImplementedException();
        }

        public Cliente GetSaldo(int clientId)
        {
            throw new NotImplementedException();
        }
    }
}
