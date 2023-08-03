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



            //var result = carManager.Get(c => c.Id == 1).Data;
            //Console.WriteLine(result.Id+" "+result.Description);



            //Console.WriteLine(xd.ColorName);



            //Console.WriteLine(result[0].Description);
            //Console.WriteLine(result.FirstOrDefault().Description);
            //DetayGetir(carManager);
            //Console.WriteLine(carManager.GetCarDetailsById(1).Data.Description);

            //Console.WriteLine(carManager.GetCarDetails(c=> c.ColorName == "Red").Message);

            IUserServices userManager = new UserManager(new EfUserDal());
            IRentalServices rentalManager = new RentalManager(new EfRentalDal());

            //userManager.Add(new User
            //{
            //    Email = "beyzagultekinyz@gmail.com",
            //    FirstName = "Beyza",
            //    Id = 2,
            //    LastName = "Gültekin",
            //    Password = "beyza2000"
            //});

            //Ekle_MsgYazdir(userManager);

            //rentalManager.Add(new Rental
            //{
            //    Id = 1,
            //    CarId = 1,
            //    CustomerId = 1,
            //    RentDate = new DateTime(2019, 05, 09, 9, 15, 0),

            //});

            var rentt = new Rental
            {
                
                CarId = 2,
                CustomerId = 1,
                RentDate = new DateTime(2019, 05, 03),

            };


            //Console.WriteLine(rentalManager.Rent(rentt).Message);

            //rentalManager.Add(rentt);

            //RentACar(rentalManager);

            
            Console.WriteLine(rentalManager.Rent(rentt).Message);

        }









        private static void RentACar(IRentalServices rentalManager)
        {
            rentalManager.Rent(new Rental
            {
                Id = 1,
                CarId = 1,
                CustomerId = 1,
                RentDate = new DateTime(2019, 05, 03),
                
            });


        }

        private static void Ekle_MsgYazdir(IUserServices userManager)
        {
            Console.WriteLine(userManager.Add(new User
            {
                Id = 3,
                FirstName = "Esma",
                LastName = "Tüzüner",
                Email = "esmatuzuner@gmail.com",
                Password = "esma2008"
            }).Message);
        }

        private static void DetayGetir(ICarServices carManager)
        {
            foreach (var item in carManager.GetCarsDetails().Data)
            {
                Console.Write(item.Description + " / ");
                Console.Write(item.BrandName + " / ");
                Console.Write(item.ColorName + " / ");
                Console.Write(item.DailyPrice + "TL \n");


            }
        }
    }
}