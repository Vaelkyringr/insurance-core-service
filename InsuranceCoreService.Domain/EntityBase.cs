namespace InsuranceCoreService.Domain;

public abstract class EntityBase
{
    public int Id { get; set; }
    public DateTime Created { get; set; } = DateTime.UtcNow;
    public DateTime Updated { get; set; }
}