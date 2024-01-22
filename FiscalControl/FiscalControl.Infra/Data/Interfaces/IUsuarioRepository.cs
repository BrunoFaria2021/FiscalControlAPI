using FiscalControl.CrossCutting.Extensions;
using FiscalControl.Domain.Entities;

namespace FiscalControl.Infra.Data.Interfaces
{
    public interface IUsuarioRepository
    {
        RetornoApi<List<Usuario>> BuscarTodosUsuarios();
        RetornoApi<Usuario> BuscarUsuario(Guid id);
        RetornoApi<Usuario> CriarUsuario(Usuario usuario);
        RetornoApi<Usuario> EditarUsuario(Guid id, Usuario usuario);
        RetornoApi<Usuario> DeletarUsuario(Guid id);
    }
}
