namespace SuperHeroAssessment.Api.Contracts.Responses
{
    public class AppearanceResponse : BaseResponse
    {
        public string Gender { get; set; }
        public string Race { get; set; }
        public string Height { get; set; }
        public string Weight { get; set; }
        public string EyeColor { get; set; }
        public string HairColor { get; set; }
    }
}
