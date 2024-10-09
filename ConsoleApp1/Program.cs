using ConsoleApp1.BikeRentalManagementSystem;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Menu();
            Console.ReadLine();
        }

        public static void Menu()
        {
            var bikes = new Bike(1, "Yamaha", "Fz", 2000);
            Console.WriteLine(bikes.ToString());

            BikeManager bikeManager = new BikeManager();
            BikeRepository bikeRepository = new BikeRepository();
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("\nBike Rental Management System:");
                Console.WriteLine("1. Add a Bike");
                Console.WriteLine("2. View All Bikes");
                Console.WriteLine("3. Update a Bike");
                Console.WriteLine("4. Delete a Bike");
                Console.WriteLine("5. Exit");
                Console.Write("Choose an option: ");
                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        // Adding a bike
                        Console.WriteLine("Select the type of bike:");
                        Console.WriteLine("1. Electric Bike");
                        Console.WriteLine("2. Petrol Bike");
                        string bikeType = Console.ReadLine();

                        Console.Write("Enter the bike brand: ");
                        string brand = Console.ReadLine();
                        Console.Write("Enter the bike model: ");
                        string model = Console.ReadLine();
                        decimal rentalPrice = BikeManager.ValidateBikeRentalPrice();

                        if (bikeType == "1") // Electric Bike
                        {
                            Console.Write("Enter the battery capacity: ");
                            string batteryCapacity = Console.ReadLine();
                            Console.Write("Enter the motor power: ");
                            string motorPower = Console.ReadLine();

                            ElectricalBike electricBike = new ElectricalBike(0, brand, model, rentalPrice, batteryCapacity, motorPower);
                            bikeRepository.CreateBike(electricBike);
                        }
                        else if (bikeType == "2") // Petrol Bike
                        {
                            Console.Write("Enter the fuel tank capacity: ");
                            string fuelTankCapacity = Console.ReadLine();
                            Console.Write("Enter the engine capacity: ");
                            string engineCapacity = Console.ReadLine();

                            PetrolBike petrolBike = new PetrolBike(0, brand, model, rentalPrice, fuelTankCapacity, engineCapacity);
                            bikeRepository.CreateBike(petrolBike);
                        }
                        else
                        {
                            Console.WriteLine("Invalid bike type selected.");
                        }
                        break;

                    case "2":
                        // Viewing all bikes
                        var bikesList = bikeRepository.ReadBikes();
                        foreach (var bike in bikesList)
                        {
                            Console.WriteLine(bike.DisplayBikeInfo());
                        }
                        break;

                    case "3":
                        // Updating a bike
                        Console.Write("Enter the Bike ID to update: ");
                        int updateId = int.Parse(Console.ReadLine());
                        Console.Write("Enter the new bike brand: ");
                        string newBrand = Console.ReadLine();
                        Console.Write("Enter the new bike model: ");
                        string newModel = Console.ReadLine();
                        decimal newRentalPrice = BikeManager.ValidateBikeRentalPrice();

                        Console.WriteLine("Select the type of bike:");
                        Console.WriteLine("1. Electric Bike");
                        Console.WriteLine("2. Petrol Bike");
                        string updateBikeType = Console.ReadLine();

                        if (updateBikeType == "1") // Electric Bike
                        {
                            Console.Write("Enter the new battery capacity: ");
                            string newBatteryCapacity = Console.ReadLine();
                            Console.Write("Enter the new motor power: ");
                            string newMotorPower = Console.ReadLine();

                            ElectricalBike updatedElectricBike = new ElectricalBike(updateId, newBrand, newModel, newRentalPrice, newBatteryCapacity, newMotorPower);
                            bikeRepository.UpdateBike(updateId, updatedElectricBike);
                        }
                        else if (updateBikeType == "2") // Petrol Bike
                        {
                            Console.Write("Enter the new fuel tank capacity: ");
                            string newFuelTankCapacity = Console.ReadLine();
                            Console.Write("Enter the new engine capacity: ");
                            string newEngineCapacity = Console.ReadLine();

                            PetrolBike updatedPetrolBike = new PetrolBike(updateId, newBrand, newModel, newRentalPrice, newFuelTankCapacity, newEngineCapacity);
                            bikeRepository.UpdateBike(updateId, updatedPetrolBike);
                        }
                        else
                        {
                            Console.WriteLine("Invalid bike type selected.");
                        }
                        break;

                    case "4":
                        // Deleting a bike
                        Console.Write("Enter the Bike ID to delete: ");
                        int deleteId = int.Parse(Console.ReadLine());
                        bikeRepository.DeleteBike(deleteId);
                        break;

                    case "5":
                        // Exit the program
                        exit = true;
                        Console.WriteLine("Exiting the Bike Rental Management System.");
                        break;

                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }
    }
}


// Main program class
//            var bikeManager = new BikeManager();
//            bool exit = false;

//            while (!exit)
//            {
//                Console.WriteLine("\nBike Rental Management System");
//                Console.WriteLine("1. Add Bike");
//                Console.WriteLine("2. View Bikes");
//                Console.WriteLine("3. Update Bike");
//                Console.WriteLine("4. Delete Bike");
//                Console.WriteLine("5. Exit");
//                Console.Write("Choose an option: ");

//                switch (Console.ReadLine())
//                {
//                    case "1":
//                        Console.Write("Enter Bike ID: ");
//                        int id = int.Parse(Console.ReadLine());

//                        Console.Write("Enter Bike Brand: ");
//                        string brand = Console.ReadLine();

//                        Console.Write("Enter Bike Model: ");
//                        string model = Console.ReadLine();

//                        Console.Write("Enter Bike Rental Price: ");
//                        decimal rentalPrice = decimal.Parse(Console.ReadLine());

//                        Bike newBike = new Bike { BikeId = id, Brand = brand, Model = model, RentalPrice = rentalPrice };
//                        bikeManager.CreateBike(newBike);
//                        break;

//                    case "2":
//                        bikeManager.ReadBikes();
//                        break;

//                    case "3":
//                        Console.Write("Enter Bike ID to update: ");
//                        int updateId = int.Parse(Console.ReadLine());

//                        Console.Write("Enter new Bike Brand: ");
//                        string newBrand = Console.ReadLine();

//                        Console.Write("Enter new Bike Model: ");
//                        string newModel = Console.ReadLine();

//                        Console.Write("Enter new Rental Price: ");
//                        decimal newRentalPrice = decimal.Parse(Console.ReadLine());

//                        bikeManager.UpdateBike(updateId, newBrand, newModel, newRentalPrice);
//                        break;

//                    case "4":
//                        Console.Write("Enter Bike ID to delete: ");
//                        int deleteId = int.Parse(Console.ReadLine());
//                        bikeManager.DeleteBike(deleteId);
//                        break;

//                    case "5":
//                        exit = true;
//                        Console.WriteLine("Exiting the program.");
//                        break;

//                    default:
//                        Console.WriteLine("Invalid option, please try again.");
//                        break;



//                }
//            }
//        }
//    }
//}

