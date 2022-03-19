using System;
using System.Collections.Generic;

#nullable disable

namespace Session2.Domains
{
    public partial class TipoEvento
    {
        public TipoEvento()
        {
            Eventos = new HashSet<Evento>();
        }

        public int Id { get; set; }
        public string Tipoevento1 { get; set; }

        public virtual ICollection<Evento> Eventos { get; set; }
    }
}
