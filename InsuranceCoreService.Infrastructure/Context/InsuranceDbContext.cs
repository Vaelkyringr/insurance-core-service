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
        modelBuilder.Entity<Insurance>()
            .HasOne(i => i.Insurer)
            .WithMany(i => i.Insurances)
            .HasForeignKey(i => i.InsurerId);

        modelBuilder.Entity<Insurer>().ToTable("Insurers").HasKey(i => i.Id);
        modelBuilder.Entity<Insurer>().Property(p => p.Id).ValueGeneratedOnAdd();

        modelBuilder.Entity<InsuranceCoverage>().ToTable("InsuranceCoverages").HasKey(i => i.Id);
        modelBuilder.Entity<InsuranceCoverage>().Property(p => p.Id).ValueGeneratedOnAdd();
        modelBuilder.Entity<InsuranceCoverage>().HasKey(ic => new { ic.InsuranceId, ic.CoverageId });
        modelBuilder.Entity<InsuranceCoverage>()
            .HasOne(ic => ic.Insurance)
            .WithMany(i => i.InsuranceCoverages)
            .HasForeignKey(ic => ic.InsuranceId);
        modelBuilder.Entity<InsuranceCoverage>()
            .HasOne(ic => ic.Coverage)
            .WithMany(c => c.InsuranceCoverages)
            .HasForeignKey(ic => ic.CoverageId);

        base.OnModelCreating(modelBuilder);
    }

    public DbSet<Insurance> Insurances { get; set; }
    public DbSet<Insurer> Insurers { get; set; }
    public DbSet<Coverage> Coverages { get; set; }
    public DbSet<InsuranceCoverage> InsuranceCoverages { get; set; }
}
