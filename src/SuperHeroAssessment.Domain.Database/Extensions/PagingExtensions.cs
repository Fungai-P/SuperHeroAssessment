using MongoDB.Bson;

namespace SuperHeroAssessment.Domain.Database.Extensions
{
    public static class PagingExtensions
    {
        public static IQueryable<T> Page<T>(IQueryable<T> source, int page, int pageSize)
        {
            return source.Skip((page - 1) * pageSize).Take(pageSize);
        }

        public static BsonValue Find(this BsonDocument bsonDocument, string name)
        {
            var segments = name.Split('.');
            var length = segments.Length;
            var thisDocument = bsonDocument;

            for (int i = 0; i < segments.Length; i++)
            {
                if (thisDocument.Contains(segments[i]) == false)
                    return null;

                if (i == segments.Length - 1)
                    return thisDocument.GetValue(segments[i]);

                if (thisDocument.IsBsonDocument)
                    thisDocument = (BsonDocument)thisDocument.GetValue(segments[i]);
            }

            return null;
        }
    }
}
