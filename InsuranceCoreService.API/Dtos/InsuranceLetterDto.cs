namespace InsuranceCoreService.API.Dtos;

public class InsuranceLetterDto
{
    public string InsuranceNumber { get; set; } = null!;
    public int YearlyPremium { get; set; }
    public string InsurerName { get; set; } = null!;
    public DateTime StartPeriod { get; set; }
    public DateTime EndPeriod { get; set; }
    public List<string> Coverages { get; set; } = null!;
}
