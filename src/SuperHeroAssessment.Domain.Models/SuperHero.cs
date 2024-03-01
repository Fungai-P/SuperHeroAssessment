namespace SuperHeroAssessment.Domain.Models
{
    public class SuperHero
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
