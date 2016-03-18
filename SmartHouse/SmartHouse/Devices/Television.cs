using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse
{
    class Television : Device, ISound, IBrightness, ISetChannel
    {
        private int setChannel;
        private int volume;
        private int screenbrightness;
        private string chanName;
        private int maxchannel;
        private List<string> channels;
        public Television(bool status, int maxchannel) : base(status)
        {
            MAXchannel = maxchannel;
        }
        public int MAXchannel { get; set; }
        public void SetBrightness(int variable)
        {
            if (State == true)
            {
                Brightness = variable;
            }
        }
        public int Brightness
        {
            get { return screenbrightness; }
            set
            {
                if (value >= 0 && value <= 100)
                {
                    screenbrightness = value;
                }
            }
        }
        public int Volume
        {
            get { return volume; }
            set
            {
                if (value >= 0 && value <= 100)
                {
                    volume = value;
                }
            }
        }
        public void SetVolume(int variable)
        {
            if (State == true)
            {
                Volume = variable;
            }
        }
        public int SetChannel
        {
            get
            {
                return setChannel;
            }
            set
            {
                if (value <= MAXchannel && value>0)
                {
                    setChannel = value;
                }
            }
        }
        public override void On()
        {
            if (State == false)
            {
                State = true;
                SetChannel = 1;
            }
        }
        public void VolumeUp()
        {
            if (State == true)
            {
                if (Volume < 100)
                {
                    Volume += 1;
                }
            }
        }
        public void VolumeDown()
        {
            if (State == true)
            {
                if (Volume > 0)
                {
                    Volume -= 1;
                }
            }
        }
        public void VolumeMute()
        {
            if (State == true)
            {
                Volume = 0;
            }
        }
        public void NextChannel()
        {
            if (State == true)
            {
                if (SetChannel < MAXchannel)
                {
                    SetChannel += 1;
                }
                else
                {
                    SetChannel = 1;
                }
                ChannelName();
            }
        }
        public void PreviousChannel()
        {
            if (State == true)
            {
                if (SetChannel > 1)
                {
                    SetChannel -= 1;
                }
                if (SetChannel <= 1)
                {
                    SetChannel = MAXchannel;
                }
                ChannelName();
            }
        }
        public void ChooseChannel(int variable)
        {
            if (State == true)
            {               
                SetChannel = variable;
                ChannelName();
            }
        }
        protected void ChannelName()
        {
            if (SetChannel <= channels.Count && SetChannel > 0)
            {
                chanName = channels[SetChannel - 1];
            }
            else
            {
                chanName = "";
            }                   
        } 
        public string ChannelList()
        {
            string str = "";
            if(State==true)
            {
                channels = new List<string>();
                for (int i = 1; i < MAXchannel; i++)
                {
                    channels.Add("1plus1");
                    channels.Add("ICTV");
                    channels.Add("Discovery");
                    channels.Add("Jetix");
                }
                    ChannelName();
                }
                return str;
            }
        public string ShowChannelList()
        {
            string str=("List of Channels: ");
            if(State==true)
            {
                for(int i=0;i<channels.Count;i++)
                {
                    str += "№ " + (i + 1) + "----" + channels[i];
                }
            }
            return str;
        }
        public override string ToString()
        {
            return base.ToString() + " Volume level: " + volume +" Screen Brightness: "+screenbrightness+ " Channel: " + setChannel + " title " + chanName +";";
        }
    }
    } 

