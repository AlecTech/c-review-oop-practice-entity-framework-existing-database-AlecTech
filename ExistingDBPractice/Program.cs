using ExistingDBPractice.Model;
using System;
using System.Linq;

namespace ExistingDBPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;
            Console.Write("Please Enter First Name to lookup in DB:");
            input = Console.ReadLine().Trim();

            using(PersonContext context = new PersonContext())
            {
                Person person = context.Person.Where(x => x.FirstName.ToLower() == input.ToLower()).Single();

                //List<Vehicle> vehicles = context.Vehicles.Where(x => x.ManufacturerId == manufacturer.Id).ToList();

                Console.WriteLine($"-{person.FirstName} {person.LastName}");
            }
        }
    }
}
