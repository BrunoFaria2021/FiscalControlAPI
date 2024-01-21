using FiscalControl.Application.ViewModel;
using FiscalControl.CrossCutting.Extensions;

namespace FiscalControl.Application.Interfaces
{
    public interface IContaBancariaAppService
    {
        RetornoApi<List<ContaBancariaViewModel>> BuscarTodasContasBancariasPorUsuario(Guid usuarioId);
        RetornoApi<ContaBancariaViewModel> BuscarContaBancaria(Guid id);
        RetornoApi<ContaBancariaViewModel> CriarContaBancaria(ContaBancariaViewModel contaBancaria);
        RetornoApi<ContaBancariaViewModel> EditarContaBancaria(Guid id, ContaBancariaViewModel contaBancaria);
        RetornoApi<ContaBancariaViewModel> DeletarContaBancaria(Guid id);
    }
}
