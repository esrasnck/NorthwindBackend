using NorthwindBackend.CORE.Utilities.Results;
using NorthwindBackend.ENTITIES.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace NorthwindBackend.BLL.Abstract
{
    public interface ICategoryService
    {

        IDataResult<Category> GetById(int categoryId );
        IDataResult<List<Category>> GetList();

        //IDataResult<List<Category>> GetListByProduct(int productId);
        IResult Add(Category category);  // değil Iresult döndürcem. başarı lı başarısız mı? (bool yani)
        IResult Delete(Category category);
        IResult Update(Category category);
    }
}
