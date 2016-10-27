using System.IO;
using Newtonsoft.Json;
using TravelHubApi.Sdk.Common.Extensions;

namespace TravelHubApi.Sdk.Common.Helpers
{
    public static class LoadFiles
    {
        public static string LoadJsonString(string path)
        {
            object obj = LoadJsonObj(path);
            return obj.ToJson();
        }

        public static dynamic LoadJsonObj(string path)
        {
            string json = string.Empty;

            using (StreamReader r = new StreamReader(path))
            {
                json = r.ReadToEnd();
            }

            return JsonConvert.DeserializeObject(json);
        }
    }
}
