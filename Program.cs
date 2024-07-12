using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ_Practice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Create each building
            Building empireState = new Building("Empire State Building", "New York", 2248355, 15);
            Building oneWorld = new Building("One World Trade Center", "New York", 3501274, 12);
            Building plazaHotel = new Building("The Plaza Hotel", "New York", 868375, 20);
            Building newYorkLibrary = new Building("New York Public Library", "New York", 646000, 10);
            Building saintPatricks = new Building("Saint Patrick’s Cathedral", "New York", 101760, 8);
            Building willisTower = new Building("Willis Tower", "Chicago", 4500000, 18);
            Building johnHancock = new Building("John Hancock Center", "Chicago", 2800000, 16);
            Building aqcuaTower = new Building("Aqua Tower", "Chicago", 1900000, 14);

            // Create list of buildings
            List<Building> myBuildings = new List<Building>
            {
                empireState, oneWorld, plazaHotel, newYorkLibrary, saintPatricks, willisTower, johnHancock, aqcuaTower
            };

            Console.WriteLine("List of buildings: ");
            foreach (var building in myBuildings)
            {                
                Console.WriteLine($"{building.Name}, {building.City}, size: {building.Size:N0}, tax: {building.TaxPerSize:C}");
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

            // Implement a list of the the most expensive buildings using LINQ methods

            var expensiveBuildings = myBuildings.Where(building => building.TaxPerSize >= 15).ToList();

            Console.WriteLine($"Expensive buildings:");
            expensiveBuildings.ForEach(building => Console.WriteLine(building.Name));
            Console.WriteLine();

            // Implement a list of the the most expensive buildings using LINQ Query Syntax

            var expensiveBuildingsQuery = (from building in myBuildings
                                           where building.TaxPerSize >= 15
                                           select building).ToList();

            Console.WriteLine($"Expensive buildings:");
            expensiveBuildingsQuery.ForEach(building => Console.WriteLine(building.Name));
            Console.WriteLine();

            // Implement a list of the building ordered by size using LINQ methods.

            var buildingsOrderedBySize = myBuildings.OrderBy(b => b.Size).ToList();

            Console.WriteLine($"Buildings ordered by size: ");
            buildingsOrderedBySize.ForEach(b => Console.WriteLine(b.Name));
            Console.WriteLine();

            // Implement a list of the building ordered by size using LINQ Query Syntax

            var buildingsOrderedBySizeQuery = (from b in myBuildings
                                               orderby b.Size
                                               select b).ToList();

            Console.WriteLine($"Buildings ordered by size: ");
            buildingsOrderedBySizeQuery.ForEach(b => Console.WriteLine(b.Name));
            Console.WriteLine();

            // Implement a list of building in alphabetical order using LINQ methods

            var buildingsInAlphabeticalOrder = myBuildings.OrderBy(b => b.Name).ToList();

            Console.WriteLine($"Buildings ordered by name: ");
            buildingsInAlphabeticalOrder.ForEach(b => Console.WriteLine(b.Name));
            Console.WriteLine();

            // Implement a list of building in alphabetical order using LINQ Query Syntax

            var buildingsInAlphabeticalOrderQuery = (from b in myBuildings
                                                     orderby b.Name
                                                     select b).ToList();

            Console.WriteLine($"Buildings ordered by name: ");
            buildingsInAlphabeticalOrderQuery.ForEach(b => Console.WriteLine(b.Name));
            Console.WriteLine();

            // Implement a list of building grouped by city using LINQ methods

            var buildingsGroupedByCity = myBuildings.GroupBy(b => b.City).ToList();

            Console.WriteLine($"Buildings grouped by city: ");
            foreach (var group in buildingsGroupedByCity)
            {
                Console.WriteLine($"City: {group.Key}");
                foreach (var building in group)
                {
                    Console.WriteLine($" - {building.Name}");
                }
            }
            Console.WriteLine();

            // Implement a list of building grouped by city using LINQ Query Syntax

            var buildingsGroupedByCityQuery = (from b in myBuildings
                                               group b by b.City into cityGroup
                                               select cityGroup).ToList();

            Console.WriteLine($"\nBuildings grouped by city:");
            foreach (var group in buildingsGroupedByCityQuery)
            {
                Console.WriteLine($"City: {group.Key}");
                foreach (var building in group)
                {
                    Console.WriteLine($" - {building.Name}");
                }
            }
            Console.WriteLine();

            // Find the largest building using LINQ methods

            var largestBuilding = myBuildings.OrderByDescending(b => b.Size).FirstOrDefault();

            Console.WriteLine($"The largest building is {largestBuilding.Name}");
            Console.WriteLine();

            // Find the largest building using LINQ Query Syntax

            var largestBuildingQuery = (from b in myBuildings
                                        orderby b.Size descending
                                        select b).FirstOrDefault();

            Console.WriteLine($"The largest building is {largestBuildingQuery.Name}");
            Console.WriteLine();

            // Calculate average tax per city using LINQ methods

            var averageTaxPerCity = myBuildings.GroupBy(b => b.City)
                                               .Select(group => new
                                               {
                                                   city = group.Key,
                                                   averageTax = group.Average(b => b.CalculateTax())
                                               }).ToList();

            Console.WriteLine("Average tax per city:");
            averageTaxPerCity.ForEach(c => Console.WriteLine($"{c.city}: {c.averageTax:C}"));
            Console.WriteLine();

            // Calculate average tax per city using LINQ Query Syntax

            var averageTaxPerCityQuery = (from b in myBuildings
                                     group b by b.City into cityGroup
                                     select new
                                     {
                                         city = cityGroup.Key,
                                         averageTax = cityGroup.Average(b => b.CalculateTax())
                                     }).ToList();

            Console.WriteLine("Average tax per city: ");
            averageTaxPerCityQuery.ForEach(c => Console.WriteLine($"{c.city}: {c.averageTax:C}"));
            Console.WriteLine();

            // Select top 3 buildings by tax using LINQ methods

            int topN = 3;

            var topNBuildingsByTax = myBuildings.OrderByDescending(b => b.CalculateTax()).Take(topN).ToList();

            Console.WriteLine($"Top {topN} Buildings by Tax:");
            topNBuildingsByTax.ForEach(b => Console.WriteLine($"{b.Name}: {b.CalculateTax():C}"));
            Console.WriteLine();

            // Select top 3 buildings by tax using LINQ Query Syntax

            var topNBuildingsByTaxQuery = (from b in myBuildings
                                           orderby b.CalculateTax() descending
                                           select b).Take(topN).ToList();

            Console.WriteLine($"Top {topN} Buildings by Tax:");
            topNBuildingsByTaxQuery.ForEach(b => Console.WriteLine($"{b.Name}: {b.CalculateTax():C}"));
            Console.WriteLine();

            // Filter buildings by size greater than 1,000,000 sqft and then sort by tax using LINQ methods

            var largeBuildingsSortedByTax = myBuildings.Where(b => b.Size > 1000000)
                                                       .OrderByDescending(b => b.CalculateTax())
                                                       .ToList();

            Console.WriteLine("Large buildings sorted by tax:");
            largeBuildingsSortedByTax.ForEach(b => Console.WriteLine($"{b.Name}: {b.CalculateTax():C}"));
            Console.WriteLine();

            // Filter buildings by size greater than 1,000,000 sqft and then sort by tax using LINQ Query Syntax

            var largeBuildingsSortedByTaxQuery = (from b in myBuildings
                                                  where b.Size > 1000000
                                                  orderby b.CalculateTax() descending
                                                  select b).ToList();

            Console.WriteLine("Large buildings sorted by tax:");
            largeBuildingsSortedByTaxQuery.ForEach(b => Console.WriteLine($"{b.Name}: {b.CalculateTax():C}"));

            Console.ReadKey();
        }
    }

    public class Building
    {
        public string Name { get; set; }
        public string City { get; set; }
        public double Size { get; set; }
        public double TaxPerSize { get; set; }

        public Building(string name, string city, double size, double taxPerSize)
        {
            Name = name;
            City = city;
            Size = size;
            TaxPerSize = taxPerSize;
        }

        public double CalculateTax()
        {
            return Size * TaxPerSize;
        }
    }
}
