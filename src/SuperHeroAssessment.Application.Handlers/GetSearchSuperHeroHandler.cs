using MediatR;
using SuperHeroAssessment.Api.Contracts.Requests;
using SuperHeroAssessment.Api.Contracts.Responses;
using SuperHeroAssessment.Application.Handlers.Mappers;
using SuperHeroAssessment.Domain.Services;

namespace SuperHeroAssessment.Application.Handlers
{
    public class GetSearchSuperHeroHandler : BaseHandler, IRequestHandler<GetSearchSuperHeroRequest, List<SuperHeroResponse>>
    {
        private readonly ISuperHeroApiService _superHeroApiService;

        public GetSearchSuperHeroHandler(ISuperHeroApiService superHeroApiService)
        {
            _superHeroApiService = superHeroApiService;
        }

        public async Task<List<SuperHeroResponse>> Handle(GetSearchSuperHeroRequest request, CancellationToken cancellationToken)
        {
            var results = await _superHeroApiService.SearchSuperHero(request.Name);

            return results.Map();
        }
    }
}
