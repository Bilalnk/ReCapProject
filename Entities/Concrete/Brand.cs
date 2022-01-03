using Core.Entities;

namespace Entities.Concrete
{
    public class Brand : IEntity
    {
        public int id { get; set; }
        public string brand { get; set; }
    }
}