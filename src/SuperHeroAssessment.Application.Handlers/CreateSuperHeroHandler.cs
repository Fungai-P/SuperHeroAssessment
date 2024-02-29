using MediatR;
using SuperHeroAssessment.Api.Contracts.Requests;
using SuperHeroAssessment.Api.Contracts.Responses;
using SuperHeroAssessment.Application.Handlers.Mappers;
using SuperHeroAssessment.Domain.Database;
using SuperHeroAssessment.Domain.Database.Entities;

namespace SuperHeroAssessment.Application.Handlers
{
    public class CreateSuperHeroHandler : BaseHandler, IRequestHandler<CreateSuperHeroRequest, BaseResponse>
    {
        private readonly IRepository<SuperHeroEntity> _repository;

        public CreateSuperHeroHandler(IRepository<SuperHeroEntity> repository)
        {
            _repository = repository;
        }

        public async Task<BaseResponse> Handle(CreateSuperHeroRequest request, CancellationToken cancellationToken)
        {
            var result = _repository.Add(request.Map());

            return new BaseResponse
            {
                Id = result.Id
            };
        }
    }
}
