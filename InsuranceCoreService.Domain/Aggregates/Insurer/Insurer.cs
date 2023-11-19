namespace InsuranceCoreService.Domain.Aggregates.Insurer;

public class Insurer
{
    public Insurer(string name, string orgNr)
    {
        Id = new InsurerId();
        Name = name;
        OrgNr = orgNr;
    }

    private InsurerId Id { get; set; }

    private string Name { get; set; }

    private string OrgNr { get; set; }
}
