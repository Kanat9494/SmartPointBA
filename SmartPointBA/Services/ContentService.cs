namespace SmartPointBA.Services;

internal class ContentService
{
    internal ContentService()
    {

    }

    private static ContentService _instance;
    public static ContentService Instance()
    {
        if (_instance == null)
            _instance = new ContentService();

        return _instance;
    }

    public async Task<List<TResponse>> GetItemsAsync<TResponse>(string requestUrl)
    {
        using (var httpClient = new HttpClient())
        {
            httpClient.BaseAddress = new Uri(SmartPointConstants.SERVER_ROOT_URL);
            httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                var response = await httpClient.GetStringAsync(httpClient.BaseAddress + requestUrl);
                List<TResponse> result = JsonConvert.DeserializeObject<List<TResponse>>(response);
                return result;
            }
            catch { return null; }
        }
    }
}
