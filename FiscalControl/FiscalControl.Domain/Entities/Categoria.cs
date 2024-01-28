using FiscalControl.CrossCutting.Util.Enum;
using System.ComponentModel.DataAnnotations.Schema;

namespace FiscalControl.Domain.Entities
{
    public class Categoria
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public EnumTipoCategoria Tipo { get; set; }
        //public string NomePersonalizado { get; set; }


        [ForeignKey("UsuarioId")]
        public Guid UsuarioId { get; set; }
        public  Usuario Usuario { get; set; }
        public List<Receita> Receitas { get; set; } = new List<Receita>();

    }
}
