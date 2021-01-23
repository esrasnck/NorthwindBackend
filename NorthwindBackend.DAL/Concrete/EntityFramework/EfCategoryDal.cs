using NorthwindBackend.CORE.DataAccess.EntityFramework;
using NorthwindBackend.DAL.Abstract;
using NorthwindBackend.DAL.Concrete.EntityFramework.Contexts;
using NorthwindBackend.ENTITIES.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace NorthwindBackend.DAL.Concrete.EntityFramework
{
   public class EfCategoryDal: EfEntityRepositoryBase<Category, NorthwindContext>, ICategoryDAL
    {
    }
}
