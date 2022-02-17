using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace StreetRacing
{
    public class Car
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public string LicensePlate { get; set; }
        public int HorsePower { get; set; }
        public double Weight { get; set; }

        public Car(string make, string model, string license, int horsePower, double weight)
        {
            Make = make;
            Model = model;
            LicensePlate = license;
            HorsePower = horsePower;
            Weight = weight;
        }

        public override string ToString()
        {
            return
                $"Make: {Make}\nModel: {Model}\nLicense Plate: {LicensePlate}\nHorse Power: {HorsePower}\nWeight: {Weight}";
        }
    }
}
