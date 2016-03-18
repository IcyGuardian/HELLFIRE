using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse
{
    interface IConditionerModes
    {
        void HeatingMode();
        void AerationMode();
        void CoolingMode();
    }
}
