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
            ConsoleDisplayN18.Clear();
            ConsoleDisplayN18.WriteLine("Press and move the joystick.");

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
            Clear();
            _IsDetails=!_IsDetails;
            Draw();
        }

        public override void JoystickPosition(double X, double Y)
        {
            Clear();
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

        public void Clear()
        {
            string txt = _IsDetails ? "X (" + _x + "," + _y + ")" : "X";
            ConsoleDisplayN18.ClearSimple(txt, _x, _y);
        }
        public void Draw()
        {
            string txt = _IsDetails ? "X (" + _x + "," + _y + ")" : "X";
            ConsoleDisplayN18.WriteSimple(txt, _x, _y);
        }
    }
}
