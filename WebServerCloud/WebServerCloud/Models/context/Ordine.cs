using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebServerCloud.Models
{
    public class Ordine
    {
        public Guid Id { get; set; }
        public Anagrafica AudioProtesista { get; set; }
        public Anagrafica Spedizione { get; set; }
        public UtenteProtesi UtenteProtesi { get; set; }
        public byte[] Video { get; set; }
        public DateTime DataCaricamento { get; set; }
    }
}
