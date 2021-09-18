using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebServerCloud.Models
{
    public class Tenant
    {
        public Guid Id { get; set; }
        public string RagioneSociale { get; set; }
        public string Cellulare { get; set; }
        public string Mail { get; set; }
        public string stampante { get; set; }
        public ICollection<Spedizione> Spedizioni { get; set; }
    }
}
