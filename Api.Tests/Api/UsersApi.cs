using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace API.Test.Api
{
    public class UsersApi
    {
        public IRestResponse UserLogin(JObject body)
        {
            var restClient = new RestClient("http://restapi.adequateshop.com");
            var path = "/api/authaccount/login";
            var restRequest = new RestRequest(path, Method.POST);
            var jsonBody = JsonConvert.SerializeObject(body);
            restRequest.RequestFormat = DataFormat.Json;
            restRequest.AddParameter("application/json", jsonBody, ParameterType.RequestBody);

            IRestResponse restResponse = restClient.Execute(restRequest);
            return restResponse;
        }

        public IRestResponse UserRegister(JObject body)
        {

            var restClient = new RestClient("http://restapi.adequateshop.com");
            var path = "/api/authaccount/registration";
            var restRequest = new RestRequest(path, Method.POST);
            var jsonBody = JsonConvert.SerializeObject(body);
            restRequest.RequestFormat = DataFormat.Json;
            restRequest.AddParameter("application/json", jsonBody, ParameterType.RequestBody);

            IRestResponse restResponse = restClient.Execute(restRequest);
            return restResponse;
        }

        public IRestResponse GetAllUsers(string token, int page)
        {
            var restClient = new RestClient("http://restapi.adequateshop.com");
            var path = $"/api/users?page={page}";
            var restRequest = new RestRequest(path, Method.GET);
            restRequest.RequestFormat = DataFormat.Json;
            restRequest.AddHeader("Authorization", $"Bearer {token}");

            IRestResponse restResponse = restClient.Execute(restRequest);
            return restResponse;
        }

        public IRestResponse GetUserById(string token, int id)
        {
            var restClient = new RestClient("http://restapi.adequateshop.com");
            var path = $"/api/users/{id}";
            var restRequest = new RestRequest(path, Method.GET);
            restRequest.RequestFormat = DataFormat.Json;
            restRequest.AddHeader("Authorization", $"Bearer {token}");

            IRestResponse restResponse = restClient.Execute(restRequest);
            return restResponse;
        }

        public IRestResponse DeleteUserById(string token, int id)
        {
            var restClient = new RestClient("http://restapi.adequateshop.com");
            var path = $"/api/users/{id}";
            var restRequest = new RestRequest(path, Method.DELETE);
            restRequest.RequestFormat = DataFormat.Json;
            restRequest.AddHeader("Authorization", $"Bearer {token}");

            IRestResponse restResponse = restClient.Execute(restRequest);
            return restResponse;
        }

        public IRestResponse AddUser(JObject body, string token)
        {
            var restClient = new RestClient("http://restapi.adequateshop.com");
            var path = "/api/users";
            var restRequest = new RestRequest(path, Method.POST);
            var jsonBody = JsonConvert.SerializeObject(body);
            restRequest.RequestFormat = DataFormat.Json;
            restRequest.AddParameter("application/json", jsonBody, ParameterType.RequestBody);
            restRequest.AddHeader("Authorization", $"Bearer {token}");

            IRestResponse restResponse = restClient.Execute(restRequest);
            return restResponse;
        }

    }
}
