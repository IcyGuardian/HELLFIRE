using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ColorOfProperty
{ 
    class SetColor
    {
        public static void ColorPrint(object obj)
        {
            Type type = obj.GetType();
            PropertyInfo[] info = type.GetProperties();

            foreach (PropertyInfo property in info)
            {
                if (property.IsDefined(typeof(PropertyAttribute), false))
                {
                    PropertyAttribute set = (PropertyAttribute)property.GetCustomAttribute(typeof(PropertyAttribute), false);
                    Console.ForegroundColor = set.Color;
                    Console.WriteLine(property.GetValue(obj));
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine(property.GetValue(obj));
                }

            }
        }
    }
}