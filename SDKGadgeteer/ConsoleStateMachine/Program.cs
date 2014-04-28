using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ConsoleStateMachine
{
    public class Program
    {
        #region Accessors
        private static Context _Context;

        public static Context Context
        {
            get { return _Context; }
        }
        #endregion

        public static void Main(string[] args)
        {
            ConsoleDisplayN18.setConsoleSize();
            /*ConsoleDisplayN18.Clear();
            ConsoleDisplayN18.WriteLine("Size Display : " + Console.BufferWidth + "x" + Console.BufferHeight);
            ConsoleDisplayN18.WriteLine("Line 2");
            ConsoleDisplayN18.WriteLine("Line 3");
            ConsoleDisplayN18.WriteLine("Line 4");
            ConsoleDisplayN18.WriteLine("Line 5");
            ConsoleDisplayN18.WriteLine("0123456789X123........456789X123456___________789X12345");
            ConsoleDisplayN18.WriteLine("Line 9\nLine 10\nLine 11\nLine 12\nLine 13");
            */
            State startState = new SplashScreenState();
            ErrorState errorState = new ErrorState();
            _Context = new Context(startState, errorState);
            _Context.Start();
        }
    }
}
