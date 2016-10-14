using Newtonsoft.Json;
using System;
using TravelHubApi.Sdk.Common.Extensions;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

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
                json = r.ReadToEnd(); ;
            }
            return JObject.Parse(json);
        }
    }
}
