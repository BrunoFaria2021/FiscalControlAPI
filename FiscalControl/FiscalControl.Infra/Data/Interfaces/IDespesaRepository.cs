using FiscalControl.CrossCutting.Extensions;
using FiscalControl.Domain.Entities;

namespace FiscalControl.Infra.Data.Interfaces
{
    public interface IDespesaRepository
    {
        RetornoApi<List<Despesa>> BuscarTodasDespesasPorUsuario(Guid usuarioId);
        RetornoApi<Despesa> BuscarDespesa(Guid id, Guid usuarioId);
        RetornoApi<Despesa> CriarDespesa(Despesa despesa);
        RetornoApi<Despesa> EditarDespesa(Guid id, Guid usuarioId, Despesa despesa);
        RetornoApi<bool> DeletarDespesa(Guid id, Guid usuarioId);
    }
}
