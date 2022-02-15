using System.Collections.Generic;
using System.Linq;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, ReCapContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = from c in context.Cars
                    join b in context.Brand
                        on c.Id equals b.id
                    join color in context.Color
                        on c.Id equals color.Id
                    select new CarDetailDto
                    {
                        CarId = c.Id, Color = color.Name, Description = c.Description, BrandName = b.Name,
                        ModelYear = c.ModelYear
                    };

                return result.ToList();
            }
        }
    }
}