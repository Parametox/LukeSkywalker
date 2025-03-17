using Newtonsoft.Json;
using RestSharp;

namespace LukeSkywalker.Integrations;

public class RestApiInvoker
{
    private RestClient _restClient;
    private const string _url = "https://swapi.dev/api/";

    public RestApiInvoker()
    {
        _restClient = new RestClient(_url);
        ConfigureDefaultHeaders(_restClient);
    }

    public async Task<T?> GetAsync<T>(string endpoint)
    {
        var request = new RestRequest(endpoint, Method.Get);

        var response = await _restClient.ExecuteAsync(request);

        if (response.IsSuccessful)
        {
            try
            {
                if (response?.Content == null)
                {
                    return default;
                }
                return JsonConvert.DeserializeObject<T>(response.Content,new JsonSerializerSettings { });
            }
            catch (Exception ex)
            {
                throw new DeserializationException(response, ex);
            }
        }
        return default;
    }

    private void ConfigureDefaultHeaders(RestClient restClient)
    {
        restClient.AddDefaultHeader("Content-Type", "application/json");
    }
}
