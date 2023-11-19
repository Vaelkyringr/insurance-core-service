namespace InsuranceCoreService.Domain.Aggregates.Insurer;

using System;

public class InsurerId
{
    private readonly Guid _value;

    public InsurerId()
    {
        _value = Guid.NewGuid();
    }

    public Guid GetValue()
    {
        return _value;
    }

    public override bool Equals(object? obj)
    {
        if (this == obj) return true;
        if (obj == null || GetType() != obj.GetType()) return false;
        var that = (InsurerId)obj;
        return _value.Equals(that._value);
    }

    public override int GetHashCode()
    {
        return _value.GetHashCode();
    }
}