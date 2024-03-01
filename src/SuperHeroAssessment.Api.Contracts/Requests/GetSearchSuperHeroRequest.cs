using MediatR;
using SuperHeroAssessment.Api.Contracts.Responses;

namespace SuperHeroAssessment.Api.Contracts.Requests
{
    public class GetSearchSuperHeroRequest : IRequest<List<SuperHeroResponse>>
    {
        public string Name { get; }
        public GetSearchSuperHeroRequest(string name)
        {
            Name = name;
        }
    }
}
