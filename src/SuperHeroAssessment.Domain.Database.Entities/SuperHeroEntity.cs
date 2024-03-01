using SuperHeroAssessment.Domain.Models;

namespace SuperHeroAssessment.Domain.Database.Entities
{
    public class SuperHeroEntity : Entity
    {
        public string CharacterId { get; set; }
        public string Name { get; set; }
        public Appearance Appearance { get; set; }
        public Biography Biography { get; set; }
        public PowerStats PowerStats { get; set; }
        public Work Work { get; set; }
        public Connections Connections { get; set; }
        public Image Image { get; set; }
    }
}
