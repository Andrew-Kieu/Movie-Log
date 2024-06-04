using System;
using System.Net.Http;
using System.Threading.Tasks;

public class HttpService
{
    private readonly HttpClient _httpClient;
    

    public HttpService()
    {
        _httpClient = new HttpClient();
    }

    

    public async Task<string> GetAsync(string url)
    {
        HttpResponseMessage response = await _httpClient.GetAsync(url);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadAsStringAsync();
    }

    public async Task<string> PostAsync(string url, string data)
    {
        HttpResponseMessage response = await _httpClient.PostAsync(url, new StringContent(data));
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadAsStringAsync();
    }

}
