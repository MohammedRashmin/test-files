using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class ElectricalBike : Bike
    {
        public string BatteryCapacity { get; set; }
        public string MotorPower { get; set; }

        public ElectricalBike(int bikeId, string brand, string model, decimal rentalPrice, string batteryCapacity, string motorPower)
            : base(bikeId, brand, model, rentalPrice)
        {
            BatteryCapacity = batteryCapacity;
            MotorPower = motorPower;
        }

        // Override DisplayBikeInfo
        public override string DisplayBikeInfo()
        {
            return base.DisplayBikeInfo() + $", BatteryCapacity: {BatteryCapacity}, MotorPower: {MotorPower}";
        }
    }
}
