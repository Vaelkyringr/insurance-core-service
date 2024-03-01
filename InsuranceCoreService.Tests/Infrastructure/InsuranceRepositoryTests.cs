using InsuranceCoreService.Domain.InsuranceAggregate;
using InsuranceCoreService.Domain.InsurerAggregate;
using InsuranceCoreService.Infrastructure.Context;
using InsuranceCoreService.Infrastructure.Repository;

namespace InsuranceCoreService.Tests.Infrastructure;

public class InsuranceRepositoryTests
{
    private readonly InsuranceDbContext _context;
    private readonly InsuranceRepository _repository;

    public InsuranceRepositoryTests()
    {
        var options = new DbContextOptionsBuilder<InsuranceDbContext>()
            .UseInMemoryDatabase(databaseName: "InsuranceTestDb")
            .Options;

        _context = new InsuranceDbContext(options);
        _repository = new InsuranceRepository(_context);
    }


    [Fact]
    public async Task GetInsuranceByIdAsync_ReturnsInsurance()
    {
        var insurance = new Insurance
        {
            Id = 1,
            Insurer = new Insurer
            {
                Name = "Insurer",
                OrganizationNumber = new OrganizationNumber("1234567890"),
                Address = "Street"
            }
        };

        _context.Insurances.Add(insurance);
        await _context.SaveChangesAsync();

        var result = await _repository.GetInsuranceByIdAsync(insurance.Id);

        Assert.Equal(insurance, result);
    }

    [Fact]
    public async Task GetInsuranceByIdAsync_ReturnsNull()
    {
        var result = await _repository.GetInsuranceByIdAsync(1);
        Assert.Null(result);
    }

    [Fact]
    public async Task CreateInsuranceAsync_AddsInsuranceToDatabase()
    {
        var insurance = new Insurance { Id = 1 };

        var result = await _repository.CreateInsuranceAsync(insurance);

        Assert.Equal(insurance, result);
        Assert.Contains(insurance, _context.Insurances);
    }
}