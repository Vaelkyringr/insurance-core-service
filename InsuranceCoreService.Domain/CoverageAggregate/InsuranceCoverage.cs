﻿using InsuranceCoreService.Domain.InsuranceAggregate;
using InsuranceCoreService.Domain.SeedWork;

namespace InsuranceCoreService.Domain.CoverageAggregate;

public class InsuranceCoverage : EntityBase
{
    public InsuranceCoverage() { }

    public int InsuranceId { get; init; }
    public Insurance Insurance { get; init; } = null!;

    public int CoverageId { get; init; }
    public Coverage Coverage { get; init; } = null!;
}
