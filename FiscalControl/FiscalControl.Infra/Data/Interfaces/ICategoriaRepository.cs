using FiscalControl.CrossCutting.Extensions;
using FiscalControl.Domain.Entities;

namespace FiscalControl.Infra.Data.Interfaces
{
    public interface ICategoriaRepository
    {
        RetornoApi<List<Categoria>> BuscarTodasCategorias();
        RetornoApi<Categoria> BuscarCategoria(Guid id);
        RetornoApi<Categoria> CriarCategoria(Categoria categoria);
        RetornoApi<Categoria> EditarCategoria(Guid id, Categoria categoria);
        RetornoApi<bool> DeletarCategoria(Guid id);
    }
}
