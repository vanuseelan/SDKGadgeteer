using System;
using Gadgeteer.Modules.GHIElectronics;
using Microsoft.SPOT;
using GT = Gadgeteer;

namespace SDKGadgeteer
{
    public sealed class ErrorState : State
    {
        private Exception _Error;
        
        public ErrorState(Program handle, int timerIntervalMilliseconds = 100):
            base(handle,TypeState.Error,timerIntervalMilliseconds)
        {
        }

        public Exception Error
        {
            get { return _Error; }
            set { _Error = value; }
        }

        public override void Entry()
        {
            Display_N18 screen = MainHandle.Display_N18;
           PrintText.Write(Error.Message + " " + Error.StackTrace, screen);
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
