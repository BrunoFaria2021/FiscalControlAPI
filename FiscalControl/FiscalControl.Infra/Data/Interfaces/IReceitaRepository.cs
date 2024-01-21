using FiscalControl.CrossCutting.Extensions;
using FiscalControl.Domain.Entities;

namespace FiscalControl.Infra.Data.Interfaces
{
    public interface IReceitaRepository
    {
        RetornoApi<List<Receita>> BuscarTodasReceitasPorUsuario(Guid usuarioId);
        RetornoApi<Receita> BuscarReceita(Guid id, Guid usuarioId);
        RetornoApi<Receita> CriarReceita(Receita receita);
        RetornoApi<Receita> EditarReceita(Guid id, Guid usuarioId, Receita receita);
        RetornoApi<bool> DeletarReceita(Guid id, Guid usuarioId);
    }

}
