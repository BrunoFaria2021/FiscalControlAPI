using FiscalControl.Application.DTO;
using FiscalControl.Application.ViewModel;
using FiscalControl.CrossCutting.Extensions;

namespace FiscalControl.Application.Interfaces
{
    public interface IAutenticacaoAppService
    {
        Task<RetornoApi<AutenticacaoViewModel>> Login(LoginDTO loginDTO);

        RetornoApi<TokenAcesso> RefreshToken(string refreshToken);
    }
}
