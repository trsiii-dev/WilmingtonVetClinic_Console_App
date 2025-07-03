using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace WilmingtonVetClinic
{

    class Pet
    {
        // Private variables //
        private string _name;
        private char _petType;
        private int _age;

        // Dictionary for pet codes - notice static keyword - this allows us to call the dictionary from the Main class without having to instantiate a Pet object first //
        public static Dictionary<char, string> PetCodes = new Dictionary<char, string>
        {
            {'B', "Bird"},
            {'C', "Cat"},
            {'D', "Dog"},
            {'R', "Reptile"}
        };

        public string Name // property
        {
            get { return _name; } // get method
            set { _name = value; } // set method
        }

        public char PetType // property
        {
            get { return _petType; } // get method
            set { _petType = value; } // set method
        }

        public int Age // property
        {
            get { return _age; } // get method
            set { _age = value; } // set method
        }

        // Void return type means we aren't returning anything. pets and petTypeCode are List<Pets> and char input parameters respectively //
        public static void PrintNamesList(List<Pet> pets, char petTypeCode)
        {
            foreach (Pet pet in pets)
            {
                // Loop through each Pet object in List<Pet>...check if pet type code in input parameter value, if so, print the name and age of the pet from the Pet object in current iteration of loop //
                if (pet.PetType == petTypeCode)
                {
                    Console.WriteLine(pet.Name + " (" + pet.Age.ToString() + ")");
                }

            }
        }


    }

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
            int pets;
            Console.Write("Enter the number of pets in your household: ");
            
            // Loop until a valid integer is entered
            while (!Int32.TryParse(Console.ReadLine(), out pets))
            {
                Console.WriteLine("Invalid amount of pets entered. Please enter a whole number.");
                Console.Write("Enter the number of pets in your household: ");
            }

            // Administrative fees
            int adminFee = 25;
            int maxAdminFee = 100;
            int currentAdminFee = 0;

            if (pets <= 4)
            {
                currentAdminFee = pets * adminFee;
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

            // List of objects to hold Pet objects //
            List<Pet> listPets = new List<Pet>();

            // Prompt for pet names
            int p = 0;
            while (true)
            {
                Console.Write("Enter your pet's name: ");
                string nameInput = Console.ReadLine();

                // Show pet codes
                Console.WriteLine("The following pet type codes are available: ");
                foreach (KeyValuePair<char, string> code in Pet.PetCodes)
                {
                    Console.WriteLine("\t" + code.Key + "\t" + code.Value);
                }

                // Prompt for pet code in try...catch
                char codeInput = ' ';
                try
                {
                    Console.Write($"Enter {nameInput}'s pet type code: ");
                    
                    // This will throw a FormatException if the input is not a single character
                    codeInput = Convert.ToChar(Console.ReadLine().ToUpper());
                }
                catch (FormatException)
                {
                    Console.WriteLine("\nInvalid pet code entered. A single character is required. The program will now exit.");

                    // Exit the program
                    Environment.Exit(-1);
                }


                // Prompt for pet age with input validation
                int ageInput;
                Console.Write($"Enter {nameInput}'s age: ");

                // Loop until a valid integer is entered for the age of each pet
                while (!Int32.TryParse(Console.ReadLine(), out ageInput))
                {
                    Console.WriteLine("Invalid pet age entered. Please enter a whole number for the pet's age.");
                    Console.Write($"Enter {nameInput}'s age: ");
                }

                // Create new pet object //
                Pet thisPet = new Pet();
                thisPet.Name = nameInput;
                thisPet.PetType = codeInput;
                thisPet.Age = ageInput;

                // Add pet to pet list //
                listPets.Add(thisPet);

                // Insert break for readability
                Console.WriteLine();

                // Increment counter
                p++;

                // If counter is greater than or equal to pets, break out of while loop
                if (p >= pets)
                {
                    break;
                }

            }

            while (true)
            {
                // Display pet type code legend
                Console.WriteLine("The following pet type codes are available: ");
                foreach (KeyValuePair<char, string> code in Pet.PetCodes)
                {
                    Console.WriteLine("\t" + code.Key + "\t" + code.Value);
                }

                // Try...catch for user entering desired pet type code or q for quit. Will be converted to upper case.
                char codeToReview = ' ';
                try
                {
                    Console.Write($"Enter pet type code to see listing of names or 'Q' to Quit: ");
                    
                    // This will throw a FormatException if the input is not a single character
                    codeToReview = Convert.ToChar(Console.ReadLine().ToUpper());
                }
                catch (FormatException)
                {
                    Console.WriteLine("\nInvalid pet code entered. A single character is required. The program will now exit.");

                    // Exit the program
                    Environment.Exit(-1);
                }

                if (codeToReview == 'Q')
                {
                    break;
                }

                // Print the pets with the correct code
                Console.WriteLine($"\nPets of type '{codeToReview}':");
                Pet.PrintNamesList(listPets, codeToReview);
                
                // Add a blank line for readability
                Console.WriteLine();

            }

            // Print terminate message
            Console.WriteLine("\nPress Enter twice to terminate...");
            Console.Read();

        }
    }
}