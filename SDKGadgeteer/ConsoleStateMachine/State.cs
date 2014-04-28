using System;

namespace ConsoleStateMachine
{
    public abstract class State
    {
        private bool _stopListen = false;
        private TypeState _typeState;

        public enum TypeState {Error,Start,Final,Normal}; 

        public State(TypeState type)
        {
            _typeState = type;
        }

        public TypeState Type
        {
            get { return _typeState; }
        }

        public abstract void Entry();
        public abstract void Exit();
        public abstract void Do();

        public void StartListen()
        {
            _stopListen = false;
            Listen();
        }
        public void StopListen()
        {
            _stopListen = true;
        }

        public virtual void ButtonLeftPressed()
        {
            Program.Context.GoBack();
        }

        public virtual void ButtonRightPressed()
        {
            Program.Context.GoStart();
        }

        public virtual void JoystickPressed()
        {
        }

        public virtual void JoystickPosition(double X, double Y)
        {
        }

        private void Listen()
        {
            string command = "";
            if (!_stopListen)
            {
                command = Console.ReadLine();
                ConsoleDisplayN18.ClearLine();
                switch (command)
                {
                    case "4"://Joystick .LeftArrow: //Do something  
                        JoystickPosition(-1, 0);
                        break;
                    case "8"://Joystick.UpArrow:  //Do something
                        JoystickPosition(0, 1);
                        break;
                    case "6"://Joystick.RightArrow: //Do something
                        JoystickPosition(1, 0);
                        break;
                    case "2"://Joystick.DownArrow: //Do something 
                        JoystickPosition(0, -1);
                        break;
                    case "5": //Joystick button  
                        JoystickPressed();
                        break;
                    case "1": //Left button  
                        ButtonLeftPressed();
                        break;
                    case "3": //right button  
                        ButtonRightPressed();
                        break;
                }
                if (command != "q" || command != "Q")
                    Listen();
            }
        }

    }
}
