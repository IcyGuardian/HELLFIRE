using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorOfProperty
{
    [AttributeUsage(AttributeTargets.Property)]
    public class PropertyAttribute : System.Attribute
    {
        public PropertyAttribute(ConsoleColor color)
        {
            Color = color;
        }
        public ConsoleColor Color { get; set; }
    }
}
