using NorthwindBackend.CORE.Utilities.Results;
using NorthwindBackend.ENTITIES.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindBackend.BLL.Abstract
{
    public  interface IProductService
    {
        IDataResult<Product> GetById(int productId);
        IDataResult<List<Product>> GetList();
        IDataResult<List<Product>> GetListByCategory(int categoryId);
        IResult Add(Product product);  // değil Iresult döndürcem. başarı lı başarısız mı? (bool yani)
        IResult Delete(Product product);
        IResult Update(Product product);

    }
}
