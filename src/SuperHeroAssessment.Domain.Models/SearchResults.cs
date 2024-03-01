using Newtonsoft.Json;

namespace SuperHeroAssessment.Domain.Models
{
    public class SearchResults
    {
        public string Response { get; set; }
        [JsonProperty(PropertyName = "results-for")]
        public string ResultsFor { get; set; }
        public List<SuperHero> Results { get; set; }

    }
}
