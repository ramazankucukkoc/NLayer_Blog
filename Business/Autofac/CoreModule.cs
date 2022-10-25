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
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();

            builder.RegisterType<EfCategoryDal>().As<ICategoryDal>();
            builder.RegisterType<EfProductDal>().As<IProductDal>();
            
            builder.RegisterType<CategoryManager>().As<ICategoryService>();
            builder.RegisterType<ProductManager>().As<IProductService>();

            builder.RegisterType<EfCompanyDal>().As<ICompanyDal>();
            builder.RegisterType<CompanyManager>().As<ICompanyService>();

            builder.RegisterType<EfCompanyTransactionDal>().As<ICompanyTransactionDal>();
            builder.RegisterType<CompanyTransactionManager>().As<ICompanyTransactionService>();

            builder.RegisterType<EfCustomerDal>().As<ICustomerDal>();
            builder.RegisterType<CustomerManager>().As<ICustomerService>();

            builder.RegisterType<EfCustomerTransactionDal>().As<ICustomerTransactionDal>();
            builder.RegisterType<CustomerTransactionManager>().As<ICustomerTrasanctionService>();

            builder.RegisterType<EfPersonelDal>().As<IPersonelDal>();
            builder.RegisterType<PersonelManager>().As<IPersonelService>();

            builder.RegisterType<EfDepartmanDal>().As<IDepartmanDal>();
            builder.RegisterType<DepartmanService>().As<IDepartmanService>();

            //builder.RegisterType<IArticleServi>().As<EfArticleDal>();


        }
    }
}
