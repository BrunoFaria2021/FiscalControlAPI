using FiscalControl.CrossCutting.Util.Enum;

namespace FiscalControl.Domain.Entities
{
    public class Categoria
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public EnumTipoCategoria Tipo { get; set; }
    }
}
