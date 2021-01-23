using NorthwindBackend.CORE.DataAccess.EntityFramework;
using NorthwindBackend.DAL.Abstract;
using NorthwindBackend.DAL.Concrete.EntityFramework.Contexts;
using NorthwindBackend.ENTITIES.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace NorthwindBackend.DAL.Concrete.EntityFramework
{
    public class EfProductDal : EfEntityRepositoryBase<Product,NorthwindContext>, IProductDAL
    {
        // efEntityrepositorybase yazıldığı anda, IproductDal implement edilmek istemiyor

    }
}
