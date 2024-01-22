using FiscalControl.CrossCutting.Util.Enum;
using System.ComponentModel.DataAnnotations.Schema;

namespace FiscalControl.Domain.Entities
{
    public class ContaBancaria
    {
        public Guid Id { get; set; }
        public decimal Saldo { get; set; }
        public EnumTipoContaBancaria Tipo { get; set; }

        // Chave estrangeira para Usuario (Relação de muitos para um)
        [ForeignKey("UsuarioId")]
        public Guid UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }

        
        public virtual List<Despesa> Despesas { get; set; } = new List<Despesa>();
        public List<Receita> ReceitasEntrada { get; set; } = new List<Receita>();
        public virtual List<Transacao> Transacoes { get; set; } = new List<Transacao>();
    }
}
