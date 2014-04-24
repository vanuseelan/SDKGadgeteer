using System;
using System.Threading;
using Gadgeteer.Modules.GHIElectronics;
using Microsoft.SPOT;
using GT = Gadgeteer;

namespace SDKGadgeteer
{
    public sealed class LedButtonState : State
    {
        public LedButtonState(Program handle)
            : base(handle, TypeState.Normal)
        {          
        }


        public override void Entry()
        {
            StartListen();

            PrintText.Write("Press the joystick to turn on/off the button's led." , MainHandle.Display_N18);
        }

        public override void Exit()
        {
            StopListen();

            MainHandle.ButtonLeft.TurnLEDOff();
            MainHandle.ButtonRight.TurnLEDOff();
        }

        public override void Do()
        {
            //Do nothing            
        }

        public override void JoystickPosition(double X, double Y)
        {
            //Do nothing  
        }

        public override void JoystickReleased(Joystick sender, Joystick.JoystickState state)
        {
            if (MainHandle.ButtonLeft.IsLedOn)
                MainHandle.ButtonLeft.TurnLEDOff();
            else
                MainHandle.ButtonLeft.TurnLEDOn();

            if (MainHandle.ButtonRight.IsLedOn)
                MainHandle.ButtonRight.TurnLEDOff();
            else
                MainHandle.ButtonRight.TurnLEDOn();
        }
    }
}
