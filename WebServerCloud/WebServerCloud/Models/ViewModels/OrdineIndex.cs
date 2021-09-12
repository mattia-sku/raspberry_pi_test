using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebServerCloud.Models.ViewModels
{
    public class OrdineIndex
    {
        public Guid OrderId { get; set; }
        public string RagioneSociale { get; set; }
        public DateTime DataCaricamento { get; set; }
    }
}
