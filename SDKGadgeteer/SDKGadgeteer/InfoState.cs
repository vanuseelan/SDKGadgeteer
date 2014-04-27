using System;
using System.Reflection;
using System.Threading;
using Gadgeteer.Modules.GHIElectronics;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;

namespace SDKGadgeteer
{
    class InfoState : State
    {
        public InfoState(Program handle, int timerIntervalMilliseconds = 100) :
            base(handle, TypeState.Normal, timerIntervalMilliseconds)
        {
        }

        public override void Entry()
        {
            StartListen();

            ConsoleDisplayN18.Clear();
            ConsoleDisplayN18.WriteLine("About this DEMO Gadgeteer");
            ConsoleDisplayN18.WriteLine("Mainboard :");
            ConsoleDisplayN18.WriteLine(MainHandle.MotherCard.MainboardName);
            ConsoleDisplayN18.WriteLine(MainHandle.MotherCard.MainboardVersion);
            ConsoleDisplayN18.WriteLine("Framework :");
            ConsoleDisplayN18.WriteLine(SystemInfo.Version.ToString());
            ConsoleDisplayN18.WriteLine("Logiciel :");
            ConsoleDisplayN18.WriteLine(Assembly.GetExecutingAssembly().GetName().Name);
            ConsoleDisplayN18.WriteLine(Assembly.GetExecutingAssembly().GetName().Version.ToString());
        }

        public override void Exit()
        {
            StopListen();
            //Do nothing
        }

        public override void Do()
        {
            //Do nothing
        }
    }
}
