using System;
using System.Threading;
using Gadgeteer.Modules.GHIElectronics;
using Microsoft.SPOT;

namespace SDKGadgeteer
{
    class TunesDemoState : State
    {
        private Tunes _Tunes;
        private Menu _menu;
        private string[] _melodyRTTL;

        public TunesDemoState(Program handle)
            : base(handle, TypeState.Normal)
        {
            _melodyRTTL = new String[9];
            _menu = new Menu(MainHandle.Display_N18);
            _menu.Title = "Demo Tunes";
            _menu.Lines[0] = "Super Mario Bros";
            _melodyRTTL[0] = "smb:d=4,o=5,b=100:16e6,16e6,32p,8e6,16c6,8e6,8g6,8p,8g,8p,8c6,16p,8g,16p,8e,16p,8a,8b,16a#,8a,16g.,16e6,16g6,8a6,16f6,8g6,8e6,16c6,16d6,8b,16p,8c6,16p,8g,16p,8e,16p,8a,8b,16a#,8a,16g.,16e6,16g6,8a6,16f6,8g6,8e6,16c6,16d6,8b,8p,16g6,16f#6,16f6,16d#6,16p,16e6,16p,16g#,16a,16c6,16p,16a,16c6,16d6,8p,16g6,16f#6,16f6,16d#6,16p,16e6,16p,16c7,16p,16c7,16c7,p,16g6,16f#6,16f6,16d#6,16p,16e6,16p,16g#,16a,16c6,16p,16a,16c6,16d6,8p,16d#6,8p,16d6,8p,16c6";
            _menu.Lines[1] = "Zelda: Ocarina Of Time";
            _melodyRTTL[1] = "zelda_gerudo:d=4,o=5,b=125:16c#,16f#,16g#,8a,16p,16c#,16f#,16g#,a,8p,16d,16f#,16g#,8a,16p,16d,16f#,16g#,a,8p,16b4,16e,16f#,8g#,16p,16b4,16e,16f#,g#,8p,16f#,16g#,16f#,2f,8p,16c#,16f#,16g#,8a,16p,16c#,16f#,16g#,a,8p,16d,16f#,16g#,8a,16p,16d,16f#,16g#,a,8p,16b4,16e,16f#,8g#,16p,16b4,16e,16f#,g#,8p,16a,16b,16a,2g#";
            _menu.Lines[2] = "Tetris";
            _melodyRTTL[2] = "korobyeyniki:d=4,o=5,b=160:e6,8b,8c6,8d6,16e6,16d6,8c6,8b,a,8a,8c6,e6,8d6,8c6,b,8b,8c6,d6,e6,c6,a,2a,8p,d6,8f6,a6,8g6,8f6,e6,8e6,8c6,e6,8d6,8c6,b,8b,8c6,d6,e6,c6,a,a";
            _menu.Lines[3] = "The Adams Family";
            _melodyRTTL[3] = "aadams:d=4,o=5,b=160:8c,f,8a,f,8c,b4,2g,8f,e,8g,e,8e4,a4,2f,8c,f,8a,f,8c,b4,2g,8f,e,8c,d,8e,1f,8c,8d,8e,8f,1p,8d,8e,8f#,8g,1p,8d,8e,8f#,8g,p,8d,8e,8f#,8g,p,8c,8d,8e,8f";
            _menu.Lines[4] = "Pink Panther";
            _melodyRTTL[4] = "PinkPanther:d=4,o=5,b=160:8d#,8e,2p,8f#,8g,2p,8d#,8e,16p,8f#,8g,16p,8c6,8b,16p,8d#,8e,16p,8b,2a#,2p,16a,16g,16e,16d,2e";
            _menu.Lines[5] = "Barbie Girl";
            _melodyRTTL[5] = "girl:d=4,o=5,b=125:8g#,8e,8g#,8c#6,a,p,8f#,8d#,8f#,8b,g#,8f#,8e,p,8e,8c#,f#,c#,p,8f#,8e,g#,f# ";
            _menu.Lines[6] = "Macarena";
            _melodyRTTL[6] = "Macarena:d=4,o=5,b=180:f,8f,8f,f,8f,8f,8f,8f,8f,8f,8f,8a,8c,8c,f,8f,8f,f,8f,8f,8f,8f,8f,8f,8d,8c,p,f,8f,8f,f,8f,8f,8f,8f,8f,8f,8f,8a,p,2c.6,a,8c6,8a,8f,p,2p";
            _menu.Lines[7] = "Indiana";
            _melodyRTTL[7] = "Indiana:d=4,o=5,b=250:e,8p,8f,8g,8p,1c6,8p.,d,8p,8e,1f,p.,g,8p,8a,8b,8p,1f6,p,a,8p,8b,2c6,2d6,2e6,e,8p,8f,8g,8p,1c6,p,d6,8p,8e6,1f.6,g,8p,8g,e.6,8p,d6,8p,8g,e.6,8p,d6,8p,8g,f.6,8p,e6,8p,8d6,2c6";
            _menu.Lines[8] = "The Simpsons";
            _melodyRTTL[8] = "The Simpsons:d=4,o=5,b=160:c.6,e6,f#6,8a6,g.6,e6,c6,8a,8f#,8f#,8f#,2g,8p,8p,8f#,8f#,8f#,8g,a#.,8c6,8c6,8c6,c6";
            _menu.Draw();

            _Tunes = MainHandle.Tunes;
        }

        private void PlayMelody(int menuItem)
        {
            RttlMelody melody = new RttlMelody(_melodyRTTL[menuItem]);
            _Tunes.Play(melody.ToMelody());
        }

        public override void Entry()
        {
            if (_Tunes == null)
            {
                ConsoleDisplayN18.Clear();
                ConsoleDisplayN18.WriteLine("The module Tunes is not connected.You have to connect in the socket 3 and in the Gadgeteer's designer(don't forget to recompile the project).");
                Thread.Sleep(2000);
                MainHandle.Context.GoBack();
            }
            else
            {
                StartListen();
            }
        }

        public override void Exit()
        {
            if (_Tunes != null)
            {
                StopListen();
            }
        }

        public override void Do()
        {
            //Do nothing            
        }

        public override void JoystickReleased(Joystick sender, Joystick.JoystickState state)
        {
            //ConsoleDisplayN18.Write("Selected " + _menu.CursorLine);
            //Thread.Sleep(1000);
            //_menu.Draw();
            PlayMelody(_menu.CursorLine);
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
