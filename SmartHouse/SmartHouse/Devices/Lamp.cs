using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse
{
    class Lamp : Device, IBrightness, ILightColors
    {
        private LightColor color;
        private string lightcolor;
        private int lampbrightness;
        public Lamp(bool state, int brightness) : base(state)
        {
            Brightness = brightness;
        }
        public void SetBrightness(int variable)
        {
            if (State == true)
            {
                Brightness = variable;
            }
        }
        public int Brightness
        {
            get { return lampbrightness; }
            set
            {
                if (value >= 0 && value <= 100)
                {
                    lampbrightness = value;
                }
            }
        }
        public string Color
        {
            get { return lightcolor; }
            set
            {
                if (value == "White")
                {
                    color = LightColor.White;
                    lightcolor = value;
                }
                if (value == "Red")
                {
                    color = LightColor.Red;
                    lightcolor = value;
                }
                if (value == "Pink")
                {
                    color = LightColor.Pink;
                    lightcolor = value;
                }
                if (value == "Yellow")
                {
                    color = LightColor.Yellow;
                    lightcolor = value;
                }
                if (value == "Blue")
                {
                    color = LightColor.Blue;
                    lightcolor = value;
                }
            }
        }
        public void WhiteLight()
        {
            if (State == true)
            {
                color = LightColor.White;
                lightcolor = "White";
            }
        }
        public void RedLight()
        {
            if (State == true)
            {
                color = LightColor.Red;
                lightcolor = "Red";
            }
        }
        public void YellowLight()
        {
            if (State == true)
            {
                color = LightColor.Yellow;
                lightcolor = "Yellow";
            }
        }
        public void PinkLight()
        {
            if (State == true)
            {
                color = LightColor.Pink;
                lightcolor = "Pink";
            }
        }
        public void BlueLight()
        {
            if (State == true)
            {
                color = LightColor.Blue;
                lightcolor = "Blue";
            }
        }
        public override string ToString()
        {
            string color;
            if (this.color == LightColor.White)
            {
                color = "White";
                Console.ForegroundColor = ConsoleColor.White;
            }
            else if (this.color == LightColor.Red)
            {
                color = "Red";
                Console.ForegroundColor = ConsoleColor.Red;
            }
            else if (this.color == LightColor.Yellow)
            {
                color = "Yellow";
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            else if (this.color == LightColor.Pink)
            {
                color = "Pink";
                Console.ForegroundColor = ConsoleColor.Magenta;
            }
            else if (this.color == LightColor.Blue)
            {
                color = "Blue";
                Console.ForegroundColor = ConsoleColor.Blue;               
            }
            else
            {
                color = "Default";
                Console.ResetColor();
            }
            return base.ToString() + ", " + color + " Light" + ", brightness: " + lampbrightness;
        }
    }
}
