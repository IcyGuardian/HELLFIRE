using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorOfProperty
{
    class SetColorOfProperty
    {
        public void Show()
        {
            Kitty cat = new Kitty("Felix", "Red", 13);
            Building hotel = new Building("United Kingdom", "London", "Park Lane 22", "Hilton", 27, 453);
            Yacht yacht = new Yacht("Silveryachts", "Silver Fast", "Cyan", 77, 27);
            Console.WriteLine("\tProperty: " + cat.GetType());
            SetColor.ColorPrint(cat);
            Console.WriteLine("");
            Console.WriteLine("\tProperty: " + hotel.GetType());
            SetColor.ColorPrint(hotel);
            Console.WriteLine("");
            Console.WriteLine("\tProperty: " + yacht.GetType());
            SetColor.ColorPrint(yacht);
            Console.ReadKey();
        }
    }
}
