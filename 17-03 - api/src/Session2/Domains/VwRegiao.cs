using System;
using System.Collections.Generic;

#nullable disable

namespace Session2.Domains
{
    public partial class VwRegiao
    {
        public int Id { get; set; }
        public string Regiao { get; set; }
        public double? Total { get; set; }
        public int? Vendas { get; set; }
    }
}
