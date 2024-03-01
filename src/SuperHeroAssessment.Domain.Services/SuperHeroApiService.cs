using Newtonsoft.Json;
using SuperHeroAssessment.Domain.Models;

namespace SuperHeroAssessment.Domain.Services
{
    public class SuperHeroApiService : ISuperHeroApiService
    {
        private readonly HttpClient _httpClient;
        public SuperHeroApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<SuperHero> GetSuperHero(string id)
        {
            var response = await _httpClient.GetAsync(id);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            if (content == null)
            {
                return null;
            }
            var result = JsonConvert.DeserializeObject<SuperHero>(content);
            return (result.Id != null) ? result : null;
        }

        public async Task<List<SuperHero>> SearchSuperHero(string name)
        {
            var response = await _httpClient.GetAsync($"search/{name}");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            if (content == null)
            {
                return null;
            }
            var results = JsonConvert.DeserializeObject<SearchResults>(content);
            return results.Results ?? new List<SuperHero>();
        }
    }
}