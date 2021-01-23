using NorthwindBackend.BLL.Abstract;
using NorthwindBackend.CORE.Utilities.Results;
using NorthwindBackend.DAL.Abstract;
using NorthwindBackend.ENTITIES.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using NorthwindBackend.BLL.Constants;
using System.Linq;

namespace NorthwindBackend.BLL.Concrete
{
    public class CategoryManager : ICategoryService
    {

        ICategoryDAL _categoryDal;
        public CategoryManager(ICategoryDAL categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public IResult Add(Category category)
        {
            _categoryDal.Add(category);

            return new SuccessResult(Messages.CategoryAdded); // bekle biraz.
        }

        public IResult Delete(Category category)
        {
            _categoryDal.Delete(category);

            return new SuccessResult(Messages.CategoryDeleted);
            
        }

        public IDataResult<Category> GetById(int categoryId)
        {
            return new SuccessDataResult<Category>(_categoryDal.Get(x=> x.CategoryID==categoryId));
        }

        public IDataResult<List<Category>> GetList()
        {
            return new SuccessDataResult<List<Category>>(_categoryDal.GetList().ToList());
        }

        public IDataResult<List<Category>> GetListByCategory(int productId)
        {
            throw new NotImplementedException();
        }

        //public IDataResult<List<Category>> GetListByProduct(int productId)
        //{
        //    // sonra bak:)
        //     //return new SuccessDataResult<List<Category>>(_categoryDal.GetList(x => x.Products.FirstOrDefault(x => x.ProductID == productId)));
        //}

        public IResult Update(Category category)
        {
            _categoryDal.Update(category);

            return new SuccessResult(Messages.CategoryUpdated);
        }
    }
}
