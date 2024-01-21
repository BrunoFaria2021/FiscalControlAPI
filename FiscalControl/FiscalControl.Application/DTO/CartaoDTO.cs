namespace FiscalControl.Application.DTO
{
    public class CartaoDTO
    {
        public string Numero { get; set; } = string.Empty;
        public DateTime DataExpiracao { get; set; }
        public string CodigoSeguranca { get; set; }
        public Guid UsuarioId { get; set; }
        public UsuarioDTO Usuario { get; set; }
    }
}
