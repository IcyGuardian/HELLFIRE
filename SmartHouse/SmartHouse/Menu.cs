using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse
{
    class Menu
    {
        private IDictionary<string, Device> DevicesDictionary = new Dictionary<string, Device>();

        private int buffer;       
        public string variable { get; set; }
        public IAddDevice ADD { get; set; }
        public void Show()
        {
            ADD = new CreateDevices();

            DevicesDictionary.Add("TV1", ADD.AddTV());
            DevicesDictionary.Add("Refr1", ADD.AddFridge());
            DevicesDictionary.Add("Lamp1", ADD.AddLamp());
            DevicesDictionary.Add("Kettle1", ADD.AddKettle());
            DevicesDictionary.Add("Condit1", ADD.AddConditioner());
            while (true)
            {
                Console.Clear();
                foreach (var dev in DevicesDictionary)
                {
                    Console.WriteLine("Device: " + dev.Key + ", " + dev.Value.ToString());
                }
                Console.WriteLine();
                Console.Write("Введите команду: ");

                string[] commands = Console.ReadLine().Split(' ');
                if (commands[0].ToLower() == "exit" & commands.Length == 3)
                {
                    return;
                }
                if (commands.Length != 3)
                {
                    Help();
                    continue;
                }
                if (commands[0].ToLower() == "add" && !DevicesDictionary.ContainsKey(commands[2]))
                {
                    if (commands[1] == "TV")
                    {
                        DevicesDictionary.Add(commands[2], ADD.AddTV());
                        continue;
                    }
                    if (commands[1] == "ref")
                    {
                        DevicesDictionary.Add(commands[2], ADD.AddFridge());
                        continue;
                    }
                    if (commands[1] == "ket")
                    {
                        DevicesDictionary.Add(commands[2], ADD.AddKettle());
                        continue;
                    }
                    if (commands[1] == "lamp")
                    {
                        DevicesDictionary.Add(commands[2], ADD.AddLamp());
                        continue;
                    }
                    if (commands[1] == "cond")
                    {
                        DevicesDictionary.Add(commands[2], ADD.AddConditioner());
                        continue;
                    }
                }

                if (commands[0].ToLower() == "add" && DevicesDictionary.ContainsKey(commands[2]))
                {
                    Console.WriteLine("Device with such name already exists");
                    Console.WriteLine("Press any key to continue");
                    Console.ReadLine();
                    continue;
                }

                if (commands[0].ToLower() == "del" && !DevicesDictionary.ContainsKey(commands[2]))
                {
                    Console.WriteLine("Device with such name doesn`t exist");
                    Console.WriteLine("Press any key to continue");
                    Console.ReadLine();
                    continue;
                }

                if (!DevicesDictionary.ContainsKey(commands[2]))
                {
                    Help();
                    continue;
                }

                if (commands[0].ToLower() == "del" && DevicesDictionary.ContainsKey(commands[2]))
                {
                    DevicesDictionary.Remove(commands[2]);
                    continue;
                }

                switch (commands[0].ToLower())
                {
                    case "on":
                    case "ON":
                    case "On":
                        DevicesDictionary[commands[2]].On();
                        break;
                    case "off":
                    case "Off":
                    case "OFF":
                        DevicesDictionary[commands[2]].Off();
                        break;
                }

                if (DevicesDictionary[commands[2]] is IChannelsList)
                {
                    IChannelsList t = (IChannelsList)DevicesDictionary[commands[2]];
                    switch (commands[0].ToLower())
                    {
                        case "show":
                            Console.Clear();
                            Console.WriteLine(t.ShowChannelList());
                            Console.ReadKey();
                            break;
                        case "list_chan":
                            Console.WriteLine(t.ListChannel());
                            Console.ReadKey();
                            break;
                    }
                }

                if (DevicesDictionary[commands[2]] is ISetChannel)
                {
                    ISetChannel ch = (ISetChannel)DevicesDictionary[commands[2]];
                    switch (commands[0].ToLower())
                    {
                        case "next":
                        case "Next":
                        case "NEXT":
                            ch.NextChannel();
                            break;
                        case "previous":
                        case "Previous":
                        case "PREVIOUS":
                            ch.PreviousChannel();
                            break;
                        case "choose":
                        case "CHOOSE":
                        case "Choose":
                            Console.WriteLine("Enter the channel number: ");
                            variable = Console.ReadLine();
                            if (Int32.TryParse(variable, out buffer))
                            {
                                if (buffer < 0 || buffer > ch.MAXchannel)
                                {
                                    Console.WriteLine("Error. U can`t set such channel.");
                                    Console.ReadKey();
                                }
                                else
                                {
                                    ch.ChooseChannel(buffer);
                                }
                            }
                            else
                            {
                                Console.WriteLine("Error! U failed to set number of channel");
                                Console.ReadKey();
                            }
                            break;
                    }
                }
                    if (DevicesDictionary[commands[2]] is ISound)
                    {
                        ISound sound = (ISound)DevicesDictionary[commands[2]];
                        switch (commands[0].ToLower())
                        {
                            case "mute":
                                sound.VolumeMute();
                                break;
                            case "vol_up":
                                sound.VolumeUp();
                                break;
                            case "vol_down":
                                sound.VolumeDown();
                                break;
                            case "set_vol":
                                Console.WriteLine("Enter the volume [1-100] : ");
                                variable = Console.ReadLine();
                                if (Int32.TryParse(variable, out buffer))
                                {
                                    if (buffer < 0 || buffer > 100)
                                    {
                                        Console.WriteLine("Error! Wrong volume.");
                                        Console.ReadKey();
                                    }
                                    else
                                    {
                                        sound.SetVolume(buffer);
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Error! Can`t set the volume!");
                                    Console.ReadKey();
                                }
                                break;
                        }
                    }

                    if (DevicesDictionary[commands[2]] is IBrightness)
                    {
                        IBrightness sound = (IBrightness)DevicesDictionary[commands[2]];
                        switch (commands[0].ToLower())
                        {
                            case "set_bright":
                                Console.WriteLine("Enter the volume [1-100] : ");
                                variable = Console.ReadLine();
                                if (Int32.TryParse(variable, out buffer))
                                {
                                    if (buffer < 0 || buffer > 100)
                                    {
                                        Console.WriteLine("Error! Wrong brightness.");
                                        Console.ReadKey();
                                    }
                                    else
                                    {
                                        sound.SetBrightness(buffer);
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Error! Can`t set the volume!");
                                    Console.ReadKey();
                                }
                                break;
                        }
                    }

                    if (DevicesDictionary[commands[2]] is IFreezModes)
                    {
                        IFreezModes type = (IFreezModes)DevicesDictionary[commands[2]];
                        switch (commands[0].ToLower())
                        {
                            case "NoFrost":
                            case "nofrost":
                            case "Nofrost":
                                type.NoFrostMode();
                                break;
                            case "normal":
                            case "Normal":
                                type.NormalMode();
                                break;
                            case "ventilation":
                            case "Ventilation":
                                type.VentilationMode();
                                break;
                            case "SuperFrost":
                            case "superfrost":
                            case "Superfrost":
                                type.SuperFrostMode();
                                break;
                        }
                    }
                    if (DevicesDictionary[commands[2]] is ISetTemperature)
                    {
                        ISetTemperature t = (ISetTemperature)DevicesDictionary[commands[2]];
                        switch (commands[0].ToLower())
                        {
                            case "set_temp":
                                Console.WriteLine("Set temperature [-4...10] ");
                                variable = Console.ReadLine();
                                if (Int32.TryParse(variable, out buffer))
                                {
                                    if (buffer < -4 || buffer > 10)
                                    {
                                        Console.WriteLine("Error! Failed to set temperature.");
                                        Console.ReadKey();
                                    }
                                    else
                                    {
                                        t.SetTemperature(buffer);
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Error! Try to set temperature once more!");
                                    Console.ReadKey();
                                }
                                break;
                        }
                    }                
                if (DevicesDictionary[commands[2]] is IConditionerModes)
                {
                    IConditionerModes mode = (IConditionerModes)DevicesDictionary[commands[2]];
                    switch (commands[0].ToLower())
                    {
                        case "heat_mode":
                        case "Heat_mode":
                            mode.HeatingMode();
                            break;
                        case "Aero_mode":
                        case "aero_mode":
                            mode.AerationMode();
                            break;
                        case "cool_mode":
                        case "Cool_mode":
                            mode.CoolingMode();
                            break;
                    }
                }
                if (DevicesDictionary[commands[2]] is ILightColors)
                {
                    Console.ResetColor();
                    ILightColors color = (ILightColors)DevicesDictionary[commands[2]];
                    switch (commands[0].ToLower())
                    {
                        case "white_light":
                        case "White_light":
                            color.WhiteLight();
                            break;
                        case "Red_light":
                        case "red_light":
                            color.RedLight();
                            break;
                        case "pink_light":
                        case "Pink_light":
                            color.PinkLight();
                            break;
                        case "Yellow_light":
                        case "yellow_light":
                            color.YellowLight();
                            break;
                        case "Blue_light":
                        case "blue_light":
                            color.BlueLight();
                            break;                           
                    }
                }
            }
        }
                    
        private static void Help()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Commands to add device:");
            Console.ResetColor();
            Console.WriteLine("\tadd tv DeviceName");
            Console.WriteLine("\tadd fridge DeviceName");
            Console.WriteLine("\tadd kettle DeviceName");
            Console.WriteLine("\tadd lamp DeviceName");
            Console.WriteLine("\tadd conditioner DeviceName");
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("To remove device: ");
            Console.ResetColor();
            Console.WriteLine("\tdel _ DeviceName  ");
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("To on/off device: ");
            Console.ResetColor();
            Console.WriteLine("\ton _ DeviceName");
            Console.WriteLine("\toff _ DeviceName");
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Commands to control TV:");
            Console.ResetColor();
            Console.WriteLine("\tnext TV nameDevice");
            Console.WriteLine("\tprevious TV nameDevice");
            Console.WriteLine("\tchoose TV nameDevice");
            Console.WriteLine("\tshow TV nameDevice");
            Console.WriteLine("\tlist_chan TV nameDevice");
            Console.WriteLine("\tvol_up TV nameDevice");
            Console.WriteLine("\tvol_down TV nameDevice");
            Console.WriteLine("\tset_vol TV nameDevice");
            Console.WriteLine("\tmute TV nameDevice");
            Console.WriteLine("\tset_bright TV nameDevice");

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Commands to control Refridgerator:");
            Console.ResetColor();
            Console.WriteLine("\tnofrost ref nameDevice");
            Console.WriteLine("\tnormal ref nameDevice");
            Console.WriteLine("\tventilation ref nameDevice");
            Console.WriteLine("\tsuperfrost ref nameDevice");
            Console.WriteLine("\tset_temp ref nameDevice");

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Commands to control Conditioner:");
            Console.ResetColor();
            Console.WriteLine("\theat_mode cond nameDevice");
            Console.WriteLine("\taero_mode cond nameDevice");
            Console.WriteLine("\tcool_mode cond nameDevice");
            Console.WriteLine("\tset_temp cond nameDevice");

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Commands to control Lamp:");
            Console.ResetColor();
            Console.WriteLine("\twhite_light lamp nameDevice");
            Console.WriteLine("\tred_light lamp nameDevice");
            Console.WriteLine("\tpink_light lamp nameDevice");
            Console.WriteLine("\tyellow_light lamp nameDevice");
            Console.WriteLine("\tblue_light lamp nameDevice");
            Console.WriteLine("\tset_bright lamp nameDevice");


            Console.WriteLine("\n \texit _ _");
            Console.WriteLine("Нажмите любую клавишу для продолжения");
            Console.ReadLine();
        }
    }
  }
 
