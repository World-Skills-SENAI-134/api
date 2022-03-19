using System;
using System.Collections.Generic;

#nullable disable

namespace Session2.Domains
{
    public partial class Evento
    {
        public Evento()
        {
            ParticipantesEventos = new HashSet<ParticipantesEvento>();
            Venda = new HashSet<Venda>();
        }

        public int Id { get; set; }
        public string Evento1 { get; set; }
        public int? TipoEventoId { get; set; }

        public virtual TipoEvento TipoEvento { get; set; }
        public virtual ICollection<ParticipantesEvento> ParticipantesEventos { get; set; }
        public virtual ICollection<Venda> Venda { get; set; }
    }
}
