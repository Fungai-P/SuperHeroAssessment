using MediatR;
using SuperHeroAssessment.Api.Contracts.Responses;
using SuperHeroAssessment.Domain.Models;

namespace SuperHeroAssessment.Api.Contracts.Requests
{
    public class UpdateSuperHeroRequest : IRequest<SuperHeroResponse>
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public Appearance Appearance { get; set; }
        public Biography Biography { get; set; }
        public PowerStats PowerStats { get; set; }
        public Work Work { get; set; }
        public Connections Connections { get; set; }
        public Image Image { get; set; }
    }
}
