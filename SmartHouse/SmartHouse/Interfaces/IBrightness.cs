using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse
{
    interface IBrightness
    {
        int Brightness { get; set; }
        void SetBrightness(int variable);
    }
}
