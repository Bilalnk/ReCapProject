using Core.Entities;

namespace Entities.Concrete
{
    public class Car : IEntity
    {
        public string Id { get; set; }
        public string BrandId { get; set; }
        public string ColorId { get; set; }
        public int ModelYear { get; set; }
        public decimal DailyPrice { get; set; }
        public string Description { get; set; }

        public override string ToString()
        {
            return this.Id + ", " + BrandId + ", " + ColorId + ", " + ModelYear + ", " + DailyPrice + ", " +
                   Description;
        }
    }
}