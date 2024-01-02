using Microsoft.EntityFrameworkCore;
using ptt_api.Entities;

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

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
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
            modelBuilder.Entity<DancePair>()
                .HasKey(r => r.Id);

            modelBuilder.Entity<DancePair>()
                .Property(r => r.DancePartnerId)
                .IsRequired();
            modelBuilder.Entity<DancePair>()
                .Property(r => r.DancerId)
                .IsRequired();
            modelBuilder.Entity<DanceEvent>()
                .Property(r => r.Name)
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(r => r.ContactEmail)
                .IsRequired();
            modelBuilder.Entity<Role>()
                .Property(r => r.Name)
                .IsRequired();

        }
        
        
        
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
