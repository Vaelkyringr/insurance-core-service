namespace InsuranceCoreService.Domain;

public abstract class EntityBase
{
    protected EntityBase()
    {
        Created = DateTime.UtcNow;
    }

    public int Id { get; set; }
    public DateTime Created { get; set; }
    public DateTime Updated { get; set; }
}