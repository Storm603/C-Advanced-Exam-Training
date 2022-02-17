using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Drones
{
    public class Airfield
    {
        public List<Drone> Drones { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public double LandingStrip { get; set; }
        public int Count => Drones.Count;

        public Airfield(string name, int capacity, double landingStrip)
        {
            Name = name;
            Capacity = capacity;
            LandingStrip = landingStrip;
            Drones = new List<Drone>();

        }

        public string AddDrone(Drone drone)
        {
            if (Count > Capacity)
            {
                return "Airfield is full.";
            }

            if (string.IsNullOrEmpty(drone.Name) || string.IsNullOrEmpty(drone.Brand) || drone.Range < 5 || drone.Range > 15)
            {
                return "Invalid drone";
            }

            Drones.Add(drone);
            return $"Successfully added {drone.Name} to the airfield.";
        }

        public bool RemoveDrone(string name)
        {
            foreach (Drone drone in Drones)
            {
                if (drone.Name == name)
                {
                    Drones.Remove(drone);
                    return false;
                }
            }

            return false;
        }

        public int RemoveDroneByBrand(string brand)
        {
            int count = 0;

            for (int i = Count - 1; i >= 0; i--)
            {
                if (Drones[i].Brand == brand)
                {
                    count++;
                    Drones.RemoveAt(i);
                }
            }

            return count;
        }

        public Drone FlyDrone(string name)
        {
            foreach (Drone drone in Drones)
            {
                if (drone.Name == name)
                {
                    drone.Available = false;
                    return drone;
                }
            }

            return null;
        }

        public List<Drone> FlyDronesByRange(int range)
        {
            List<Drone> dronesFlying = new List<Drone>();

            foreach (Drone drone in Drones)
            {
                if (drone.Range >= range)
                {
                    drone.Available = false;
                    dronesFlying.Add(drone);
                }
            }

            return dronesFlying;
        }

        public StringBuilder Report()
        {
            StringBuilder sb = new StringBuilder();

            Console.WriteLine($"Drones available at {Name}");
            foreach (Drone drone in Drones)
            {
                if (drone.Available)
                {
                    sb.AppendLine(drone.ToString());
                }
            }

            return sb;
        }
    }
}
