using ExistingDBPractice.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ExistingDBPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;
            do
            {
                 
                Console.Write("Please Enter First Name to lookup in DB:");
                input = Console.ReadLine().Trim().ToLower();

                using(PersonContext context = new PersonContext())
                {

                    try
                    {
                        
                        Person person = context.Person.Where(x => x.FirstName.ToLower() == input.ToLower()).Single();

                        List<Phonenumber> phone = context.Phonenumber.Where(x => x.PersonId == person.Id).ToList();

                        foreach (Phonenumber phones in phone)
                        {
                            Console.WriteLine($"-{person.FirstName} {person.LastName} {phones.Number}");
                        }
                        
                    }

                    catch
                    {
                        Console.WriteLine("ERROR: Name not found.");
                        //input = "";
                    }

                }
            } while (input != "quit");
        }
    }
}
