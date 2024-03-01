using MediatR;
using SuperHeroAssessment.Api.Contracts.Requests;
using SuperHeroAssessment.Application.Handlers.Mappers;
using SuperHeroAssessment.Domain.Database;
using SuperHeroAssessment.Domain.Database.Entities;
using SuperHeroAssessment.Domain.Services;

namespace SuperHeroAssessment.Application.Handlers
{
    public class StoreFavoriteSuperHeroHandler : BaseHandler, IRequestHandler<StoreSuperHeroRequest, string>
    {
        private readonly ISuperHeroApiService _superHeroApiService;
        private readonly IRepository<SuperHeroEntity> _superHeroRepository;

        public StoreFavoriteSuperHeroHandler(ISuperHeroApiService superHeroApiService, IRepository<SuperHeroEntity> superHeroRepository)
        {
            _superHeroApiService = superHeroApiService;
            _superHeroRepository = superHeroRepository;
        }

        public async Task<string> Handle(StoreSuperHeroRequest request, CancellationToken cancellationToken)
        {
            var superHero = await _superHeroApiService.GetSuperHero(request.Id);
            if (superHero == null)
            {
                return null;
            }

            var result = _superHeroRepository.Add(superHero.Map(true));

            return result.Id;
        }
    }
}
