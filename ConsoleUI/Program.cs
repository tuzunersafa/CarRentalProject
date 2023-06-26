using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;

namespace ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            
            ICarServices carManager  = new CarManager(new InMemoryCarDal());


            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Id);
            }
            Console.WriteLine(  );
            foreach (var car in carManager.GetById(4))
            {
                Console.WriteLine(car.DailyPrice);
            }
            



























        }
    }
}