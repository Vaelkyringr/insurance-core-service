using InsuranceCoreService.Infrastructure.Context;

namespace InsuranceCoreService.Tests.Infrastructure;
public class TestDbContextFactory
{
    public static InsuranceDbContext CreateNewContext()
    {
        var options = new DbContextOptionsBuilder<InsuranceDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

        return new InsuranceDbContext(options);
    }
}