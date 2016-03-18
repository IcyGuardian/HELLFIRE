using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse
{
    class CreateDevices:IAddDevice
    {
        public Refrigerator AddFridge()
        {                        
            return new Refrigerator(false, 7);
        }

        public Television AddTV()
        {
            return new Television(false, 100);
        }

        public Lamp AddLamp()
        {
            return new Lamp(false, 50);
        }

        public Kettle AddKettle()
        {
            return new Kettle(false, 0);
        }

        public Conditioner AddConditioner()
        {
            return new Conditioner(false,15);
        }
    }
}
