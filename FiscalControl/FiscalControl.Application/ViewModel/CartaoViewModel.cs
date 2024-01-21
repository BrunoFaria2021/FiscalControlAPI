namespace FiscalControl.Application.ViewModel
{
    public class CartaoViewModel
    {
        public Guid Id { get; set; }
        public string Numero { get; set; }
        public DateTime DataExpiracao { get; set; }
        public string CodigoSeguranca { get; set; }

        // Adicionando dados do usuário (se necessário)
        public UsuarioViewModel Usuario { get; set; }
    }
}
