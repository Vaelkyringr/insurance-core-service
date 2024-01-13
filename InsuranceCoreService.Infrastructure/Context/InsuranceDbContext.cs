using InsuranceCoreService.Domain.Aggregates.Insurance;

namespace InsuranceCoreService.Infrastructure.Context;

public class InsuranceDbContext : DbContext
{
	public InsuranceDbContext(DbContextOptions<InsuranceDbContext> options) : base(options)
	{
	}

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Insurance;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Insurance>().ToTable("Insurances").HasKey(i => i.Id);
        modelBuilder.Entity<Insurance>().Property(f => f.Id).ValueGeneratedOnAdd();

        base.OnModelCreating(modelBuilder);
    }

    public DbSet<Insurance> Insurances { get; set; }
}
