using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace WebAPICRUD.Domain.Persistence
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Country> Countries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("WebApi");
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Country>(entity =>
            {
                entity.ToTable("Countries");
                entity.HasKey(e => e.Id);
                entity.HasIndex(e=>e.Name).IsUnique();
                entity.HasIndex(e=>e.Motto).IsUnique();
                entity.Property(e => e.Name).HasComment("The name of the country").IsRequired();
                entity.Property(e => e.DateOfIndependence).HasComment("The date of independence").IsRequired();
                entity.Property(e => e.Motto).HasComment("The national motto").IsRequired();
                entity.Property(e => e.Population).HasComment("The population of the country").IsRequired();
                entity.Property(e => e.CurrencyCode).HasComment("The currency code").IsRequired();

                entity.HasQueryFilter(e => !e.IsDeleted);
            });

          
        }
    }
}
