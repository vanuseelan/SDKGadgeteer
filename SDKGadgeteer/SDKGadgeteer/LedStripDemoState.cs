using System;
using System.Threading;
using Microsoft.SPOT;

namespace SDKGadgeteer
{
    class LedStripDemoState : State
    {
        private int _Counter;

        public LedStripDemoState(Program handle) :
            base(handle, TypeState.Normal, 1000) //timer tick each 1000ms
        {
            //init variables
            _Counter = 0;
        }

        public override void Entry()
        {
            if (MainHandle.LED_Strip == null)
            {
                ConsoleDisplayN18.Clear();
                ConsoleDisplayN18.WriteLine("The module Led Strip is not connected.You have to connect in the socket 3 and in the Gadgeteer's designer(don't forget to recompile the project).");
                Thread.Sleep(2000);
                MainHandle.Context.GoBack();
            }
            else
            {
                ConsoleDisplayN18.Clear();
                ConsoleDisplayN18.WriteLine("Demo led strip !");
                StartListen(); //start timer and interface (button Home, back and joystick)

                MainHandle.LED_Strip.TurnAllLedsOn();
                Thread.Sleep(1000);
                Timer.Tick += Timer_Tick;
            }
        }

        public override void Exit()
        {
            if (MainHandle.LED_Strip != null)
            {
                //To do at the end (desubscribe events...)
                Timer.Tick -= Timer_Tick;
                StopListen();//Stop timer and interface

                //init state
                MainHandle.LED_Strip.TurnAllLedsOff();
            }
        }

        public override void Do()
        {
            //To do often
        }

        void Timer_Tick(Gadgeteer.Timer timer)
        {
            _Counter++;
            ConsoleDisplayN18.Write("Counter = " + _Counter + "s",50,50);

            MainHandle.LED_Strip.SetBitmask((uint)(_Counter % 65));
            /*if ((_Counter % 2) == 0)
            {
                MainHandle.ButtonLeft.TurnLEDOn();
                MainHandle.ButtonRight.TurnLEDOff();
            }
            else
            {
                MainHandle.ButtonLeft.TurnLEDOff();
                MainHandle.ButtonRight.TurnLEDOn();
            }*/
        }
    }
}
