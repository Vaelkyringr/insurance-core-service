namespace InsuranceCoreService.Tests;

internal static class FixtureExtensions
{
    /// <summary>
    /// Fix circular reference that Entity Framework causes together with AutoFixture
    /// </summary>
    public static IFixture FixCircularReference(this IFixture fixture)
    {
        fixture.Behaviors.Remove(new ThrowingRecursionBehavior());
        fixture.Behaviors.Add(new OmitOnRecursionBehavior());

        return fixture;
    }
}