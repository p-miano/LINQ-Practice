# LINQ Practice Project

## Overview
This project is a practical exercise to familiarize myself with LINQ queries and data transformations using .NET collections. The goal was to implement various LINQ methods and query syntax to perform operations on a list of buildings. The buildings have properties such as Name, City, Size, and TaxPerSize.

## Project Structure

### Classes

- **Building**: A class that represents a building with properties:
  - **Name:** The name of the building.
  - **City**: The city where the building is located.
  - **Size**: The size of the building in square feet.
  - **TaxPerSize**: The tax rate per square foot.

### Main Program

- **Program.cs**: The main entry point of the application where the following tasks were performed:
  - Created a list of buildings.
  - Calculated the total estimated tax over all buildings.
  - Implemented various data transformations using LINQ methods and query syntax:
    - Filtered the most expensive buildings.
    - Ordered buildings by size.
    - Ordered buildings alphabetically by name.
    - Grouped buildings by city.
    - Found the largest building.
    - Calculated average tax per city.
    - Selected top N buildings by tax.
    - Combined transformations to filter and sort buildings.
   
### Running the Project
To run the project, clone the repository and open it in your preferred C# development environment (e.g., Visual Studio). Build and run the solution to see the output of various LINQ operations on the list of buildings.

## What I Learned

- **LINQ Methods**: I gained hands-on experience with various LINQ methods such as Where, Select, OrderBy, GroupBy, and Sum.
- **LINQ Query Syntax**: I learned how to write LINQ queries using query syntax, which is similar to SQL.
- **Data Transformation**: I understood how to transform data from one structure to another using LINQ.
- **Object-Oriented Programming**: The project reinforced my understanding of object-oriented programming concepts in C#.

## Conclusion
This project was a valuable learning experience in using LINQ for data transformations in .NET. It provided me with practical skills that I can apply in future projects as a .NET developer.
