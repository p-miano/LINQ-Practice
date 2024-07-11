using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_Practice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Create each building
            Building empireState = new Building("Empire State Building", 2248355, 15);
            Building oneWorld = new Building("One World Trade Center", 3501274, 12);
            Building plazaHotel = new Building("The Plaza Hotel", 868375, 20);
            Building newYorkLibrary = new Building("New York Public Library", 646000, 10);
            Building saintPatricks = new Building("Saint Patrick’s Cathedral", 101760, 8);

            // Create list of buildings
            List<Building> myBuildings = new List<Building>
            {
                empireState, oneWorld, plazaHotel, newYorkLibrary, saintPatricks
            };

            Console.WriteLine("List of buildings: ");
            foreach (var building in myBuildings)
            {                
                Console.WriteLine(building.Name);
            }
            Console.WriteLine();

            // Calculate the total estimated tax over all buildings in a single number using a LINQ method
            double totalEstimatedTax = myBuildings.Sum(building => building.CalculateTax());

            Console.WriteLine($"The total estimated tax is {totalEstimatedTax.ToString("C")}");
            Console.WriteLine();

            // Calculate the total estimated tax over all buildings in a single number using LINQ Query Syntax

            var totalEstimatedTaxQuery = (from building in myBuildings
                                          select building.CalculateTax()).Sum();

            Console.WriteLine($"The total estimated tax is {totalEstimatedTaxQuery.ToString("C")}");
            Console.WriteLine();

            // Implement a list of the the most expensive buildings using LINQ methods.

            var expensiveBuildings = myBuildings.Where(building => building.TaxPerSize >= 15).ToList();

            Console.WriteLine($"Expensive Buildings:");
            expensiveBuildings.ForEach(building => Console.WriteLine(building.Name));
            Console.WriteLine();

            // Implement a list of the the most expensive buildings using LINQ Query Syntax.

            var expensiveBuildingsQuery = (from building in myBuildings
                                           where building.TaxPerSize >= 15
                                           select building).ToList();

            Console.WriteLine($"Expensive Buildings:");
            expensiveBuildingsQuery.ForEach(building => Console.WriteLine(building.Name));
            Console.WriteLine();

            Console.ReadKey();

        }
    }

    public class Building
    {
        public string Name { get; set; }
        public double Size { get; set; }
        public double TaxPerSize { get; set; }    

        public Building(string name, double size, double taxPerSize)
        {
            Name = name;
            Size = size;
            TaxPerSize = taxPerSize;
        }

        public double CalculateTax()
        {
            return Size * TaxPerSize;
        }
    }
}
