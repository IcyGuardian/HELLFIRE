using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse
{
    interface ISetTime
    {
        int Time { get; set; }
        void SetTime(int variable);
    }
}
