using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    namespace BikeRentalManagementSystem
    {

        // BikeManager class for managing bikes
        public class BikeManager
        {
            private List<Bike> bikes = new List<Bike>();

            // Method to add a new bike
            public void CreateBike(Bike bike)
            {
                if (ValidateBikeRentalPrice(bike.RentalPrice))
                {
                    bikes.Add(bike);
                    Console.WriteLine("Bike added successfully.");
                }
            }

            // Method to list all bikes
            public void ReadBikes()
            {
                if (bikes.Count == 0)
                {
                    Console.WriteLine("No Bikes available.");
                }
                else
                {
                    foreach (var bike in bikes)
                    {
                        Console.WriteLine(bike);
                    }
                }
            }

            // Method to update bike details
            public void UpdateBike(int id, string brand, string model, decimal rentalPrice)
            {
                var bike = bikes.FirstOrDefault(b => b.BikeId == id);
                if (bike != null && ValidateBikeRentalPrice(rentalPrice))
                {
                    bike.BikeId = id;
                    bike.Brand = brand;
                    bike.Model = model;
                    bike.RentalPrice = rentalPrice;
                    Console.WriteLine("Bike updated successfully.");
                }
                else
                {
                    Console.WriteLine("Bike not found.");
                }
            }

            // Method to delete a bike
            public void DeleteBike(int id)
            {
                var bike = bikes.FirstOrDefault(b => b.BikeId == id);
                if (bike != null)
                {
                    bikes.Remove(bike);
                    Console.WriteLine("Bike deleted successfully.");
                }
                else
                {
                    Console.WriteLine("Bike not found.");
                }
            }

            // Method to validate rental price
            public bool ValidateBikeRentalPrice(decimal rentalPrice)
            {
                if (rentalPrice <= 0)
                {
                    Console.WriteLine("Rental price must be positive.");
                    return false;
                }
                return true;
            }

 
        
            // Method to validate the rental price of a bike
            public static decimal ValidateBikeRentalPrice()
            {
                decimal rentalPrice;

                // Loop until a valid rental price is entered
                while (true)
                {
                    Console.Write("Enter the rental price for the bike: ");
                    string input = Console.ReadLine();

                    // Check if the input is a valid decimal number and greater than zero
                    if (decimal.TryParse(input, out rentalPrice) && rentalPrice > 0)
                    {
                        return rentalPrice; // Valid price, return it
                    }
                    else
                    {
                        // Display error message and ask for input again
                        Console.WriteLine("Error: Rental price must be a positive number. Please try again.");
                    }
                }
            }
        }

    }


}

