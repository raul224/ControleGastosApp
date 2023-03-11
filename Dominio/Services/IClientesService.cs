﻿using Dominio.Entidades;

namespace Dominio.Services;

public interface IClientesService
{
    List<Lancamento> GetLancamentos(int id);
    Cliente GetCliente(int clientId);
}