using FiscalControl.Application.DTO;
using FiscalControl.Application.ViewModel;
using FiscalControl.CrossCutting.Extensions;

namespace FiscalControl.Application.Interfaces
{
    public interface IUsuarioAppService
    {
        Task<RetornoApi<List<UsuarioViewModel>>> BuscarTodosUsuarios();
        Task<RetornoApi<UsuarioViewModel>> BuscarUsuario(Guid id);
        Task<RetornoApi<UsuarioViewModel>> CriarUsuario(UsuarioDTO usuarioDTO);
        Task<RetornoApi<UsuarioViewModel>> EditarUsuario(Guid id, UsuarioDTO usuarioDTO);
        Task<RetornoApi<UsuarioViewModel>> DeletarUsuario(Guid id);
    }
}
