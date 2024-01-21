using FiscalControl.CrossCutting.Util.Enum;

namespace FiscalControl.Application.ViewModel
{
    public class ContaBancariaViewModel
    {
        public Guid Id { get; set; }
        public decimal Saldo { get; set; }
        public EnumTipoContaBancaria Tipo { get; set; }

        // Adicionando dados do usuário (se necessário)
        public UsuarioViewModel Usuario { get; set; }
    }
}
