using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse
{
    class Conditioner:Device,ITemperature,IConditionerModes
    {
        private ConditionerModes Mode;
        private int temperature;
        private int temp;
        public Conditioner(bool state, int temperature): base(state)
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
                if (value >=1 && value <= 30)
                {
                    if (value >= 1 && value <=10 )
                    {
                        Mode = ConditionerModes.Cooling;
                        temperature = value;
                    }
                    if (value > 10 && value <= 20)
                    {
                        Mode = ConditionerModes.Aeration;
                        temperature = value;
                    }
                    if (value > 20 && value <= 30)
                    {
                        Mode = ConditionerModes.Heating;
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
        public void CoolingMode()
        {
            if (State == true)
            {
                Mode = ConditionerModes.Cooling;
                Temperature = 5;
                temp = Temperature;
            }
        }
        public void AerationMode()
        {
            if (State == true)
            {
                Mode = ConditionerModes.Aeration;
                Temperature = 15;
                temp = Temperature;
            }
        }
        public void HeatingMode()
        {
            if (State == true)
            {
                Mode = ConditionerModes.Heating;
                Temperature = 25;
                temp = Temperature;
            }
        }       
        public override string ToString()
        {
            string Mode;
            if (this.Mode == ConditionerModes.Cooling)
            {
                Mode = "Cooling";
            }
            else if (this.Mode == ConditionerModes.Aeration)
            {
                Mode = "Aeration";
            }
            else if (this.Mode == ConditionerModes.Heating)
            {
                Mode = "Heating";
            }           
            else
            {
                Mode = "UnSetted";
            }
            return base.ToString() + ", " + Mode + " Mode" + ", temperature: " + Temperature;
        }
    }
}