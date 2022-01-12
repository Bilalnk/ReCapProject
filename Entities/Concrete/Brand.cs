using Core.Entities;

namespace Entities.Concrete
{
    public class Brand : IEntity
    {
        public int id { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return id + " " + Name;
        }
    }
}