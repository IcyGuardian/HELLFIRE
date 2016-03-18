using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorOfProperty
{
    class Kitty
    {
        private int age;
        public Kitty(string name, string color, int age)
        {
            Name = name;
            Color = color;
            Age = age;
        }
        public string Name { get; set; }
        public string Color { get; set; }
        public int Age
        {
            get { return age; }
            set
            {
                if (value > 0)
                {
                    age = value;
                }
            }
        }
    }
}
