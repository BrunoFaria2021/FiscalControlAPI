using FiscalControl.CrossCutting.Extensions;
using FiscalControl.Domain.Entities;

namespace FiscalControl.Infra.Data.Interfaces
{
    public interface ITransacaoRepository
    {
        RetornoApi<List<Transacao>> BuscarTodasTransacoesPorUsuario(Guid usuarioId);
        RetornoApi<Transacao> BuscarTransacao(Guid id, Guid usuarioId);
        RetornoApi<Transacao> CriarTransacao(Transacao transacao);
        RetornoApi<Transacao> EditarTransacao(Guid id, Guid usuarioId, Transacao transacao);
        RetornoApi<bool> DeletarTransacao(Guid id, Guid usuarioId);
    }
}
