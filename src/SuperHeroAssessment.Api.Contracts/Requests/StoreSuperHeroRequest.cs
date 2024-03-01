using MediatR;

namespace SuperHeroAssessment.Api.Contracts.Requests
{
    public class StoreSuperHeroRequest : IRequest<string>
    {
        public string Id { get; set; }
    }
}
