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
                 
                Console.Write("Please Enter First Name to lookup in DB or quit to exit:");
                input = Console.ReadLine().Trim().ToLower();

                using(PersonContext context = new PersonContext())
                {

                    try
                    {
                        //get everything from context.Person first, then chose only that row which is equals to the input from the user
                        Person person = context.Person.Where(x => x.FirstName.ToLower() == input.ToLower()).Single();
                        //JOIN Person table with Phonenumber table based on PersonId and ID columns
                        List<Phonenumber> phone = context.Phonenumber.Where(x => x.PersonId == person.Id).ToList();

                        // if "phone" object has 3 #s assosiated with input name it will loop 3 times.
                        foreach (Phonenumber phones in phone)
                        {   //print out row from person query FirstName and LastName and then look into phone object and grab all phones that correlate with PersonId 
                            Console.WriteLine($"-{person.FirstName} {person.LastName} {phones.Number}");
                        }
                        
                    }

                    catch
                    {
                        Console.WriteLine("ERROR: Name not found.");     
                    }

                }//if true keep looping
            } while (input != "quit");
        }
    }
}
