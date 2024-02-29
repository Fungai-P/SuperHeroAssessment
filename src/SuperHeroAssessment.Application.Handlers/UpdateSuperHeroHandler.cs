using MediatR;
using SuperHeroAssessment.Api.Contracts.Requests;
using SuperHeroAssessment.Api.Contracts.Responses;
using SuperHeroAssessment.Application.Handlers.Mappers;
using SuperHeroAssessment.Domain.Database;
using SuperHeroAssessment.Domain.Database.Entities;

namespace SuperHeroAssessment.Application.Handlers
{
    public class UpdateSuperHeroHandler : BaseHandler, IRequestHandler<UpdateSuperHeroRequest, SuperHeroResponse>
    {
        private readonly IRepository<SuperHeroEntity> _repository;

        public UpdateSuperHeroHandler(IRepository<SuperHeroEntity> repository)
        {
            _repository = repository;
        }

        public async Task<SuperHeroResponse> Handle(UpdateSuperHeroRequest request, CancellationToken cancellationToken)
        {
            var result = _repository.Update(request.Id, request.Map());

            return result.Map();
        }
    }
}
