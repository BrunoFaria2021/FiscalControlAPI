namespace FiscalControl.Application.ViewModel
{
    public class DespesaViewModel
    {
        public Guid Id { get; set; }
        public decimal Valor { get; set; }
        public DateTime Data { get; set; }

        // Adicionando dados da Categoria (se necessário)
        public CategoriaViewModel Categoria { get; set; }

        // Adicionando dados do usuário (se necessário)
        public UsuarioViewModel Usuario { get; set; }
    }
}
