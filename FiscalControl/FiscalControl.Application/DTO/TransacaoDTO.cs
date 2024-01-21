using FiscalControl.CrossCutting.Util.Enum;

namespace FiscalControl.Application.DTO
{
    public class TransacaoDTO
    {
        public Guid Id { get; set; }
        public decimal Valor { get; set; }
        public DateTime Data { get; set; }

        // Adicionando o tipo de transação usando o EnumTipoTransacao
        public EnumTipoTransacao Tipo { get; set; }

        // Adicionando dados da Despesa (se necessário)
        public DespesaDTO Despesa { get; set; }

        // Adicionando dados do usuário (se necessário)
        public UsuarioDTO Usuario { get; set; }
    }
}
