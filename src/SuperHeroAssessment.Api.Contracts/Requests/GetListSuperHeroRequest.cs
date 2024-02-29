using MediatR;
using SuperHeroAssessment.Api.Contracts.Responses;

namespace SuperHeroAssessment.Api.Contracts.Requests
{
    public class GetListSuperHeroRequest : IRequest<List<SuperHeroResponse>>
    {
    }
}
