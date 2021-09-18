using System;
using System.Configuration;
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
        public virtual DbSet<Tenant> Tenant { get; set; }
        public virtual DbSet<Spedizione> Spedizioni { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //D Destra | S Sinistra | E Entrambi
            modelBuilder.Entity<Ordine>(e => e.HasCheckConstraint("CK_DATI_Ventilazione", "Ventilazione in ('D','S','E','N')"));
            modelBuilder.Entity<Ordine>(e => e.HasCheckConstraint("CK_Utente_Molle", "Molle in ('D','S','E','N')"));
            modelBuilder.Entity<Ordine>(e => e.HasCheckConstraint("CK_Utente_Cedevole", "Cedevole in ('D','S','E','N')"));
            modelBuilder.Entity<Ordine>(e => e.HasCheckConstraint("CK_Utente_Normale", "Normale in ('D','S','E','N')"));


            //Guid valori default
            modelBuilder.Entity<Ordine>().Property(p => p.Id).HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<Cliente>().Property(p => p.Id).HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<Tenant>().Property(p => p.Id).HasDefaultValueSql("NEWID()");

            //Cardinalità
            modelBuilder.Entity<Tenant>()
                .HasMany(x => x.Spedizioni)
                .WithOne(x => x.tenant);
        }
    }
}
