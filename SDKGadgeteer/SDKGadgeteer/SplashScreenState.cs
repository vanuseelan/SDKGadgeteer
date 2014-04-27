using System;
using System.Reflection;
using System.Threading;
using Gadgeteer.Modules.GHIElectronics;
using Microsoft.SPOT;

namespace SDKGadgeteer
{
    class SplashScreenState : State
    {
        public SplashScreenState(Program handle, int timerIntervalMilliseconds = 100) :
            base(handle, TypeState.Start, timerIntervalMilliseconds)
        {
        }

        public override void Entry()
        {
            ConsoleDisplayN18.Clear();
            ConsoleDisplayN18.Write("Demo Start", 0, 0);
            Thread.Sleep(1000);
            MainHandle.Context.CurrentState = new MainState(MainHandle);
        }

        public override void Exit()
        {
            //Do nothing
        }

        public override void Do()
        {
            //Do nothing
        }
    }
}
