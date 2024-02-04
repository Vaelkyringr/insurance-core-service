namespace InsuranceCoreService.Domain.InsurerAggregate;

public interface IInsurerRepository
{
    Task<Insurer> CreateInsurerAsync(Insurer insurer);
}