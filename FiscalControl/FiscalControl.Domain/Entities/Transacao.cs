using System.ComponentModel.DataAnnotations.Schema;

namespace FiscalControl.Domain.Entities
{
    public class Transacao
    {
        public Guid Id { get; set; }
        public decimal Valor { get; set; }
        public DateTime Data { get; set; }
        public string Tipo { get; set; } // Entrada ou Saída

        // Chave estrangeira para ContaBancaria (Relação de muitos para um)
        [ForeignKey("ContaBancariaId")]
        public Guid ContaBancariaId { get; set; }
        public virtual ContaBancaria ContaBancaria { get; set; }

        // Chave estrangeira para Usuario (Relação de muitos para um)
        [ForeignKey("UsuarioId")]
        public Guid UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
