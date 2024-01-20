namespace FiscalControl.Domain.Entities
{
    public class Usuario
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        // Relação de um para muitos
        public virtual List<MetaEconomica>? MetaEconomicas { get; set; }
        public virtual List<Receita> ReceitasEntrada { get; set; }
        public virtual List<Cartao> Cartoes { get; set; }
        public virtual List<ContaBancaria> ContasBancarias { get; set; }
        public virtual List<Despesa> Despesas { get; set; }
        public virtual List<Investimento> Investimentos { get; set; }
        public virtual List<Transacao> Transacoes { get; set; }
        public virtual List<Receita> ReceitasEntrada { get; set; }
        public virtual List<Receita> ReceitasEntrada { get; set; }
    }
}
