using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse
{
    interface IFreezModes
    {
        void NormalMode();
        void NoFrostMode();
        void VentilationMode();
        void SuperFrostMode();
    }
}
