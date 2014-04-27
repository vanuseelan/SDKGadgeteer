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
            ConsoleDisplayN18.Clear();
            ConsoleDisplayN18.WriteLine(Error.Message + " " + Error.StackTrace);
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
