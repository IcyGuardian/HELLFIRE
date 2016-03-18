using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse
{
    interface ISound
    {
        int Volume { get; set; }
        void SetVolume(int variable);
        void VolumeUp();
        void VolumeDown();
        void VolumeMute();
    }
}
