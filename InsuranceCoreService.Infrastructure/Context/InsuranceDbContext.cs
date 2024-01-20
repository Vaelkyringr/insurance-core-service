using InsuranceCoreService.Domain.Aggregates.Insurance;

namespace InsuranceCoreService.Infrastructure.Context;

public class InsuranceDbContext : DbContext
{
	public InsuranceDbContext(DbContextOptions<InsuranceDbContext> options) : base(options)
	{
	}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Insurance>().ToTable("Insurances").HasKey(i => i.Id);
        modelBuilder.Entity<Insurance>().Property(f => f.Id).ValueGeneratedOnAdd();

        base.OnModelCreating(modelBuilder);
    }

    public DbSet<Insurance> Insurances { get; set; }
}
