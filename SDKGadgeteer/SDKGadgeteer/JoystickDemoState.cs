using System;
using System.Threading;
using Gadgeteer.Modules.GHIElectronics;
using Microsoft.SPOT;
using GT = Gadgeteer;

namespace SDKGadgeteer
{
    public sealed class JoystickDemoState : State
    {
        private uint _x;
        private uint _y;

        public JoystickDemoState(Program handle)
            : base(handle, TypeState.Normal)
        {          
        }

        public override void Entry()
        {
            StartListen();
            PrintText.Write("Press and move the joystick." , MainHandle.Display_N18);

            _x = MainHandle.Display_N18.Width / 2;
            _y = MainHandle.Display_N18.Height / 2;
            Draw();
        }

        public override void Exit()
        {
            StopListen();
        }

        public override void Do()
        {
            //Do nothing            
        }

        private bool _IsDetails = true;
        public override void JoystickReleased(Joystick sender, Joystick.JoystickState state)
        {
            _IsDetails=!_IsDetails;
        }

        public override void JoystickPosition(double X, double Y)
        {
            if (Y < -0.3)
            {
                _y = _y < 1 ? 0 : _y - (uint)(Y * 4); 
            }
            else if (Y > 0.3)
            {
                _y = _y > (MainHandle.Display_N18.Height - 1) ? MainHandle.Display_N18.Height : _y - (uint)(Y * 4);
            }


            if (X < -0.3)
            {
                _x = _x < 1 ? 0 : _x + (uint)(X * 4);
            }
            else if (X > 0.3)
            {
                _x = _x > (MainHandle.Display_N18.Width - 1) ? MainHandle.Display_N18.Width : _x + (uint)(X * 4);
            }
            Draw();
        }

        public void Draw()
        {
            string txt = _IsDetails ? "X (" + _x + "," + _y + ")" : "X";
           PrintText.Write(txt, MainHandle.Display_N18, _x, _y);
        }
    }
}
