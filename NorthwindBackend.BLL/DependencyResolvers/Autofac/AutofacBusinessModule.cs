using Autofac;
using NorthwindBackend.BLL.Abstract;
using NorthwindBackend.BLL.Concrete;
using NorthwindBackend.DAL.Abstract;
using NorthwindBackend.DAL.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace NorthwindBackend.BLL.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // configurasyon yaptığımız yer

            // controller bunu istiyor
            builder.RegisterType<ProductManager>().As<IProductService>(); // IproductServise isteyince ctor da, ona productmanager ver demek

            // bussiness'da iproductdal istiyordu
            builder.RegisterType<EfProductDal>().As<IProductDAL>();


            //=> api'da yapılandıracaz... autofac'i kullanamsı gerektiğini api ye söyleyecez. bunu eskiden 2.1 de direkt startup' da yapardık. değişen teknoloji ile burada yapıyoruz. => program.cs'e git ( create host builder operasyonuna)

            builder.RegisterType<CategoryManager>().As<ICategoryService>();

            builder.RegisterType<EfCategoryDal>().As<ICategoryDAL>();

            builder.RegisterType<UserManager>().As<IUserService>();

            builder.RegisterType<EfUserDal>().As<IUserDAL>();
        }
    }
}
