using System;
using Gadgeteer.Modules.GHIElectronics;
using Microsoft.SPOT;
using GT = Gadgeteer;

namespace SDKGadgeteer
{
    static class ConsoleDisplayN18
    {
        //Info _limitCharLine = 21;
        //Info _limitLine13 = 21;
        //private static int _heigthChar = 12;
        //private static int _WidthChar = 5;
        private static uint _cursorX = 0;
        private static uint _cursorY = 0;
        private static Display_N18 _Screen = null;
        private static uint _Width;
        private static uint _Height;

        public static Display_N18 Screen
        {
            get { 
                return _Screen; 
            }
            set
            {
                _Screen = value;
                _Width = _Screen.Width;
                _Height = _Screen.Height;
            }
        }

        public static void Clear()
        {
            Screen.Clear();
            _cursorX = 0;
            _cursorY = 0;
        }
        

        public static void Write(string message)
        {
            Write(message, _cursorX, _cursorY);
        }
        public static void WriteLine(string message)
        {
            Write(message+"\n", _cursorX, _cursorY);
        }

        public static void Write(string message, uint x, uint y)
        {
            _cursorY = y;
            _cursorX = 0; //TODO...withString
            CheckCursorInScreen();
            int withString = 0;
            int heightString = 0;
            int posNewLine = 0;
            int limit = 0;
            string messageRest = message;
            bool newLine = false;
            Font font = Resources.GetFont(Resources.FontResources.small);

            while (messageRest.Length > 0)
            {
                posNewLine = messageRest.IndexOf('\n');

                if (posNewLine != -1 )
                    font.ComputeExtent(messageRest.Substring(0, posNewLine), out withString, out heightString);
                
                if (posNewLine != -1 && _Width > withString)
                {
                    limit = posNewLine;
                    newLine = true;
                }
                else
                {
                    newLine = false;
                    limit =limit < 50 ? messageRest.Length : 50;
                    font.ComputeExtent(messageRest.Substring(0, limit), out withString, out heightString);
                    
                   while(_Width < withString)
                    {
                        limit--;
                        font.ComputeExtent(messageRest.Substring(0, limit), out withString, out heightString);
                    }

                }

                WriteSimple(messageRest.Substring(0, limit), _cursorX, _cursorY);
                _cursorY += (uint)heightString;

                if (newLine)
                {
                    limit++; // char after newline
                    _cursorX = 0;
                }

                messageRest = messageRest.Substring(limit, messageRest.Length - limit);
            }
        }

        public static void WriteSimple(string str, uint x, uint y)
        {
            int withString = 0;
            int heightString = 0;
            Font font = Resources.GetFont(Resources.FontResources.small);
            font.ComputeExtent(str, out withString, out heightString);

            Bitmap textBmp = new Bitmap(withString, heightString);
            //textBmp.DrawRectangle(GT.Color.White, 1, 0, 0, 75, 12, 0, 0, GT.Color.White, 0, 0, GT.Color.White, 75, 12, 0xFF);
            textBmp.DrawText(str, font, GT.Color.White, 0, 0);
            Screen.Draw(textBmp, x, y);
            textBmp.Dispose();
        }
        public static void ClearSimple(string stringtoclear, uint x, uint y)
        {
            int withString = 0;
            int heightString = 0;
            Font font = Resources.GetFont(Resources.FontResources.small);
            font.ComputeExtent(stringtoclear, out withString, out heightString);

            Bitmap textBmp = new Bitmap(withString, heightString);
            Screen.Draw(textBmp, x, y);
            textBmp.Dispose();
        }

        private static void CheckCursorInScreen()
        {
            if (_cursorX > _Width)
                _cursorX = 0;


            if ((_cursorY + 12) > _Height)
            {
                Screen.Clear();
                _cursorY = 0;
            }
        }
    }
}
