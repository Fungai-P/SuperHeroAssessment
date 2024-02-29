using MediatR;
using SuperHeroAssessment.Api.Contracts.Requests;
using SuperHeroAssessment.Api.Contracts.Responses;
using SuperHeroAssessment.Application.Handlers.Mappers;
using SuperHeroAssessment.Domain.Database;
using SuperHeroAssessment.Domain.Database.Entities;

namespace SuperHeroAssessment.Application.Handlers
{
    public class GetListSuperHeroHandler : BaseHandler, IRequestHandler<GetListSuperHeroRequest, List<SuperHeroResponse>>
    {
        private readonly IRepository<SuperHeroEntity> _repository;

        public GetListSuperHeroHandler(IRepository<SuperHeroEntity> repository)
        {
            _repository = repository;
        }

        public async Task<List<SuperHeroResponse>> Handle(GetListSuperHeroRequest request, CancellationToken cancellationToken)
        {
            var result = _repository.FetchAll().ToList();

            return result.Map();
        }
    }
}
