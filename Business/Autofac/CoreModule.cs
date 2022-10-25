using Autofac;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Business.Autofac
{
    public class CoreModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<EfCategoryDal>().As<ICategoryDal>();
            builder.RegisterType<EfProductDal>().As<IProductDal>();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();
            
            builder.RegisterType<CategoryManager>().As<ICategoryService>();
            builder.RegisterType<ProductManager>().As<IProductService>();

            //builder.RegisterType<IArticleServi>().As<EfArticleDal>();


        }
    }
}
