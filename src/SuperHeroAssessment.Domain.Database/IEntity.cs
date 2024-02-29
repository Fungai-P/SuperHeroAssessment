using MongoDB.Bson.Serialization.Attributes;

namespace SuperHeroAssessment.Domain.Database
{
    public interface IEntity<T>
    {
        [BsonId]
        T Id { get; set; }
    }

    public interface IEntity : IEntity<string>
    {
    }
}
