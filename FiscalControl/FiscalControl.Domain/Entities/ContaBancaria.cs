using System.ComponentModel.DataAnnotations.Schema;

namespace FiscalControl.Domain.Entities
{
    public class ContaBancaria
    {
        public Guid Id { get; set; }
        public decimal Saldo { get; set; }
        public string Tipo { get; set; }

        // Chave estrangeira para Usuario (Relação de muitos para um)
        [ForeignKey("UsuarioId")]
        public Guid UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
