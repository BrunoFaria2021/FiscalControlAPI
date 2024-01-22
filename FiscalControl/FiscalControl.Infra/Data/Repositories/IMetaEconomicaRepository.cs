using FiscalControl.CrossCutting.Extensions;
using FiscalControl.Domain.Entities;

namespace FiscalControl.Infra.Data.Interfaces
{
    public interface IMetaEconomicaRepository
    {
        RetornoApi<List<MetaEconomica>> BuscarTodasMetasEconomicasPorUsuario(Guid usuarioId);
        RetornoApi<MetaEconomica> BuscarMetaEconomica(Guid id, Guid usuarioId);
        RetornoApi<MetaEconomica> CriarMetaEconomica(MetaEconomica metaEconomica);
        RetornoApi<MetaEconomica> EditarMetaEconomica(Guid id, Guid usuarioId, MetaEconomica metaEconomica);
        RetornoApi<bool> DeletarMetaEconomica(Guid id, Guid usuarioId);
    }
}
