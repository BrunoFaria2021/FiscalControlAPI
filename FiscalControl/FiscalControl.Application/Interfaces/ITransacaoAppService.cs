using FiscalControl.Application.ViewModel;
using FiscalControl.CrossCutting.Extensions;

namespace FiscalControl.Application.Interfaces
{
    public interface ITransacaoAppService
    {
        RetornoApi<List<TransacaoViewModel>> BuscarTodasTransacoesPorUsuario(Guid usuarioId);
        RetornoApi<TransacaoViewModel> BuscarTransacao(Guid id);
        RetornoApi<TransacaoViewModel> CriarTransacao(TransacaoViewModel transacao);
        RetornoApi<TransacaoViewModel> EditarTransacao(Guid id, TransacaoViewModel transacao);
        RetornoApi<TransacaoViewModel> DeletarTransacao(Guid id);
    }
}
