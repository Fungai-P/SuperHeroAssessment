using MediatR;
using SuperHeroAssessment.Api.Contracts.Responses;

namespace SuperHeroAssessment.Api.Contracts.Requests
{
    public class GetOneSuperHeroRequest : IRequest<SuperHeroResponse>
    {
        public string Id { get; }
        public GetOneSuperHeroRequest(string id)
        {
            Id = id;
        }
    }
}
