using FiscalControl.CrossCutting.Extensions;
using FiscalControl.Domain.Entities;

namespace FiscalControl.Infra.Data.Interfaces
{
    public interface IAutenticacaoRepository
    {
        RetornoApi<Usuario> BuscarUsuarioPorEmail(string login);
        RetornoApi<RefreshToken> BuscarRefreshToken(Guid usuarioId);
        RetornoApi<RefreshToken> SalvarRefreshToken(RefreshToken refreshToken);
        RetornoApi<RefreshToken> AtualizarRefreshToken(RefreshToken refreshToken);
    }
}
