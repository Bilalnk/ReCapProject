using Core.Entities;

namespace Entities.Concrete
{
    public class CarColor : IEntity
    {

        public string Id { get; set; }

        public string ColorName { get; set; }
    }
}