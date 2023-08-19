using Autofac;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entites.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CarManager>().As<ICarServices>().SingleInstance();
            builder.RegisterType<RentalManager>().As<IRentalServices>().SingleInstance();
            builder.RegisterType<ColorManager>().As<IColourServices>().SingleInstance();
            builder.RegisterType<UserManager>().As<IUserServices>().SingleInstance();
            builder.RegisterType<CustomerManager>().As<ICustomerServices>().SingleInstance();
            builder.RegisterType<BrandManager>().As<IBrandServices>().SingleInstance();


            builder.RegisterType<EfCarDal>().As<ICarDal>().SingleInstance();
            builder.RegisterType<EfRentalDal>().As<IRentalDal>().SingleInstance();
            builder.RegisterType<EfColourDal>().As<IColourDal>().SingleInstance();
            builder.RegisterType<EfUserDal>().As<IUserDal>().SingleInstance();
            builder.RegisterType<EfCustomerDal>().As<ICustomerDal>().SingleInstance();
            builder.RegisterType<EfBrandDal>().As<IBrandDal>().SingleInstance();

        }
    }
}
