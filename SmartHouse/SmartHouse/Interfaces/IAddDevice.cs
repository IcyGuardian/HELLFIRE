using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse
{
    interface IAddDevice
    {
        Lamp AddLamp();
        Kettle AddKettle();
        Television AddTV();
        Refrigerator AddFridge();
        Conditioner AddConditioner();
    }
}
