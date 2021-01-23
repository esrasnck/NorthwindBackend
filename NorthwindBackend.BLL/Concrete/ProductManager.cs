using NorthwindBackend.BLL.Abstract;
using NorthwindBackend.DAL.Abstract;
using NorthwindBackend.DAL.Concrete.EntityFramework;
using NorthwindBackend.ENTITIES.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NorthwindBackend.CORE.Utilities.Results;
using NorthwindBackend.BLL.Constants;

namespace NorthwindBackend.BLL.Concrete
{
    public class ProductManager : IProductService
    {
        // iş katmanında, veri erişim katmanını çağırmamız için, dependancy injection kullanıyoruz.

        // if'lerin yazıldığı yer burası olacak.

        IProductDAL _productDal;
        public ProductManager(IProductDAL productDAL)   // IProductDal 'ı kim implement ederse, onu verebilirim. mesela EfProductDal                                                    implement ediyor. o zaman onu verebilirim gibi
        {
            _productDal = productDAL; 
        }


        public IResult Add(Product product)
        {
            _productDal.Add(product);
            // validasyon kodları, iş kodları vs. buraya çağrılacak
            return new SuccessResult(Messages.ProductAdded);
        }

        public IResult Delete(Product product)
        {
            _productDal.Delete(product);

            return new SuccessResult(Messages.ProductDeleted);
        }

        public IDataResult<Product> GetById(int productId)
        {
            //try
            //{
            //    return new SuccessDataResult<Product>(_productDal.Get(x => x.ProductID == productId));
            //}
            //catch (Exception)
            //{ 
            //    // hatalı bilgi olursa böyle yapabilirz.

            //    throw;
            //}
            return new SuccessDataResult<Product>(_productDal.Get(x => x.ProductID == productId));

        }

        public IDataResult<List<Product>> GetList()
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetList().ToList()) ;  
        }

        public IDataResult<List<Product>> GetListByCategory(int categoryId)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetList(x => x.CategoryID == categoryId).ToList());
        }

        public IResult Update(Product product)
        {
            _productDal.Update(product);
            return new SuccessResult(Messages.ProductUpdated);
        }
    }
}
