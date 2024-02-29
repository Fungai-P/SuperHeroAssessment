using SuperHeroAssessment.Domain.Models;

namespace SuperHeroAssessment.Api.Contracts.Responses
{
    public class SuperHeroResponse : BaseResponse
    {
        public Appearance Appearance { get; set; }
        public Biography Biography { get; set; }
        public PowerStats PowerStats { get; set; }
        public Work Work { get; set; }
        public Connections Connections { get; set; }
        public Image Image { get; set; }
    }
}
