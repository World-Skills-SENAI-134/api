using System;
using System.Collections.Generic;

#nullable disable

namespace Session2.Domains
{
    public partial class VwRank
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public double? Idade { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public double? Pontos { get; set; }
        public string Sigla { get; set; }
    }
}
