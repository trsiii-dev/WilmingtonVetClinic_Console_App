using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace WilmingtonVetClinic
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Print welcome message
            Console.WriteLine("Welcome to the Wilmington Veterinary Clinic!\n");

            // Prompt for first name
            Console.Write("Enter your first name: ");
            string first = Console.ReadLine();

            // Prompt for last name
            Console.Write("Enter your last name: ");
            string last = Console.ReadLine();

            // Concatenate first and last
            string fullName = String.Concat(first, " ", last);

            // Prompt for town
            Console.Write("Enter the town of your residence: ");
            string town = Console.ReadLine();

            // Prompt for state
            Console.Write("Enter the state of your residence: ");
            string state = Console.ReadLine().ToUpper();

            // Concatenate town and state
            string location = String.Concat(town, ", ", state);

            // Prompt for pets
            Console.Write("Enter the number of pets in your household: ");
            string pets = Console.ReadLine();

            // Administrative fees
            int adminFee = 25;
            int maxAdminFee = 100;
            int currentAdminFee = 0;

            if (int.Parse(pets) <= 4)
            {
                currentAdminFee = int.Parse(pets) * adminFee;
            }
            else
            {
                currentAdminFee = maxAdminFee;
            }

            // Print results
            Console.WriteLine("\nCurrent Name: " + fullName);
            Console.WriteLine("Current Location: " + location);
            Console.WriteLine("Number of pets: " + pets);
            Console.WriteLine("Total Household Administrative Fee: {0}", currentAdminFee.ToString("C", CultureInfo.GetCultureInfo("en-US")) + "\n");

            // Prompt for pet names
            int p = 0;
            while (true)
            {
                Console.Write("Enter your pet's name: ");
                Console.ReadLine();

                p++;

                if (p >= int.Parse(pets))
                {
                    break;
                }

            }


            // Print admin fee
            

            // Print terminate message
            Console.WriteLine("\nPress Enter twice to terminate...");
            Console.Read();

        }
    }
}
