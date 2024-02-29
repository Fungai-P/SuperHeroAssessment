namespace SuperHeroAssessment.Domain.Database.Attributes
{
    public class CollectionName : Attribute
    {
        public virtual string Name { get; private set; }

        public CollectionName(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException("Empty collection name is not allowed.", "name");
            Name = name;
        }
    }
}
