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

            // Dictionary for pet codes
            Dictionary<char, string> petCodes = new Dictionary<char, string>
            {
                {'B', "Bird"},
                {'C', "Cat"},
                {'D', "Dog"},
                {'R', "Reptile"}
            };

            // List for pet names
            List<string> petNames = new List<string>();

            // List for pet type codes
            List<char> petTypes = new List<char>();

            // List for pet ages
            List<int> petAges = new List<int>();


            // Prompt for pet names
            int p = 0;
            while (true)
            {
                Console.Write("Enter your pet's name: ");
                string nameInput = Console.ReadLine();
                petNames.Add(nameInput);

                // Show pet codes
                Console.WriteLine("The following pet type codes are available: ");
                foreach(KeyValuePair<char, string> code in petCodes)
                {
                    Console.WriteLine("\t" + code.Key + "\t" + code.Value);
                }

                // Prompt for pet code
                Console.Write($"Enter {nameInput}'s pet type code: ");
                char codeInput = Convert.ToChar(Console.ReadLine().ToUpper());
                petTypes.Add(codeInput);

                // Prompt for pet age
                Console.Write($"Enter {nameInput}'s age: ");
                int ageInput = Convert.ToInt32(Console.ReadLine());
                petAges.Add(ageInput);

                // Insert break for readability
                Console.WriteLine();

                // Increment counter
                p++;

                // if counter is greater than or equal to pets, break out of while loop
                if (p >= int.Parse(pets))
                {
                    break;
                }

            }

            bool quit = false;
            while(quit != true) 
            {
                // Prompt for pet code to display pets of that type
                Console.WriteLine("Enter pet type to see listings, or 'Q' to Quit");
                foreach(KeyValuePair<char, string> key in petCodes)
                {
                    Console.WriteLine("\t" + key.Key + "\t" + key.Value);
                }

                char input = Convert.ToChar(Console.ReadLine().ToUpper());

                if(input == 'Q')
                {
                    break;
                }
                else if (input == 'B')
                {
                    Console.WriteLine("The following pets are of type Bird: ");
                }
                else if (input == 'C')
                {
                    Console.WriteLine("The following pets are of type Cat: ");
                }
                else if (input == 'D')
                {
                    Console.WriteLine("The following pets are of type Dog: ");
                }
                else if (input == 'R')
                {
                    Console.WriteLine("The following pets are of type Reptile: ");
                }
                else
                {
                    Console.WriteLine("That is not a valid response!");
                }
            }

            // Print terminate message
            Console.WriteLine("\nPress Enter twice to terminate...");
            Console.Read();

        }
    }
}
