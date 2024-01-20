using InsuranceCoreService.Domain.Aggregates.Insurance;
using InsuranceCoreService.Domain.Aggregates.Insurer;

namespace InsuranceCoreService.Infrastructure.Context;

public class InsuranceDbContext : DbContext
{
	public InsuranceDbContext(DbContextOptions<InsuranceDbContext> options) : base(options)
	{
	}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Insurance>().ToTable("Insurances").HasKey(i => i.Id);
        modelBuilder.Entity<Insurance>().Property(p => p.Id).ValueGeneratedOnAdd();

        modelBuilder.Entity<Insurer>().ToTable("Insurers").HasKey(i => i.Id);
        modelBuilder.Entity<Insurer>().Property(p => p.Id).ValueGeneratedOnAdd();

        base.OnModelCreating(modelBuilder);
    }

    public DbSet<Insurance> Insurances { get; set; }
}
