namespace FiscalControl.Application.DTO
{
    public class ReceitaDTO
    {
        public decimal Valor { get; set; }
        public DateTime Data { get; set; }
        public Guid CategoriaId { get; set; }
        public CategoriaDTO Categoria { get; set; }
        public Guid UsuarioId { get; set; }
        public UsuarioDTO Usuario { get; set; }
    }
}
