namespace InsuranceCoreService.Tests;
internal static class FixtureExtensions
{
    /// <summary>
    /// Fix circular reference because that Entity Framework causes
    /// </summary>
    public static IFixture FixCircularReference(this IFixture fixture)
    {
        fixture.Behaviors.Remove(new ThrowingRecursionBehavior());
        fixture.Behaviors.Add(new OmitOnRecursionBehavior());

        return fixture;
    }
}