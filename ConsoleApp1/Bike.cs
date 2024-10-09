using ConsoleApp1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{

    public class Bike
    {
        public int BikeId { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public decimal RentalPrice { get; set; }
        public static int TotalBikes { get; private set; } = 0;

        public Bike(int bikeId, string brand, string model, decimal rentalPrice)
        {
            BikeId = bikeId;
            Brand = brand;
            Model = model;
            RentalPrice = rentalPrice;
            TotalBikes++;
        }
       // public Bike() { }   

        public override string ToString()
        {
            return $"ID: {BikeId}, Brand: {Brand}, Model: {Model}, RentalPrice: {RentalPrice}";
        }

        public virtual string DisplayBikeInfo()
        {
            return ToString();
        }
    }

}

