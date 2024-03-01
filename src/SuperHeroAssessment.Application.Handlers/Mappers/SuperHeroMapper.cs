using SuperHeroAssessment.Api.Contracts.Responses;
using SuperHeroAssessment.Domain.Database.Entities;
using SuperHeroAssessment.Domain.Models;

namespace SuperHeroAssessment.Application.Handlers.Mappers
{
    public static class SuperHeroMapper
    {
        public static SuperHeroEntity Map(this SuperHero model, bool upsert)
        {
            return new SuperHeroEntity
            {
                CharacterId = model.Id,
                Name = model.Name,
                Appearance = model.Appearance,
                Biography = model.Biography,
                PowerStats = model.PowerStats,
                Work = model.Work,
                Connections = model.Connections,
                Image = model.Image
            };
        }


        public static SuperHeroResponse Map(this SuperHero model)
        {
            return new SuperHeroResponse
            {
                Id = model.Id,
                Name = model.Name,
                Appearance = model.Appearance,
                Biography = model.Biography,
                PowerStats = model.PowerStats,
                Work = model.Work,
                Connections = model.Connections,
                Image = model.Image
            };
        }

        public static List<SuperHeroResponse> Map(this List<SuperHero> models)
        {
            return models.Select(x => x.Map()).ToList();
        }
    }
}
