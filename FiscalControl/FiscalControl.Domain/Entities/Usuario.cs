using System.ComponentModel.DataAnnotations;

namespace FiscalControl.Domain.Entities
{
    public class Usuario
    {
        [Key]
        public Guid Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Senha { get; set; } = string.Empty;

        // Relação de um para muitos
        public virtual List<Cartao> Cartoes { get; set; } = new List<Cartao>();
        public virtual List<Transacao> Transacoes { get; set; } = new List<Transacao>();
        public virtual List<Despesa> Despesas { get; set; } = new List<Despesa>();
        public  List<Receita> ReceitasEntrada { get; set; } = new List<Receita>();
        public virtual List<MetaEconomica> MetasEconomicas { get; set; } = new List<MetaEconomica>();
        public virtual List<ContaBancaria> ContasBancarias { get; set; } = new List<ContaBancaria>();
    }
}

