using System;
using Gadgeteer.Modules.GHIElectronics;
using Microsoft.SPOT;
using GT = Gadgeteer;

namespace SDKGadgeteer
{
    class Menu
    {
        private string _Title;
        private int _CursorLine = 0;
        private string[] _Lines;
        private Display_N18 _Screen;


        public Menu(Display_N18 screen)
        {
            _Screen = screen;
            //_Screen.SimpleGraphics.AutoRedraw = true;
            _Lines = new String[9];

        }

        public string[] Lines
        {
            get { return _Lines; }
        }

        public int CursorLine
        {
            get { return _CursorLine; }
            set {
                if (value >= 0 && value < _Lines.Length)
                    _CursorLine = value; 
            }
        }

        public string Title
        {
            get { return _Title; }
            set { _Title = value; }
        }

        public void Draw()
        {
            string titleScreen="";
            string line = "";
            uint limitCharTitle = 16;
            uint limitChar = 25;
            uint YFirstLine = 15;
            uint size = 15;

            _Screen.Clear();

            //write title
            titleScreen = _Title.Length > limitCharTitle ? _Title.Substring(0, 13) + "..." : _Title;
            WriteTitle(titleScreen, 0, 0);

            for (uint i = 0; i < _Lines.Length; i++)
            {
                if (_Lines[i] == "")
                    continue;

                line = _Lines[i].Length > limitChar ? _Lines[i].Substring(0, 22) + "..." : _Lines[i];
                if (i == _CursorLine)
                {
                    WriteLineSelected(line, 0, YFirstLine + size * i);
                }
                else
                {
                    WriteLine(line, 0, YFirstLine + size * i);
                }
            }
        }
        
        private void WriteTitle(string str, uint x, uint y)
        {
            uint size = 15;
            Bitmap textBmp = new Bitmap((int)_Screen.Width, (int)size);
            //textBmp.DrawRectangle(GT.Color.White, 1, 0, 0, 75, 12, 0, 0, GT.Color.White, 0, 0, GT.Color.White, 75, 12, 0xFF);
            textBmp.DrawText(str, Resources.GetFont(Resources.FontResources.NinaB), GT.Color.Green,0,0);
            _Screen.Draw(textBmp, x,y);
            textBmp.Dispose();
        }

        private void WriteLine(string str, uint x,uint y)
        {
            uint size = 15;
            Bitmap textBmp = new Bitmap((int)_Screen.Width, (int)size);
            //textBmp.DrawRectangle(GT.Color.White, 1, 0, 0, 75, 12, 0, 0, GT.Color.White, 0, 0, GT.Color.White, 75, 12, 0xFF);
            textBmp.DrawText(str, Resources.GetFont(Resources.FontResources.small), GT.Color.White, 0,0);
            _Screen.Draw(textBmp, x, y);
            textBmp.Dispose();
        }

        private void WriteLineSelected(string str, uint x, uint y)
        {
            int size = 15;
            Bitmap textBmp = new Bitmap((int)_Screen.Width, (int)size);
            textBmp.DrawRectangle(GT.Color.White, 0, 0, 0, (int)_Screen.Width, size, 0, 0, GT.Color.White, 0, 0, GT.Color.White, 0, 0, 0xFF);
            textBmp.DrawText(str, Resources.GetFont(Resources.FontResources.NinaB), GT.Color.Black,0,0);
            _Screen.Draw(textBmp, x, y);
            textBmp.Dispose();
        }
    }
}
