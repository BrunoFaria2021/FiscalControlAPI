using FiscalControl.Application.ViewModel;
using FiscalControl.CrossCutting.Extensions;

namespace FiscalControl.Application.Interfaces
{
    public interface IReceitaAppService
    {
        RetornoApi<List<ReceitaViewModel>> BuscarTodasReceitasPorUsuario(Guid usuarioId);
        RetornoApi<ReceitaViewModel> BuscarReceita(Guid id);
        RetornoApi<ReceitaViewModel> CriarReceita(ReceitaViewModel receita);
        RetornoApi<ReceitaViewModel> EditarReceita(Guid id, ReceitaViewModel receita);
        RetornoApi<ReceitaViewModel> DeletarReceita(Guid id);
    }
}
