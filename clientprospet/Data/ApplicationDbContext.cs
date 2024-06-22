using clientprospet.models;
using clientprospet.Models;
using Microsoft.EntityFrameworkCore;
namespace clientprospet.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<ClientProspet> ClientProspets { get; set; }
        public DbSet<Adresse> Adresses { get; set; }
        public DbSet<MobileClient> mobiles { get; set; }
        public DbSet<Documents> Documents { get; set; }
        
        public DbSet<MailClient> MailClient { get; set; }
        public DbSet<FATCA> FATCA { get; set; }
        public DbSet<CIN> CIN { get; set; }
        public DbSet<choixagence> ChoixAgences { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ClientProspet>()
              .HasMany(cp => cp.Adresses)// Relation "un-à-plusieurs"
              .WithOne(a => a.ClientProspet) // Navigation property dans Adresse
              .HasForeignKey(a => a.ClientId) // Clé étrangère dans Adresse
              .OnDelete(DeleteBehavior.Cascade); // Action à effectuer lors de suppression

            modelBuilder.Entity<ClientProspet>()
                .HasMany(cp => cp.MobileClient) // Ajoutez cette configuration pour MobileClient
                .WithOne(mc => mc.ClientProspet)
                .HasForeignKey(mc => mc.ClientId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<ClientProspet>()
               .HasMany(cp => cp.Documents) // Ajoutez cette configuration pour MobileClient
               .WithOne(mc => mc.ClientProspet)
               .HasForeignKey(mc => mc.ClientId)
               .OnDelete(DeleteBehavior.Cascade);
          
            modelBuilder.Entity<ClientProspet>()
             .HasMany(cp => cp.MailClient)// Relation "un-à-plusieurs"
             .WithOne(a => a.ClientProspet) // Navigation property dans Adresse
             .HasForeignKey(a => a.ClientId) // Clé étrangère dans Adresse
             .OnDelete(DeleteBehavior.Cascade); // Action à effectuer lors de suppression
            modelBuilder.Entity<ClientProspet>()
            .HasMany(cp => cp.FATCA)// Relation "un-à-plusieurs"
            .WithOne(a => a.ClientProspet) // Navigation property dans Adresse
            .HasForeignKey(a => a.ClientId) // Clé étrangère dans Adresse
            .OnDelete(DeleteBehavior.Cascade); // Action à effectuer lors de suppression
            modelBuilder.Entity<ClientProspet>()
              .HasMany(cp => cp.CIN) // Ajoutez cette configuration pour MobileClient
              .WithOne(mc => mc.ClientProspet)
              .HasForeignKey(mc => mc.ClientId)
              .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<ClientProspet>()
            .HasMany(cp => cp.Choixagence) // Ajoutez cette configuration pour MobileClient
            .WithOne(mc => mc.ClientProspet)
            .HasForeignKey(mc => mc.ClientId)
            .OnDelete(DeleteBehavior.Cascade);
        }
    }
}