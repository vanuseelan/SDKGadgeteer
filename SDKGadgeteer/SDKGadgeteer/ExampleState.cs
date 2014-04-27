using System;
using System.Threading;
using Microsoft.SPOT;

namespace SDKGadgeteer
{
    class ExampleState : State
    {
        private int _Counter;

        public ExampleState(Program handle) :
            base(handle, TypeState.Normal, 1000) //timer tick each 1000ms
        {
            //init variables
            _Counter = 0;
        }

        public override void Entry()
        {
            //To do at the start (subscribe events...)
            ConsoleDisplayN18.Clear();
            ConsoleDisplayN18.WriteLine("Hello World !");
            Thread.Sleep(1000);

            StartListen(); //start timer and interface (button Home, back and joystick)
            Timer.Tick += Timer_Tick;
        }

        public override void Exit()
        {
            //To do at the end (desubscribe events...)
            Timer.Tick -= Timer_Tick;
            StopListen();//Stop timer and interface

            //init state
            MainHandle.ButtonLeft.TurnLEDOff();
            MainHandle.ButtonRight.TurnLEDOff();
        }

        public override void Do()
        {
            _Counter++;
            ConsoleDisplayN18.Write("Counter = " + _Counter + "s", 50, 50);
            if ((_Counter % 2) == 0)
            {
                MainHandle.ButtonLeft.TurnLEDOn();
                MainHandle.ButtonRight.TurnLEDOff();
            }
            else
            {
                MainHandle.ButtonLeft.TurnLEDOff();
                MainHandle.ButtonRight.TurnLEDOn();
            }
        }

        void Timer_Tick(Gadgeteer.Timer timer)
        {
            Do();
        }
    }
}
