using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse
{
    interface ISetAlarm:ISetTime
    {
        int AlarmTime { get; set; }
        void SetAlarm(int variable);
    }
}
