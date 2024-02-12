namespace InsuranceCoreService.Domain.InsurerAggregate;

public interface IInsurerRepository
{
    Task<Insurer> CreateInsurerAsync(Insurer insurer);

    Task<IEnumerable<Insurer>> GetAllInsurersAsync(int pageIndex, int pageSize);
}