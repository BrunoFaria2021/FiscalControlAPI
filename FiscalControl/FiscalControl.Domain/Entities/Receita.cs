using System.ComponentModel.DataAnnotations.Schema;

namespace FiscalControl.Domain.Entities
{
    public class Receita
    {
        public Guid Id { get; set; }
        public decimal Valor { get; set; }
        public DateTime Data { get; set; }

        //(Relação de muitos para um)
        [ForeignKey("CategoriaId")]
        public Guid CategoriaId { get; set; }
        public virtual Categoria Categoria { get; set; }

        //(Relação de muitos para um)
        [ForeignKey("UsuarioId")]
        public Guid UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}