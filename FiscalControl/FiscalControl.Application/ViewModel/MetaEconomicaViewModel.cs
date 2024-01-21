namespace FiscalControl.Application.ViewModel
{
    public class MetaEconomicaViewModel
    {
        public Guid Id { get; set; }
        public decimal ValorMeta { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFinal { get; set; }

        // Adicionando dados do usuário (se necessário)
        public UsuarioViewModel Usuario { get; set; }
    }
}
