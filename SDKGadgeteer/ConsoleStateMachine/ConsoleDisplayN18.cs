using System;

namespace ConsoleStateMachine
{
    static class ConsoleDisplayN18
    {
        private static int _limitCharLine = 21;
        private static int _limitLines = 13;

        public static void setConsoleSize()
        {
            System.Console.SetWindowPosition(0, 0);   // sets window position to upper left
            System.Console.SetWindowSize(_limitCharLine, _limitLines + 1);   //set window size to almost full screen
            System.Console.SetBufferSize(_limitCharLine, _limitLines + 1);   // make sure buffer is bigger than window
            //System.Console.ResetColor(); //resets fore and background colors to default
        }

        public static void Clear()
        {
            Console.Clear();
        }

        public static void ClearLine()
        {
            int currentLineCursor = Console.CursorTop-1;
            Console.SetCursorPosition(0, currentLineCursor);
            for (int i = 0; i < Console.WindowWidth; i++)
                Console.Write(" ");
            Console.SetCursorPosition(0, currentLineCursor);
        }

        public static void WriteLine(string message)
        {
            Console.WriteLine(message);
        }
    }
}
