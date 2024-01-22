using FiscalControl.CrossCutting.Extensions;
using FiscalControl.Domain.Entities;

namespace FiscalControl.Infra.Data.Interfaces
{
    public interface IContaBancariaRepository
    {
        RetornoApi<List<ContaBancaria>> BuscarTodasContasBancariasPorUsuario(Guid usuarioId);
        RetornoApi<ContaBancaria> BuscarContaBancaria(Guid id, Guid usuarioId);
        RetornoApi<ContaBancaria> CriarContaBancaria(ContaBancaria contaBancaria);
        RetornoApi<ContaBancaria> EditarContaBancaria(Guid id, Guid usuarioId, ContaBancaria contaBancaria);
        RetornoApi<bool> DeletarContaBancaria(Guid id, Guid usuarioId);
    }
}
