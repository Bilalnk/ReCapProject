using Core.Entities;

namespace Entities.Concrete
{
    public class Color : IEntity
    {

        public string Id { get; set; }

        public string ColorName { get; set; }
    }
}