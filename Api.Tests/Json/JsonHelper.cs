using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System.IO;

namespace API.Test.Json
{
    public static class JsonHelper
    {
        public static string JsonUserRegister => "Json/registerUser.json";
        public static string JsonUserLogin => "Json/loginUser.json";
        public static string JsonUser => "Json/user.json";

        public static JObject ChangeJsonValue(string jsonPath, string key = null, dynamic value = null)
        {
            JObject jObject = JObject.Parse(File.ReadAllText(jsonPath));

            // read JSON directly from a file
            using (StreamReader file = File.OpenText(jsonPath))
            using (JsonTextReader reader = new JsonTextReader(file))
            {
                JObject jObjectReader = (JObject)JToken.ReadFrom(reader);
                jObject = jObjectReader;
            }
            if (key != null)
                jObject.SelectToken(key).Replace(value);

            return jObject;
        }

        public static string GetTokenFromRestResponse(IRestResponse restResponse)
        {
            var obj = (JObject)JsonConvert.DeserializeObject(restResponse.Content);
            return obj["data"]["Token"].ToString();
        }

        public static int GetUserIdFromRestResponse(IRestResponse restResponse)
        {
            var obj = (JObject)JsonConvert.DeserializeObject(restResponse.Content);
            return (int)obj["id"];
        }
    }
}
