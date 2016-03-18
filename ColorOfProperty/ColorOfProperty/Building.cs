using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorOfProperty
{
    class Building
    {
        private int floors;
        private int rooms;
        public Building(string country, string city, string address, string name,int floors, int rooms)
        {
            Country = country;
            City = city;
            Address = address;
            Name = name;
            Floors = floors;
            Rooms = rooms;
            
        }
        [Property(ConsoleColor.Red)]
        public string Country { get; set; }
        [Property(ConsoleColor.Yellow)]
        public string City { get; set; }
        [Property(ConsoleColor.Green)]
        public string Address { get; set; }
        [Property(ConsoleColor.Cyan)]
        public string Name { get; set; }
        [Property(ConsoleColor.Blue)]
        public int Floors
        {
            get { return floors; }
            set
            {
                if(value>0 && value<=163)
                {
                    floors = value;
                }
            }
        }
        [Property(ConsoleColor.DarkMagenta)]
        public int Rooms
        {
            get { return rooms; }
            set
            {
                if(value>0 && value<10000)
                {
                    rooms = value;
                }
            }
        }
    }
}
