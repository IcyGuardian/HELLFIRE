using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse
{
   public abstract class Device
    {
        public Device(bool state)
        {           
            State = state;
        }
        public bool State { get; set; }

        public virtual void On()  
        {

            if (State == false)
            {
                State = true;
            }
        }

        public virtual void Off() 
        {
            if (State)
            {
                State = false;
            }
        }

        public override string ToString()
        {
            string state;
            if (State)
            {
                state = "ON";
            }
            else
            {
                state = "OFF";
            }
            return "State: " + state;
        }
    }
}