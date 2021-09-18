using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebServerCloud.Models
{
    public class Ordine
    {
        //Header
        public Guid Id { get; set; }
        public Tenant AudioProtesista { get; set; }
        public Guid AudioProtesistaId { get; set; }
        public Spedizione Spedizione { get; set; }
        public Guid SpedizioneId { get; set; }
        public string VideoName { get; set; }
        public DateTime DataCaricamento { get; set; }

        //Dati Cliente
        public string Cliente_Iniziali { get; set; }
        public bool Cliente_PrimoPortatore { get; set; }
        public DateTime Cliente_DataNascita { get; set; }

        //Dati Protesi
        public char Ventilazione { get; set; }
        public char Normale { get; set; }
        public char Cedevole { get; set; }
        public char Molle { get; set; }
        public char MiniFit_Lato { get; set; }
        public int MiniFit_Fitting { get; set; }
        public string MiniFit_Mould { get; set; }
        public string MiniFit_Tip { get; set; }
        public char PFM_Lato { get; set; }
        public int PFM_Fitting { get; set; }
        public string PFM_Versione { get; set; }
        public string PFM_Wire { get; set; }
        //Misc
        public string Note { get; set; }
    }
}
