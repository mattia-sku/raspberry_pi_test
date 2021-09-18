using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebServerCloud.Models
{
    public class Spedizione
    {
        public Guid Id { get; set; }
        public string Indirizzo { get; set; }
        public string CAP { get; set; }
        public string Citta { get; set; }
        public string Provincia { get; set; }
        public Tenant tenant { get; set; }
        public Guid tenantId { get; set; }
    }
}
