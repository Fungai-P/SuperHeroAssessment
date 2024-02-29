namespace SuperHeroAssessment.Api.Contracts.Responses
{
    public class BiographyResponse : BaseResponse
    {
        public string FullName { get; set; }
        public string AlterEgos { get; set; }
        public string Aliases { get; set; }
        public string PlaceOfBirth { get; set; }
        public string FirstAppearance { get; set; }
        public string Publisher { get; set; }
        public string Alignment { get; set; }
    }
}
