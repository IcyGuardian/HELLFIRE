using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse
{
    class Refrigerator:Device,ITemperature,IFreezModes,ISetTemperature
    {
        private FreezModes mode;
        private int temperature;
        private int temp;
        public Refrigerator(bool state, int temperature): base(state)
        {
            Temperature = temperature;
        }
        public int Temperature
        {
            get
            {
                return temperature;
            }
            set
            {
                if (value >= -4 && value <= 10)
                {
                    if (value >= 1 && value <= 4)
                    {
                        mode = FreezModes.NoFrost;
                        temperature = value;
                    }
                    if (value >= 5 && value <= 7)
                    {
                        mode = FreezModes.Normal;
                        temperature = value;
                    }
                    if (value >= 8 && value <= 10)
                    {
                        mode = FreezModes.Ventilation;
                        temperature = value;
                    }
                    if (value >= -4 && value < 1)
                    {
                        mode = FreezModes.SuperFrost;
                        temperature = value;
                    }
                }
            }
        }
        public void SetTemperature(int variable) 
        {
            if (State)
            {
                Temperature = variable;
                temp = Temperature;                
            }
        }
            public void NormalMode()
        {
            if(State==true)
            {
                mode = FreezModes.Normal;
                Temperature = 6;
                temp = Temperature;
            }
        }
        public void NoFrostMode()
        {
            if(State==true)
            {
                mode = FreezModes.NoFrost;
                Temperature = 2;
                temp = Temperature;
            }
        }
        public void VentilationMode()
        {
            if(State==true)
            {
                mode = FreezModes.Ventilation;
                Temperature = 9;
                temp = Temperature;
            }
        }
        public void SuperFrostMode()
        {
            if(State==true)
            {
                mode = FreezModes.SuperFrost;
                Temperature = -2;
                temp = Temperature;
            }
        }
        public override string ToString()
        {
            string type;
            if (mode == FreezModes.NoFrost)
            {
                type = "NoFrost";
            }
            else if (mode== FreezModes.Normal)
            {
                type = "Normal";
            }
            else if (mode == FreezModes.Ventilation)
            {
               type = "Ventilation";
            }
            else if (mode == FreezModes.SuperFrost)
            {
                type = "SuperFrost";
            }
            else
            {
                type = "UnSetted";
            }
            return base.ToString() + ", " + type + " Mode" + ", temperature: " + Temperature;
        }
    }
}
