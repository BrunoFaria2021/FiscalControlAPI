using FiscalControl.Application.ViewModel;
using FiscalControl.CrossCutting.Extensions;

namespace FiscalControl.Application.Interfaces
{
    public interface IDespesaAppService
    {
        RetornoApi<List<DespesaViewModel>> BuscarTodasDespesasPorUsuario(Guid usuarioId);
        RetornoApi<DespesaViewModel> BuscarDespesa(Guid id);
        RetornoApi<DespesaViewModel> CriarDespesa(DespesaViewModel despesa);
        RetornoApi<DespesaViewModel> EditarDespesa(Guid id, DespesaViewModel despesa);
        RetornoApi<DespesaViewModel> DeletarDespesa(Guid id);
    }
}
