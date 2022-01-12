using Core.Entities;

namespace Entities.Concrete
{
    public class Color : IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public override string ToString()
        {
            return Id + " " + Name;
        }
    }
}