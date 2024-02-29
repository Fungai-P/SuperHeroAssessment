using SuperHeroAssessment.Domain.Models;

namespace SuperHeroAssessment.Api.Contracts.Responses.Mappers
{
    public static class SuperHeroResponseMapper
    {
        public static AppearanceResponse Map(this SuperHeroResponse response, Appearance model)
        {
            return new AppearanceResponse
            {
                Response = "Success",
                Id = response.Id,
                Name = response.Name,
                EyeColor = model.EyeColor,
                Gender = model.Gender,
                HairColor = model.HairColor,
                Height = model.Height,
                Race = model.Race,
                Weight = model.Weight
            };
        }

        public static BiographyResponse Map(this SuperHeroResponse response, Biography model)
        {
            return new BiographyResponse
            {
                Response = "Success",
                Id = response.Id,
                Name = response.Name,
                Aliases = model.Aliases,
                Alignment = model.Alignment,
                AlterEgos = model.AlterEgos,
                FirstAppearance = model.FirstAppearance,
                FullName = model.FullName,
                PlaceOfBirth = model.PlaceOfBirth,
                Publisher = model.Publisher
            };
        }

        public static ConnectionsResponse Map(this SuperHeroResponse response, Connections model)
        {
            return new ConnectionsResponse
            {
                Response = "Success",
                Id = response.Id,
                Name = response.Name,
                GroupAffiliation = model.GroupAffiliation,
                Relatives = model.Relatives
            };
        }

        public static ImageResponse Map(this SuperHeroResponse response, Image model)
        {
            return new ImageResponse
            {
                Response = "Success",
                Id = response.Id,
                Name = response.Name,
                Url = model.Url
            };
        }

        public static PowerStatsResponse Map(this SuperHeroResponse response, PowerStats model)
        {
            return new PowerStatsResponse
            {
                Response = "Success",
                Id = response.Id,
                Name = response.Name,
                Combat = model.Combat,
                Durability = model.Durability,
                Intelligence = model.Intelligence,
                Power = model.Power,
                Speed = model.Speed,
                Strength = model.Strength
            };
        }

        public static WorkResponse Map(this SuperHeroResponse response, Work model)
        {
            return new WorkResponse
            {
                Response = "Success",
                Id = response.Id,
                Name = response.Name,
                BaseOfOperation = model.BaseOfOperation,
                Occupation = model.Occupation
            };
        }
    }
}
