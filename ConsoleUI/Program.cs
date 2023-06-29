using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entites.Concrete;

namespace ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            
            ICarServices carManager  = new CarManager(new EfCarDal());
            IBrandServices brandManger = new BrandManager(new EfBrandDal());

            //brandManger.Add(new Brand { Id = 1, Name = "Nissan"});


            //carManager.Add(new Car
            //{
            //    Id = 1,
            //    BrandId = 1,
            //    ColorId = 1,
            //    DailyPrice = 100,
            //    ModelYear = 2000,
            //    Description = "Nissan Qashqai"
            //});

            Console.WriteLine(carManager.Get(c => c.BrandId == 1).Description);




























        }
    }
}