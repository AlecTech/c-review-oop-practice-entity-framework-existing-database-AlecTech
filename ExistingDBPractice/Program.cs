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

                try
                {
                    Person person = context.Person.Where(x => x.FirstName.ToLower() == input.ToLower()).Single();

                    Console.WriteLine($"-{person.FirstName} {person.LastName}");
                }

                catch
                {
                    Console.WriteLine("ERROR: Name not found.");
                }
                
            }
        }
    }
}
