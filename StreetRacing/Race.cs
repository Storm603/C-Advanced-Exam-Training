using System;
using System.Collections.Generic;
using System.Text;

namespace StreetRacing
{
    public class Race
    {
        public List<Car> Participants { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int Laps { get; set; }
        public int Capacity { get; set; }
        public int HorsePower { get; set; }
        public int Count => Participants.Count;

        public Race(string name, string type, int laps, int capacity, int horsepower)
        {
            Name = name;
            Type = type;
            Laps = laps;
            Capacity = capacity;
            HorsePower = horsepower;

            Participants = new List<Car>();
        }

        public void Add(Car car)
        {
            bool exists = false;

            foreach (Car participant in Participants)
            {
                if (participant.LicensePlate == car.LicensePlate)
                {
                    exists = true;
                }
            }

            if (exists == false && Participants.Count < Capacity && car.HorsePower <= HorsePower)
            {
                Participants.Add(car);
            }
        }

        public bool Remove(string licensePlate)
        {
            foreach (Car participant in Participants)
            {
                if (participant.LicensePlate == licensePlate)
                {
                    Participants.Remove(participant);
                    return true;
                }
            }

            return false;
        }

        public Car FindParticipant(string licensePlate)
        {
            foreach (Car participant in Participants)
            {
                if (participant.LicensePlate == licensePlate)
                {
                    return participant;
                }
            }

            return null;
        }

        public Car GetMostPowerfulCar()
        {
            int horses = Int32.MinValue;
            Car car = null;

            foreach (Car participant in Participants)
            {
                if (participant.HorsePower > horses)
                {
                    horses = participant.HorsePower;
                    car = participant;
                }
            }

            return car;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Race: {Name} - Type: {Type} (Laps: {Laps})");

            foreach (Car participant in Participants)
            {
                sb.AppendLine(participant.ToString());
            }

            return sb.ToString();
        }
    }
}
