using FiscalControl.Application.ViewModel;
using FiscalControl.CrossCutting.Extensions;

namespace FiscalControl.Application.Interfaces
{
    public interface ICategoriaAppService
    {
        RetornoApi<List<CategoriaViewModel>> BuscarTodasCategorias();
        RetornoApi<CategoriaViewModel> BuscarCategoria(Guid id);
        RetornoApi<CategoriaViewModel> CriarCategoria(CategoriaViewModel categoria);
        RetornoApi<CategoriaViewModel> EditarCategoria(Guid id, CategoriaViewModel categoria);
        RetornoApi<CategoriaViewModel> DeletarCategoria(Guid id);
    }
}
