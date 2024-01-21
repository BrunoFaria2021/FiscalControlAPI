using FiscalControl.CrossCutting.Util.Enum;
using System.ComponentModel.DataAnnotations.Schema;

namespace FiscalControl.Domain.Entities
{
    public class Transacao
    {
        public Guid Id { get; set; }
        public decimal Valor { get; set; }
        public DateTime Data { get; set; }
        public EnumTipoTransacao Tipo { get; set; }
        [ForeignKey("UsuarioId")]
        public Guid UsuarioId { get; set; }
        public virtual Usuario? Usuario { get; set; }
        [ForeignKey("DespesaId")]
        public Guid DespesaId { get; set; }
        public virtual Despesa? Despesa { get; set; }
    }
}
