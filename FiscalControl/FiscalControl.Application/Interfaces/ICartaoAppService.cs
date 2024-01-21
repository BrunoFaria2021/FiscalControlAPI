using FiscalControl.Application.ViewModel;
using FiscalControl.CrossCutting.Extensions;

namespace FiscalControl.Application.Interfaces
{
    public interface ICartaoAppService
    {
        RetornoApi<List<CartaoViewModel>> BuscarTodosCartoesPorUsuario(Guid usuarioId);
        RetornoApi<CartaoViewModel> BuscarCartao(Guid id);
        RetornoApi<CartaoViewModel> CriarCartao(CartaoViewModel cartao);
        RetornoApi<CartaoViewModel> EditarCartao(Guid id, CartaoViewModel cartao);
        RetornoApi<CartaoViewModel> DeletarCartao(Guid id);
    }
}
