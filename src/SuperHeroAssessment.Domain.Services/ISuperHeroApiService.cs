using SuperHeroAssessment.Domain.Models;

namespace SuperHeroAssessment.Domain.Services
{
    public interface ISuperHeroApiService
    {
        Task<SuperHero> GetSuperHero(string id);
        Task<List<SuperHero>> SearchSuperHero(string name);
    }
}
