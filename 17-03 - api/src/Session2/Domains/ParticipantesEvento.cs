using System;
using System.Collections.Generic;

#nullable disable

namespace Session2.Domains
{
    public partial class ParticipantesEvento
    {
        public int Id { get; set; }
        public int? EventoId { get; set; }
        public int? ParticipanteId { get; set; }

        public virtual Evento Evento { get; set; }
        public virtual Participante Participante { get; set; }
    }
}
