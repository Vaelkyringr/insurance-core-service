using InsuranceCoreService.Domain.InsurerAggregate;
using InsuranceCoreService.Infrastructure.Context;
using InsuranceCoreService.Infrastructure.Repository;

namespace InsuranceCoreService.Tests.Infrastructure;

public class InsurerRepositoryTests : IAsyncDisposable
{
    private readonly InsuranceDbContext _context;
    private readonly InsurerRepository _repository;
    private readonly Fixture _fixture = new();

    public InsurerRepositoryTests()
    {
        _context = TestDbContextFactory.CreateNewContext();
        _repository = new InsurerRepository(_context);
        _fixture.FixCircularReference();
    }

    [Fact]
    public async Task GetAllInsurersAsync_ReturnsInsurers()
    {
        var insurers = Enumerable.Range(0, 10)
            .Select(x => _fixture.Build<Insurer>()
                .With(i => i.OrganizationNumber, new OrganizationNumber("1234567890"))
                .Create())
            .ToList();

        await _context.Insurers.AddRangeAsync(insurers);
        await _context.SaveChangesAsync();

        var result = await _repository.GetAllInsurersAsync(1, 10);

        Assert.Equal(insurers, result);
    }

    [Fact]
    public async Task GetAllInsurersAsync_ReturnsNull()
    {
        var result = await _repository.GetAllInsurersAsync(1, 10);

        Assert.Empty(result);
    }

    public async ValueTask DisposeAsync()
    {
        await _context.Database.EnsureDeletedAsync();
        await _context.DisposeAsync();
    }
}
