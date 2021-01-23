using NorthwindBackend.CORE.DataAccess;
using NorthwindBackend.ENTITIES.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace NorthwindBackend.DAL.Abstract
{
    public interface ICategoryDAL: IEntityRepository<Category>
    {
    }
}
