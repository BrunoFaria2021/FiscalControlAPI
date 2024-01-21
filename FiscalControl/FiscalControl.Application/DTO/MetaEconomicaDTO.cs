namespace FiscalControl.Application.DTO
{
    public class MetaEconomicaDTO
    {
        public decimal ValorMeta { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFinal { get; set; }

        // Adicionando dados do usuário (se necessário)
        public UsuarioDTO Usuario { get; set; }
    }
}
