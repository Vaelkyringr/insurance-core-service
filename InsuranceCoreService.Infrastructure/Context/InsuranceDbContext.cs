using InsuranceCoreService.Domain.CoverageAggregate;
using InsuranceCoreService.Domain.InsuranceAggregate;
using InsuranceCoreService.Domain.InsurerAggregate;

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
        modelBuilder.Entity<Insurance>().Property(i => i.YearlyPremium).HasColumnType("decimal(18,4)");
        modelBuilder.Entity<Insurance>().HasOne(i => i.Insurer).WithMany(i => i.Insurances).HasForeignKey(i => i.InsurerId);
        modelBuilder.Entity<Insurance>().HasMany(i => i.Coverages).WithMany(i => i.Insurances).UsingEntity(x => x.ToTable("InsuranceCoverage"));
        modelBuilder.Entity<Insurance>().OwnsOne(i => i.InsuranceNumber)
            .Property(i => i.Number).HasColumnName("InsuranceNumber");

        modelBuilder.Entity<Insurer>().ToTable("Insurers").HasKey(i => i.Id);
        modelBuilder.Entity<Insurer>().Property(p => p.Id).ValueGeneratedOnAdd();

        modelBuilder.Entity<InsuranceCoverage>().ToTable("InsuranceCoverages").HasKey(i => i.Id);
        modelBuilder.Entity<InsuranceCoverage>().Property(p => p.Id).ValueGeneratedOnAdd();
        modelBuilder.Entity<InsuranceCoverage>().HasKey(ic => new { ic.InsuranceId, ic.CoverageId });

        modelBuilder.Entity<Coverage>().ToTable("Coverages").HasKey(c => c.Id);
        modelBuilder.Entity<Coverage>().Property(p => p.Id).ValueGeneratedOnAdd();
        modelBuilder.Entity<Coverage>().Property(i => i.YearlyBaseAmount).HasColumnType("decimal(18,4)");

        base.OnModelCreating(modelBuilder);
    }

    public DbSet<Insurance> Insurances { get; init; }
    public DbSet<Insurer> Insurers { get; init; }
    public DbSet<Coverage> Coverages { get; init; }
    public DbSet<InsuranceCoverage> InsuranceCoverages { get; init; }
}   
