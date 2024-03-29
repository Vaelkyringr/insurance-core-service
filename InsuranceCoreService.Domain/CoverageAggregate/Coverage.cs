﻿using InsuranceCoreService.Domain.InsuranceAggregate;
using InsuranceCoreService.Domain.SeedWork;

namespace InsuranceCoreService.Domain.CoverageAggregate;

public class Coverage : EntityBase
{
    public Coverage() { }

    public string Name { get; init; } = null!;

    public decimal YearlyBaseAmount { get; init; }

    public ICollection<Insurance> Insurances { get; init; } = null!;
}