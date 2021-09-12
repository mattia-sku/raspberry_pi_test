using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebServerCloud.Models;

namespace WebServerCloud.Data
{
    public class WebServerCloudContext : DbContext
    {
        public WebServerCloudContext (DbContextOptions<WebServerCloudContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Ordine> ordini { get; set; }
        public virtual DbSet<UtenteProtesi> utentiProtesi { get; set; }
        public virtual DbSet<DatiProtesi> datiProtesi { get; set; }
        public virtual DbSet<Anagrafica> anagrafiche { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //D Destra | S Sinistra | E Entrambi
            modelBuilder.Entity<DatiProtesi>(e => e.HasCheckConstraint("CK_DATI_OTICON", "Oticon in ('D','S','E')"));
            modelBuilder.Entity<DatiProtesi>(e => e.HasCheckConstraint("CK_DATI_Ventilazione", "Ventilazione in ('D','S','E')"));
            modelBuilder.Entity<UtenteProtesi>(e => e.HasCheckConstraint("CK_Utente_Molle", "Molle in ('D','S','E')"));
            modelBuilder.Entity<UtenteProtesi>(e => e.HasCheckConstraint("CK_Utente_Cedevole", "Cedevole in ('D','S','E')"));
            modelBuilder.Entity<UtenteProtesi>(e => e.HasCheckConstraint("CK_Utente_Normale", "Normale in ('D','S','E')"));
        }

    }
}
