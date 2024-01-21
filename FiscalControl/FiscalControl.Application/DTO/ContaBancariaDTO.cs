using FiscalControl.CrossCutting.Util.Enum;

namespace FiscalControl.Application.DTO
{
    public class ContaBancariaDTO
    {
        public Guid Id { get; set; }
        public decimal Saldo { get; set; }

        // Adicionando o tipo de conta bancária usando o EnumTipoContaBancaria
        public EnumTipoContaBancaria Tipo { get; set; }

        // Adicionando dados do usuário (se necessário)
        public UsuarioDTO Usuario { get; set; }
    }
}
