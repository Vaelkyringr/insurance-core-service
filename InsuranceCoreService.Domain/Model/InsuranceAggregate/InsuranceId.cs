namespace InsuranceCoreService.Domain.Model.InsuranceAggregate;

using System;

public class InsuranceId
{
    private readonly Guid _value;

    public InsuranceId()
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
        var that = (InsuranceId)obj;
        return _value.Equals(that._value);
    }

    public override int GetHashCode()
    {
        return _value.GetHashCode();
    }
}