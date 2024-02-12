﻿namespace InsuranceCoreService.Domain.CoverageAggregate;

public class Coverage : EntityBase
{
    public Coverage() { }

    public string Name { get; init; } = null!;
    public ICollection<InsuranceCoverage> InsuranceCoverages { get; init; } = null!;
}