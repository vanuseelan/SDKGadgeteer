using System;

namespace ConsoleStateMachine
{
    public sealed class ErrorState : State
    {
        private Exception _Error;
        
        public ErrorState():
            base(TypeState.Error)
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
