using TravelHubApi.Sdk.Common.API.Enums;

namespace TravelHubApi.Sdk.Common.API
{
    public class Settings
    {
        public Environment Environment { get; set; }

        public Language Language { get; set; }

        public string ClientId { get; set; }

        public string ClientSecret { get; set; }
    }
}
