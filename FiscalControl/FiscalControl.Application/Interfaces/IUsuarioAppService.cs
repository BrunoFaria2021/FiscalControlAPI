using FiscalControl.Application.ViewModel;
using FiscalControl.CrossCutting.Extensions;

namespace FiscalControl.Application.Interfaces
{
    public interface IUsuarioAppService
    {
        RetornoApi<List<UsuarioViewModel>> BuscarTodosUsuarios();
        RetornoApi<UsuarioViewModel> BuscarUsuario(Guid id);
        RetornoApi<UsuarioViewModel> CriarUsuario(UsuarioViewModel usuario);
        RetornoApi<UsuarioViewModel> EditarUsuario(Guid id, UsuarioViewModel usuario);
        RetornoApi<bool> DeletarUsuario(Guid id);
    }
}
