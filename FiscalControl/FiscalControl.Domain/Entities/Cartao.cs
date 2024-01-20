using System.ComponentModel.DataAnnotations.Schema;

namespace FiscalControl.Domain.Entities
{
    public class Cartao
    {
        public Guid Id { get; set; }
        public string Numero { get; set; }
        public DateTime DataExpiracao { get; set; }
        public string CodigoSeguranca { get; set; }
        // Chave estrangeira para Usuario (Relação de um para um)
        [ForeignKey("UsuarioId")]
        public Guid UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
