﻿using System.Collections.Generic;
using Entities;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface ICarDal : IEntityRepository<Car>
    {
    }
}