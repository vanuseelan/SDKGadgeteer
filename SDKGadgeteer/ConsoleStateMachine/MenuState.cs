using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ConsoleStateMachine 
{
    class MenuState : State
    {
        private string _title;
        private string[] _menu;
        private State[] _arrayState;
        private int _cursorLine = 0;

        private int Cursor
        {
            get { return _cursorLine; }
            set {
                _cursorLine = value;

                if(_cursorLine > 9) //9 is the last index of menu
                    _cursorLine = 9; 

                if(_cursorLine < 0)
                     _cursorLine = 0; 
            }
        }

        public MenuState()
            : base(TypeState.Normal)
        {
            _title = "Menu";
            _menu = new string[10];
            _menu[0] = "Demo Listen";
            _menu[1] = "menu2";
            _menu[2] = "menu";
            _menu[3] = "menu";
            _menu[4] = "menu";
            _menu[5] = "menu";
            _menu[6] = "menu";
            _menu[7] = "menu";
            _menu[8] = "menu";
            _menu[9] = "menu";

            _arrayState = new State[10];
            _arrayState[0] = new DemoListenState();
            //_arrayState[1] = new TrucState();
        }

        private void SelectState(int menuItem)
        {
            if (_arrayState[menuItem] != null)
            {
                Program.Context.CurrentState = _arrayState[menuItem];
            }
        }

        public override void Entry()
        {
            Do();
            StartListen();
        }

        public override void Exit()
        {
            StopListen();
        }

        public override void Do()
        {
            ConsoleDisplayN18.Clear();

            ConsoleDisplayN18.WriteLine(_title+"\n");
            for (uint i = 0; i < _menu.Length; i++)
            {
               if (i == Cursor)
                {
                    ConsoleDisplayN18.WriteLine("=>"+_menu[i] + "<=");
                }
                else
                {
                    ConsoleDisplayN18.WriteLine(_menu[i] );
                }
            }
        }
        
        public override void JoystickPressed()
        {
            SelectState(Cursor);
        }

        public override void JoystickPosition(double X, double Y)
        {
            if (Y < -0.7)
            {
                Cursor++;
                Do();
                Thread.Sleep(100);
            }
            else if (Y > 0.7)
            {
                Cursor--;
                Do();
                Thread.Sleep(100);
            }
        }
    }
}
