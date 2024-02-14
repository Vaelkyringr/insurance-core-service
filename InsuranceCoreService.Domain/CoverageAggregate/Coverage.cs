﻿using InsuranceCoreService.Domain.InsuranceAggregate;

namespace InsuranceCoreService.Domain.CoverageAggregate;

public class Coverage : EntityBase
{
    public Coverage() { }

    public string Name { get; init; } = null!;

    public decimal BaseAmount { get; init; }

    public ICollection<Insurance> Insurances { get; init; } = null!;
}