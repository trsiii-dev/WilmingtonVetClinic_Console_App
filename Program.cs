/*

 To-Do:
    1. Finish pet class (see pet class)
    2. Need to use Pet class to add pet parameters (see first while loop)
    3. Check petCodes variable in second while loop

 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.CodeDom;

namespace WilmingtonVetClinic
{
    internal class Program
    {
        class Pet
        {
            // Lists for pet parameters
            private List<string> _petNames = new List<string>();
            private List<char> _petTypes = new List<char>();
            private List<int> _petAges = new List<int>();

            // Constructor method to add parameters to lists
            public void AddPet(string petName, char petType, int petAge)
            {
                _petNames.Add(petName);
                _petTypes.Add(petType);
                _petAges.Add(petAge);
            }

            // Getters (read-only)
            public List<string> PetNames
            {
                get { return new List<string>(_petNames); }
            }

            public List<char> PetTypes
            {
                get { return new List<char>(_petTypes); }
            }

            public List<int> PetAges
            {
                get { return new List<int>(_petAges); }
            }

            // Keeping count (an object must be responsible for itself)
            public int Count
            {
                get { return _petNames.Count; }
            }

            // 1. Method to get pet info?
        }

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

            // Prompt for pet names
            int p = 0;
            while (true)
            {
                Console.Write("Enter your pet's name: ");
                string nameInput = Console.ReadLine();
                // 2. need to use Pet class to add pet name

                // Show pet codes
                Console.WriteLine("The following pet type codes are available: ");
                foreach(KeyValuePair<char, string> code in petCodes)
                {
                    Console.WriteLine("\t" + code.Key + "\t" + code.Value);
                }

                // Prompt for pet code
                Console.Write($"Enter {nameInput}'s pet type code: ");
                char codeInput = Convert.ToChar(Console.ReadLine().ToUpper());
                // 2. need to use Pet class to add pet code

                // Prompt for pet age
                Console.Write($"Enter {nameInput}'s age: ");
                int ageInput = Convert.ToInt32(Console.ReadLine());
                // 2. need to use Pet class to add pet age

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
                foreach(KeyValuePair<char, string> key in /*3. petCodes variable*/)
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
