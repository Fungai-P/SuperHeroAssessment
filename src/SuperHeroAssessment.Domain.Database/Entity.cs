using MongoDB.Bson.Serialization.Attributes;
using System.Runtime.Serialization;

namespace SuperHeroAssessment.Domain.Database
{
    [DataContract]
    [Serializable]
    [BsonIgnoreExtraElements(Inherited = true)]
    public abstract class Entity : IEntity<string>
    {
        [DataMember]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public virtual string Id { get; set; }
    }
}
