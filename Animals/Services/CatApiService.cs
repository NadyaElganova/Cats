using Animals.Models;
using Animals.Options;
using Microsoft.Extensions.Options;
using System.Collections;
using System.Collections.Generic;
using System.Text.Json;

namespace Animals.Services
{

    public class CatApiService : ICatApiServices
    {
        public string BaseUrl { get; set; }
        public string ApiKey { get; set; }
        private HttpClient httpClient { get; set; }
        public CatApiService(IHttpClientFactory httpClientFactory, IOptions<CatApiOptions> options)
        {
            BaseUrl = options.Value.BaseUrl;
            ApiKey = options.Value.ApiKey;

            httpClient = httpClientFactory.CreateClient();
        }

        public async Task<IEnumerable<Cat>> AllInfoCatsAsync()
        {
            var response = await httpClient.GetAsync($"{BaseUrl}breeds");
            if (response == null) return null;
            var json = await response.Content.ReadAsStringAsync();
            var cats = JsonSerializer.Deserialize <IEnumerable<Cat>> (json);
            
            return cats;
        }

        public async Task<List<Photo>> SearchCat(Cat cat)
        {
            var response = await httpClient.GetAsync($"{BaseUrl}images/search?limit=10&breed_ids={cat.id}&api_key={ApiKey}");
            if (response == null) return null;
            var json = await response.Content.ReadAsStringAsync();
            
            var photos = JsonSerializer.Deserialize<List<Photo>> (json);
            return photos;
        }
    }
}
