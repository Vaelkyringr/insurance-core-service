using InsuranceCoreService.Domain.InsuranceAggregate;
using InsuranceCoreService.Domain.InsurerAggregate;
using InsuranceCoreService.Infrastructure.Context;
using InsuranceCoreService.Infrastructure.Repository;

namespace InsuranceCoreService.Tests.Infrastructure;

public class InsuranceRepositoryTests : IAsyncDisposable
{
    private readonly InsuranceDbContext _context;
    private readonly InsuranceRepository _repository;
    private readonly Fixture _fixture = new();

    public InsuranceRepositoryTests()
    {
        _context = TestDbContextFactory.CreateNewContext();
        _repository = new InsuranceRepository(_context);
        _fixture.FixCircularReference();
    }

    [Fact]
    public async Task GetInsuranceByIdAsync_ReturnsInsurance()
    {
        var insurance = _fixture.Build<Insurance>()
            .With(i => i.Id, 1)
            .With(i => i.Insurer, _fixture.Build<Insurer>()
                .With(insurer => insurer.OrganizationNumber, new OrganizationNumber("1234567890"))
                .Create())
            .Create();

        await _context.Insurances.AddAsync(insurance);
        await _context.SaveChangesAsync();

        var result = await _repository.GetInsuranceByIdAsync(insurance.Id);

        Assert.Equal(insurance, result);

        await DisposeAsync();
    }

    [Fact]
    public async Task GetInsuranceByIdAsync_ReturnsNull()
    {
        var result = await _repository.GetInsuranceByIdAsync(1);
        Assert.Null(result);
    }

    [Fact]
    public async Task CreateInsuranceAsync_CreatesInsurance()
    {
        var insurance = new Insurance { Id = 1 };

        var result = await _repository.CreateInsuranceAsync(insurance);

        Assert.Equal(insurance, result);
        Assert.Contains(insurance, _context.Insurances);

        await DisposeAsync();
    }

    public async ValueTask DisposeAsync()
    {
        await _context.Database.EnsureDeletedAsync();
        await _context.DisposeAsync();
    }
}