using FiscalControl.CrossCutting.Util.Enum;

namespace FiscalControl.Application.ViewModel
{
    public class TransacaoViewModel
    {
        public Guid Id { get; set; }
        public decimal Valor { get; set; }
        public DateTime Data { get; set; }
        public EnumTipoTransacao Tipo { get; set; }

        // Adicionando dados da Despesa (se necessário)
        public DespesaViewModel Despesa { get; set; }

        // Adicionando dados do usuário (se necessário)
        public UsuarioViewModel Usuario { get; set; }
    }
}
