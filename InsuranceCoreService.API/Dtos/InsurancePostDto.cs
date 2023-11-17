namespace InsuranceCoreService.API.Dtos;

public class InsurancePostDto
{
    public string InsuranceNumber { get; set; } = null!;

    private decimal YearlyPremium { get; set; } = 0;

    public InsurerPostDto Insurer { get; set; } = null!;

    public CoveragePostDto Coverage { get; set; } = null!;
}
