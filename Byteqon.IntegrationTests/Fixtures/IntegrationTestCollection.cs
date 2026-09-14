namespace Byteqon.IntegrationTests.Fixtures;

[CollectionDefinition(Name)]
public sealed class IntegrationTestCollection
    : ICollectionFixture<ByteqonWebApplicationFactory>
{
    public const string Name =
        "BYTEQON Integration Tests";
}
