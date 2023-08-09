using Microsoft.EntityFrameworkCore;

namespace ptt_api.Entities
{
    public class DancersDbContext : DbContext
    {
        private string _connectionString =
             "Server=LAPTOP-NCAVBJF7;Database=DancersDb;Trusted_Connection=True;TrustServerCertificate=True;Encrypt=false;";
        
        public DbSet<Dancer> Dancers { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<DanceClub> DanceClubs { get; set; }

        public DbSet<DancePair> DancePairs { get; set; }
        public DbSet<DanceCompetitionCategory> DanceCompetitionCategories { get; set; }
        public DbSet<DanceEvent> DanceEvents { get; set; }

        
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Dancer>()
                .Property(r => r.Name)
                .IsRequired()
                .HasMaxLength(25);
            modelBuilder.Entity<DanceClub>()
                .Property(r => r.Name)
                .IsRequired();
            modelBuilder.Entity<Dancer>()
                .Property(r => r.Danceclass)
                .HasDefaultValue("H");
            modelBuilder.Entity<DanceEvent>()
                .Property(r => r.Name)
                .IsRequired();

                
            //modelBuilder.Entity<DancePair>()
            //    .HasOne(w => w.Dancer)
            //    .WithMany()
            //    .HasForeignKey(w => w.DancerId);
            //modelBuilder.Entity<DancePair>()
            //    .HasOne(w => w.DancePartner)
            //    .WithMany()
            //    .HasForeignKey(r => r.DanceParnterId);

        }
        
        
        
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
