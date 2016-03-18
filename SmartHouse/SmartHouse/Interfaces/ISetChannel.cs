using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse
{
    interface ISetChannel
    {
        int MAXchannel { get; set; }
        void NextChannel();
        void PreviousChannel();
        void ChooseChannel(int variable);
    }
}
