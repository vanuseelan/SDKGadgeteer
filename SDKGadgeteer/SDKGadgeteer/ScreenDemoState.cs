/*
FEZ Cerberus has 192kB and N18 display has 128x160 pixels.
With 16BPP an image would take 128x160x2=40960 bytes per image...too big for cerberus 
 */

using System;
using System.Collections;
using System.Reflection;
using System.Threading;
using Gadgeteer.Modules.GHIElectronics;
using GHI.OSHW.Hardware;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using Microsoft.SPOT.Presentation.Media;
using GT = Gadgeteer;

namespace SDKGadgeteer
{
    class ScreenDemoState : State
    {
        public ScreenDemoState(Program handle) :
            base(handle, TypeState.Normal)
        { 
        }

        public override void Entry()
        {
            StartListen();

            ConsoleDisplayN18.Clear();
            ConsoleDisplayN18.WriteLine("Size Display : " + ConsoleDisplayN18.Screen.Width + "x" + ConsoleDisplayN18.Screen.Height);
            ConsoleDisplayN18.WriteLine("Line 2");
            ConsoleDisplayN18.WriteLine("Line 3");
            ConsoleDisplayN18.WriteLine("Line 4");
            ConsoleDisplayN18.WriteLine("Line 5");
            ConsoleDisplayN18.WriteLine("0123456789X123........456789X123456___________789X12345");
            ConsoleDisplayN18.WriteLine("Line 9\nLine 10\nLine 11\nLine 12\nLine 13");
        }
        
        public override void Exit()
        {
            StopListen();
        }

        public override void Do()
        {
            //Do nothing
        }

        #region test 128x160
        //private uint _x;
        //private uint _y;

        //public override void JoystickReleased(Joystick sender, Joystick.JoystickState state)
        //{
        //    Display_N18 screen = MainHandle.Display_N18;
        //    screen.Clear();
        //}

        //public override void JoystickPosition(double X, double Y)
        //{
        //    if (Y < -0.3)
        //    {
        //        _y = _y < 1 ? 0 : _y - (uint)(Y * 2);
        //    }
        //    else if (Y > 0.3)
        //    {
        //        _y = _y > (MainHandle.Display_N18.Height - 1) ? MainHandle.Display_N18.Height : _y - (uint)(Y * 2);
        //    }


        //    if (X < -0.3)
        //    {
        //        _x = _x < 1 ? 0 : _x + (uint)(X * 2);
        //    }
        //    else if (X > 0.3)
        //    {
        //        _x = _x > (MainHandle.Display_N18.Width - 1) ? MainHandle.Display_N18.Width : _x + (uint)(X * 2);
        //    }

        //    Display_N18 screen = MainHandle.Display_N18;
        //    Bitmap cursorClearBmp = new Bitmap(10, 10);
        //    Bitmap cursorBmp = new Bitmap(1, 1);
        //    Bitmap cursorPositionBmp = new Bitmap(120, 20);

        //    //clear old cursor
        //    cursorClearBmp.DrawRectangle(GT.Color.Black, 1, 0, 0, 10, 10, 0, 0, GT.Color.Black, 0, 0, GT.Color.Black, 10, 10, 0xFF);
        //    screen.Draw(cursorClearBmp, _x-5, _y-5);

        //    //draw new cursor
        //    cursorBmp.SetPixel(0,0,GT.Color.White);
        //    screen.Draw(cursorBmp, _x, _y);
           
        //    //clear old text
        //    screen.Draw(cursorPositionBmp, screen.Width / 2, screen.Height / 2); 
        //    //write new text
        //    cursorPositionBmp.DrawText("(" + _x + "," + _y + ") [" + screen.Width + "," + screen.Height + "]", Resources.GetFont(Resources.FontResources.small), GT.Color.White, 0, 0);
        //    screen.Draw(cursorPositionBmp, 0, screen.Height / 2);

        //    cursorPositionBmp.Dispose();
        //    cursorBmp.Dispose();
        //    cursorClearBmp.Dispose();
        //}
        #endregion

    }
}
