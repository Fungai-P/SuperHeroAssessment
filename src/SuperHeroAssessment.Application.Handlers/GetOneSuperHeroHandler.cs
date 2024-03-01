using MediatR;
using SuperHeroAssessment.Api.Contracts.Requests;
using SuperHeroAssessment.Api.Contracts.Responses;
using SuperHeroAssessment.Application.Handlers.Mappers;
using SuperHeroAssessment.Domain.Services;

namespace SuperHeroAssessment.Application.Handlers
{
    public class GetOneSuperHeroHandler : BaseHandler, IRequestHandler<GetOneSuperHeroRequest, SuperHeroResponse>
    {
        private readonly ISuperHeroApiService _superHeroApiService;

        public GetOneSuperHeroHandler(ISuperHeroApiService superHeroApiService)
        {
            _superHeroApiService = superHeroApiService;
        }

        public async Task<SuperHeroResponse> Handle(GetOneSuperHeroRequest request, CancellationToken cancellationToken)
        {
            var result = await _superHeroApiService.GetSuperHero(request.Id);

            return result.Map();
        }
    }
}
