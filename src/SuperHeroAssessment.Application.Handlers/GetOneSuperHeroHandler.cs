using MediatR;
using SuperHeroAssessment.Api.Contracts.Requests;
using SuperHeroAssessment.Api.Contracts.Responses;
using SuperHeroAssessment.Application.Handlers.Mappers;
using SuperHeroAssessment.Domain.Database;
using SuperHeroAssessment.Domain.Database.Entities;

namespace SuperHeroAssessment.Application.Handlers
{
    public class GetOneSuperHeroHandler : BaseHandler, IRequestHandler<GetOneSuperHeroRequest, SuperHeroResponse>
    {
        private readonly IRepository<SuperHeroEntity> _repository;

        public GetOneSuperHeroHandler(IRepository<SuperHeroEntity> repository)
        {
            _repository = repository;
        }

        public async Task<SuperHeroResponse> Handle(GetOneSuperHeroRequest request, CancellationToken cancellationToken)
        {
            var result = _repository.Single(x => x.Id == request.Id);

            return result.Map();
        }
    }
}
