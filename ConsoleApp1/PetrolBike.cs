using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class PetrolBike : Bike
    {
        public string FuelTankCapacity { get; set; }
        public string EngineCapacity { get; set; }

        public PetrolBike(int bikeId, string brand, string model, decimal rentalPrice, string fuelTankCapacity, string engineCapacity)
            : base(bikeId, brand, model, rentalPrice)
        {
            FuelTankCapacity = fuelTankCapacity;
            EngineCapacity = engineCapacity;
        }

        // Override DisplayBikeInfo
        public override string DisplayBikeInfo()
        {
            return base.DisplayBikeInfo() + $", FuelTankCapacity: {FuelTankCapacity}, EngineCapacity: {EngineCapacity}";
        }
    }
}
