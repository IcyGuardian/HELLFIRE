using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorOfProperty
{
    class Yacht
    {
        private double length;
        private double maxspeedkneets;
        public Yacht(string brand, string model, string color, double length, double maxspeedkneets)
        {
            Brand = brand;
            Model = model;
            Color = color;
            Length = length;
            MaxSpeedKneets = maxspeedkneets;
        }
        [Property(ConsoleColor.Gray)]
        public string Brand{get;set;}
        [Property(ConsoleColor.White)]
        public string Model { get; set; }
        [Property(ConsoleColor.Cyan)]
        public string Color { get; set; }
        public double Length
        {
            get { return length; }
            set
            {
                if (value > 0.0 && value < 200.0)
                {
                    length = value;
                }
            }
        }       
        public double MaxSpeedKneets
        {
            get { return maxspeedkneets; }
            set
            {
                if (value > 0.0 && value < 50.0)
                {
                    maxspeedkneets = value;
                }
            }
        }

    }
}
