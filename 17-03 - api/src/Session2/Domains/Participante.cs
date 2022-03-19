using System;
using System.Collections.Generic;

#nullable disable

namespace Session2.Domains
{
    public partial class Participante
    {
        public Participante()
        {
            ParticipantesEventos = new HashSet<ParticipantesEvento>();
            Venda = new HashSet<Venda>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public double? Idade { get; set; }
        public int? CidadeId { get; set; }
        public string Genero { get; set; }

        public virtual Cidade Cidade { get; set; }
        public virtual ICollection<ParticipantesEvento> ParticipantesEventos { get; set; }
        public virtual ICollection<Venda> Venda { get; set; }
    }
}
