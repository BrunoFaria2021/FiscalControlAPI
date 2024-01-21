using FiscalControl.Application.ViewModel;
using FiscalControl.CrossCutting.Extensions;

namespace FiscalControl.Application.Interfaces
{
    public interface IMetaEconomicaAppService
    {
        RetornoApi<List<MetaEconomicaViewModel>> BuscarTodasMetasEconomicasPorUsuario(Guid usuarioId);
        RetornoApi<MetaEconomicaViewModel> BuscarMetaEconomica(Guid id);
        RetornoApi<MetaEconomicaViewModel> CriarMetaEconomica(MetaEconomicaViewModel metaEconomica);
        RetornoApi<MetaEconomicaViewModel> EditarMetaEconomica(Guid id, MetaEconomicaViewModel metaEconomica);
        RetornoApi<MetaEconomicaViewModel> DeletarMetaEconomica(Guid id);
    }
}

