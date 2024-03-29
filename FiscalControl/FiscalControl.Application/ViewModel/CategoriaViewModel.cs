﻿using FiscalControl.CrossCutting.Util.Enum;

namespace FiscalControl.Application.ViewModel
{
    public class CategoriaViewModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public EnumTipoCategoria Tipo { get; set; }
    }
}
