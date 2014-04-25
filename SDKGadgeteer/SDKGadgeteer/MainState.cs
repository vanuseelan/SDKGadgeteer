using System;
using System.Threading;
using Gadgeteer.Modules.GHIElectronics;
using Microsoft.SPOT;
using GT = Gadgeteer;

namespace SDKGadgeteer
{
    public sealed class MainState : State
    {
        private Menu _menu;

        public MainState(Program handle) : base(handle,TypeState.Normal)
        {
            _menu = new Menu(MainHandle.Display_N18);
            _menu.Title = "SDK Gadgeteer";
            _menu.Lines[0] = "On/off Button led";
            _menu.Lines[1] = "Demo Joystick";
            _menu.Lines[2] = "Demo Timer";
            _menu.Lines[3] = "Demo SDCard";
            _menu.Lines[4] = "Demo Tunes";
            _menu.Lines[5] = "Item5";
            _menu.Lines[6] = "Item6";
            _menu.Lines[7] = "Item7";
            _menu.Lines[8] = "Infos,versions,...";
            _menu.Draw();          
        }

        private void SelectState(int menuItem)
        {
            switch (menuItem)
            {
                case 0:
                    MainHandle.Context.CurrentState = new LedButtonState(MainHandle);
                    break;
                case 1:
                    MainHandle.Context.CurrentState = new JoystickDemoState(MainHandle);
                    break;
                case 2:
                    MainHandle.Context.CurrentState = new ExampleState(MainHandle);
                    break;
                case 3:
                    MainHandle.Context.CurrentState = new SDCardState(MainHandle);
                    break;
                case 4:
                    MainHandle.Context.CurrentState = new TunesDemoState(MainHandle);
                    break;
                case 8:
                    MainHandle.Context.CurrentState = new InfoState(MainHandle);
                    break;
            }
        }
        
        public override void Entry()
        {
            StartListen();
        }

        public override void Exit()
        {
            StopListen();
        }

        public override void Do()
        {
            //Do nothing            
        }

        public override void JoystickReleased(Joystick sender, Joystick.JoystickState state)
        {
            //PrintText.Write("Selected " + _menu.CursorLine, MainHandle.Display_N18);
            //Thread.Sleep(1000);
            //_menu.Draw();
            SelectState(_menu.CursorLine);
        }
        
        public override void JoystickPosition(double X, double Y)
        {
            if (Y < -0.7)
            {
                _menu.CursorLine++;
                _menu.Draw();
                Thread.Sleep(100);
            }
            else if (Y > 0.7)
            {
                _menu.CursorLine--;
                _menu.Draw();
                Thread.Sleep(100);
            }
        }
    }
}
