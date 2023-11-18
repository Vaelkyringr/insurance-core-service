namespace InsuranceCoreService.Infrastructure.Context;

public class InsuranceDbContext : DbContext
{
	public InsuranceDbContext(DbContextOptions<InsuranceDbContext> options) : base(options)
	{
	}

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		base.OnConfiguring(optionsBuilder);
		optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=Insurance;Trusted_Connection=true;TrustServerCertificate=true");
	}

	public DbSet<Entities.Insurance> Insurances { get; set; }
}
