using Autofac;
using Autofac.Extensions.DependencyInjection;
using Business.Abstract;
using Business.Concrete;
using Business.DependencyResolvers.Autofac;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;

namespace WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();




            //builder.Services.AddSingleton<ICarServices, CarManager>();
            //builder.Services.AddSingleton<ICarDal, EfCarDal>();
            //builder.Services.AddSingleton<IUserServices, UserManager>();
            //builder.Services.AddSingleton<IUserDal, EfUserDal>();
            //builder.Services.AddSingleton<ICustomerServices, CustomerManager>();
            //builder.Services.AddSingleton<ICustomerDal, EfCustomerDal>();
            //builder.Services.AddSingleton<IRentalServices, RentalManager>();
            //builder.Services.AddSingleton<IRentalDal, EfRentalDal>();


            //builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

            //builder.Host.ConfigureContainer<ContainerBuilder>(options =>
            //{
            //    options.RegisterModule(new AutofacBusinessModule());
            //});



            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Host.UseServiceProviderFactory(services => new AutofacServiceProviderFactory()).ConfigureContainer<ContainerBuilder>(builder => { builder.RegisterModule(new AutofacBusinessModule()); });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();
      

            app.MapControllers();

            app.Run();
        }
    }
}