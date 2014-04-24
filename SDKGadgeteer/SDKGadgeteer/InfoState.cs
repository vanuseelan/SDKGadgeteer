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

            Display_N18 screen = MainHandle.Display_N18;
            screen.Clear();
            PrintText.Write("About this DEMO Gadgeteer", screen, 0, 0);
            PrintText.Write("Mainboard :", screen, 0, 15);
            PrintText.Write(MainHandle.MotherCard.MainboardName, screen, 0, 30);
            PrintText.Write(MainHandle.MotherCard.MainboardVersion, screen, 0, 45);
            PrintText.Write("Framework :", screen, 0, 60);
            PrintText.Write(SystemInfo.Version.ToString(),screen, 0, 75);
            PrintText.Write("Logiciel :", screen, 0, 90);
            PrintText.Write(Assembly.GetExecutingAssembly().GetName().Name, screen, 0, 105);
            PrintText.Write(Assembly.GetExecutingAssembly().GetName().Version.ToString(), screen, 0, 120);
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
