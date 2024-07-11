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
            Building empireState = new Building("Empire State Building", 2248355, 15);
            Building oneWorld = new Building("One World Trade Center", 3501274, 12);
            Building plazaHotel = new Building("The Plaza Hotel", 868375, 20);
            Building newYorkLibrary = new Building("New York Public Library", 646000, 10);
            Building saintPatricks = new Building("Saint Patrick’s Cathedral", 101760, 8);

            List<Building> myBuildings = new List<Building>();

            myBuildings.Add(empireState);

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

        public double CalculateTax(Building building)
        {
            return building.Size * building.TaxPerSize;
        }
    }
}
