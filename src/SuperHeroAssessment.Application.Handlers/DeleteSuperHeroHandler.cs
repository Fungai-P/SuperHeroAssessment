using MediatR;
using SuperHeroAssessment.Api.Contracts.Requests;
using SuperHeroAssessment.Domain.Database;
using SuperHeroAssessment.Domain.Database.Entities;

namespace SuperHeroAssessment.Application.Handlers
{
    public class DeleteSuperHeroHandler : BaseHandler, IRequestHandler<DeleteSuperHeroRequest>
    {
        private readonly IRepository<SuperHeroEntity> _repository;

        public DeleteSuperHeroHandler(IRepository<SuperHeroEntity> repository)
        {
            _repository = repository;
        }

        public async Task Handle(DeleteSuperHeroRequest request, CancellationToken cancellationToken)
        {
            _repository.Delete(x => x.Id == request.Id);
        }
    }
}
