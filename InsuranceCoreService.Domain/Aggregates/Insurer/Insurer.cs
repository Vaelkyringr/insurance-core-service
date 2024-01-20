namespace InsuranceCoreService.Domain.Aggregates.Insurer;

public class Insurer
{
    public Insurer() { }

    public Insurer(string name, string orgNr)
    {
        Name = name;
        OrgNr = orgNr;
    }

    public int Id { get; set; }

    public string Name { get; }

    public string OrgNr { get; }
}
