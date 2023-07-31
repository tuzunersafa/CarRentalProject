using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entites.Concrete;
using Entites.DTOs;

namespace ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {


            ICarServices carManager = new CarManager(new EfCarDal());
            IBrandServices brandManger = new BrandManager(new EfBrandDal());

            //brandManger.Add(new Brand { Id = 1, Name = "Nissan"});
            //brandManger.Add(new Brand { Id = 2, Name = "Honda" });



            //carManager.Add(new Car
            //{
            //    Id = 2,
            //    BrandId = 2,
            //    ColorId = 2,
            //    DailyPrice = 200,
            //    ModelYear = 2020,
            //    Description = "Honda Civic"
            //});



            //Console.WriteLine(carManager.Get(c => c.BrandId == 1).Description);
            //Console.WriteLine(carManager.GetAll()[0].Description);

            //DetayGetir(carManager);

            var result = carManager.Get(c => c.Id == 1).Data;
            Console.WriteLine(result.Id+" "+result.Description);

        }

        private static void DetayGetir(ICarServices carManager)
        {
            foreach (var item in carManager.GetCarDetails().Data)
            {
                Console.Write(item.Description + " / ");
                Console.Write(item.BrandName + " / ");
                Console.Write(item.ColorName + " / ");
                Console.Write(item.DailyPrice + "TL \n");


            }
        }
    }
}