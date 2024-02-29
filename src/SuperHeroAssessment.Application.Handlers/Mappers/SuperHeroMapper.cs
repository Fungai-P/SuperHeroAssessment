using SuperHeroAssessment.Api.Contracts.Requests;
using SuperHeroAssessment.Api.Contracts.Responses;
using SuperHeroAssessment.Domain.Database;
using SuperHeroAssessment.Domain.Database.Entities;

namespace SuperHeroAssessment.Application.Handlers.Mappers
{
    public static class SuperHeroMapper
    {
        public static SuperHeroEntity Map(this CreateSuperHeroRequest request)
        {
            return new SuperHeroEntity
            {
                Name = request.Name,
                Appearance = request.Appearance,
                Biography = request.Biography,
                PowerStats = request.PowerStats,
                Work = request.Work,
                Connections = request.Connections,
                Image = request.Image
            };
        }

        public static SuperHeroResponse Map(this SuperHeroEntity entity)
        {
            return new SuperHeroResponse
            {
                Id = entity.Id,
                Name = entity.Name,
                Appearance = entity.Appearance,
                Biography = entity.Biography,
                PowerStats = entity.PowerStats,
                Work = entity.Work,
                Connections = entity.Connections,
                Image = entity.Image
            };
        }

        public static SuperHeroEntity Map(this UpdateSuperHeroRequest request)
        {
            return new SuperHeroEntity
            {
                Name = request.Name,
                Appearance = request.Appearance,
                Biography = request.Biography,
                PowerStats = request.PowerStats,
                Work = request.Work,
                Connections = request.Connections,
                Image = request.Image
            };
        }
        public static List<SuperHeroResponse> Map(this List<SuperHeroEntity> entities)
        {
            return entities.Select(x => new SuperHeroResponse
            {
                Id = x.Id,
                Name = x.Name,
                Appearance = x.Appearance,
                Biography = x.Biography,
                PowerStats = x.PowerStats,
                Work = x.Work,
                Connections = x.Connections,
                Image = x.Image
            }).ToList();
        }
    }
}
