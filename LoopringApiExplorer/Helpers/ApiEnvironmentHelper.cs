using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace LoopringApiExplorer
{
    public static class ApiEnvironmentHelper
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public enum ApiEnvironment
        {
            PRODUCTION,
            UAT
        };
        public static string GetApiEnvironment(ApiEnvironment apiEnvironment)
        {
            if (apiEnvironment == ApiEnvironment.PRODUCTION)
            {
                return "https://api3.loopring.io";
            }
            else if(apiEnvironment == ApiEnvironment.UAT)
            {
                return "https://uat2.loopring.io";
            }
            else
            {
                //Should never get to here
                return null;
            }
        }
    }
}
