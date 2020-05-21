using System;
using System.Collections.Generic;

namespace B20_Ex02
{
    internal class MessageDisplayer
    {
        private const string k_EnterPlayerOne = "Please Enter Player #1 Name: (no spaces, max 20 chars)";


        internal static string EnterPlayerOne
        {
            get
            {
                return k_EnterPlayerOne;
            }
        }

        internal static void DisplayMessage(string i_Msg)
        {
            Console.WriteLine(i_Msg);
        }
    }
}
