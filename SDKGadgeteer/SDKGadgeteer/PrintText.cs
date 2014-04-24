using System;
using Gadgeteer.Modules.GHIElectronics;
using Microsoft.SPOT;
using GT = Gadgeteer;

namespace SDKGadgeteer
{
    static class PrintText
    {
        public static void Write(string str, Display_N18 screen, uint x, uint y)
        {
            uint size = 15;
            Bitmap textBmp = new Bitmap((int)screen.Width, (int)size);
            //textBmp.DrawRectangle(GT.Color.White, 1, 0, 0, 75, 12, 0, 0, GT.Color.White, 0, 0, GT.Color.White, 75, 12, 0xFF);
            textBmp.DrawText(str, Resources.GetFont(Resources.FontResources.small), GT.Color.White, (int)x,0);
            screen.Draw(textBmp, 0, y);
            textBmp.Dispose();
        }

        public static void Write(string message, Display_N18 screen)
        {
            uint x = 0;
            uint y = 0;
            int limitCharLine = 26;
            int limit = 0;
            uint heigthChar = 15;
            string messageRest = message;

            screen.Clear();
            while (messageRest.Length > 0)
            {
                limit = messageRest.Length > limitCharLine ? limitCharLine : messageRest.Length;
                Write(messageRest.Substring(0, limit), screen, x, y);
                y += heigthChar;
                messageRest = messageRest.Substring(limit, messageRest.Length - limit);
            }            
        }
    }
}
