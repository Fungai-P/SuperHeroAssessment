using MediatR;

namespace SuperHeroAssessment.Api.Contracts.Requests
{
    public class DeleteSuperHeroRequest : IRequest
    {
        public string Id { get; }
        public DeleteSuperHeroRequest(string id)
        {
            Id = id;
        }
    }
}
