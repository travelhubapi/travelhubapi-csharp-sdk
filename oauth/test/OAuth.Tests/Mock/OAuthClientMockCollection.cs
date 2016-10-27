using TravelHubApi.Sdk.OAuth.Tests.Mock;
using Xunit;

namespace Sdk.OAuth.Tests.Mock
{
    [CollectionDefinition("OAuthClientMock collection")]
    public class OAuthClientMockCollection : ICollectionFixture<OAuthClientMockFixture>
    {
        // This class has no code, and is never created. Its purpose is simply
        // to be the place to apply [CollectionDefinition] and all the
        // ICollectionFixture<> interfaces.
    }
}
