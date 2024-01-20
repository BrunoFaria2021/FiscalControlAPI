using System.ComponentModel.DataAnnotations.Schema;

namespace FiscalControl.Domain.Entities
{
    public class MetaEconomica
    {
        public Guid Id { get; set; }
        public decimal ValorMeta { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFinal { get; set; }

        // Chave estrangeira para Usuario (Relação de muitos para um)
        [ForeignKey("UsuarioId")]
        public Guid UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
