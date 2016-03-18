using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse
{
    class Kettle : Device, ITemperature
    {
        private int temperature;


        public Kettle(bool status, int temp) : base(status)
        {
            Temperature = temp;
        }

        public int Temperature
        {
            get
            {
                return temperature;
            }

            set
            {
                if (value >= 0 && value <= 120)
                {
                    temperature = value;
                }
            } }
        public override string ToString()
        {
            return base.ToString() + ", temperature: " + Temperature + "\n";
        }
    }
    } 