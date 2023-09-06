using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utitilies.Helpers.FileHelpers;
using Core.Utitilies.Interceptors;
using Core.Utitilies.Security.JWT;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entites.Concrete;
using Microsoft.AspNetCore.Http;
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
            builder.RegisterType<CarImageManager>().As<ICarImageServices>().SingleInstance();
            builder.RegisterType<UserManager>().As<IUserServices>().SingleInstance();



            builder.RegisterType<EfCarDal>().As<ICarDal>().SingleInstance();
            builder.RegisterType<EfRentalDal>().As<IRentalDal>().SingleInstance();
            builder.RegisterType<EfColourDal>().As<IColourDal>().SingleInstance();
            builder.RegisterType<EfUserDal>().As<IUserDal>().SingleInstance();
            builder.RegisterType<EfCustomerDal>().As<ICustomerDal>().SingleInstance();
            builder.RegisterType<EfBrandDal>().As<IBrandDal>().SingleInstance();
            builder.RegisterType<EfCarImageDal>().As<ICarImageDal>().SingleInstance();

            builder.RegisterType<ImageFileHelper>().As<IFileHelper>().SingleInstance();


            builder.RegisterType<HttpContextAccessor>().As<IHttpContextAccessor>();
            builder.RegisterType<AuthManager>().As<IAuthServices>();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>();





            var assembly = System.Reflection.Assembly.GetExecutingAssembly();
            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}
