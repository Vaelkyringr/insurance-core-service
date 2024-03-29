﻿namespace InsuranceCoreService.API.CQRS.Responses;

public class CreateInsurerResponse
{
    public int Id { get; init; }

    public string Name { get; init; } = null!;

    public string OrganizationNumber { get; init; } = null!;

    public string? Address { get; init; }
}