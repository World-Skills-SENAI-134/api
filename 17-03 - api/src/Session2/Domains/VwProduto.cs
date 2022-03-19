using System;
using System.Collections.Generic;

#nullable disable

namespace Session2.Domains
{
    public partial class VwProduto
    {
        public int Id { get; set; }
        public double? Total { get; set; }
        public string Produto { get; set; }
        public double? Valor { get; set; }
    }
}
