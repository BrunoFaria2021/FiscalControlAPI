using FiscalControl.CrossCutting.Extensions;
using FiscalControl.Domain.Entities;

namespace FiscalControl.Infra.Data.Interfaces
{
    public interface ICartaoRepository
    {
        RetornoApi<List<Cartao>> BuscarTodosCartoesPorUsuario(Guid usuarioId);
        RetornoApi<Cartao> BuscarCartao(Guid id, Guid usuarioId);
        RetornoApi<Cartao> CriarCartao(Cartao cartao);
        RetornoApi<Cartao> EditarCartao(Guid id, Guid usuarioId, Cartao cartao);
        RetornoApi<bool> DeletarCartao(Guid id, Guid usuarioId);
    }
}
