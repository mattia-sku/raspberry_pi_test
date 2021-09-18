using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebServerCloud.Models
{
    public class Cliente
    {
        public Guid Id { get; set; }
        public string Iniziali { get; set; }
        public bool PrimoPortatore { get; set; }
        public DateTime DataNascita { get; set; }
        public char Normale { get; set; }
        public char Cedevole { get; set; }
        public char Molle { get; set; }
        public string Note { get; set; }
    }
}
