using System;
using System.IO;
using System.Text;
using System.Threading;
using Microsoft.SPOT;

namespace SDKGadgeteer
{
    class SDCardState : State
    {
        private string _Filename = "ExampleData.xml";
        private ExampleData _Data;

        public SDCardState(Program handle) :
            base(handle, TypeState.Normal, 1000) //timer tick each 1000ms
        {
            //init variables
        }

        public override void Entry()
        {
            StartListen(); //start timer and interface (button Home, back and joystick)
            PrintLastDate();
        }

        public override void Exit()
        {
            //To do at the end (desubscribe events...)
            if (MainHandle.SdCard.IsCardMounted)
            {
                //save date
                _Data = new ExampleData();
                _Data.LastDate = DateTime.Now;
                SaveData();
            }
            else
            {
                ConsoleDisplayN18.Clear();
                ConsoleDisplayN18.WriteLine("Sorry I cannot save the date.");
                Thread.Sleep(1000);                
            }

            StopListen();//Stop timer and interface
        }

        public override void Do()
        {
            //To do often
        }

        public override void JoystickPressed(Gadgeteer.Modules.GHIElectronics.Joystick sender, Gadgeteer.Modules.GHIElectronics.Joystick.JoystickState state)
        {
            _Data = new ExampleData();
            _Data.LastDate = DateTime.Now;
            SaveData();
            PrintLastDate();
        }


        private void PrintLastDate()
        {
            ReadData();
            if (_Data != null)
            {
                ConsoleDisplayN18.Clear();
                ConsoleDisplayN18.WriteLine("The last date save in the SDCard : " + _Data.LastDate.ToString());
            }
        }

        private void SaveData()
        {
            string rootDirectory = MainHandle.SdCard.GetStorageDevice().RootDirectory;
            if (_Data != null && MainHandle.SdCard.IsCardMounted)
                    ExampleData.XmlSerialize(rootDirectory + @"\" + _Filename, _Data);
        }

        private void ReadData()
        {
            if (IsMountSdCard()) //ask to mountSD
            {
                string rootDirectory = MainHandle.SdCard.GetStorageDevice().RootDirectory;
                _Data = ExampleData.XmlDeSerialize(rootDirectory + @"\" + _Filename);
                Debug.Print("Last record : " + _Data.LastDate.ToString());
            }
        }

        private bool IsMountSdCard()
        {
            bool result = false;
            if (!MainHandle.SdCard.IsCardInserted)
            {

                ConsoleDisplayN18.Clear();
                ConsoleDisplayN18.WriteLine("Insert the SDCard.");
                ConsoleDisplayN18.WriteLine("After press Joystick.");
            }
            else
            {
                if (!MainHandle.SdCard.IsCardMounted)
                    MainHandle.SdCard.MountSDCard();

                result = true;
            }
            return result;
        }

    }
}
