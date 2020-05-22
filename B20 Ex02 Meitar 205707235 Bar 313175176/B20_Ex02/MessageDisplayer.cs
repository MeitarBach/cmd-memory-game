using System;
using System.Collections.Generic;

namespace B20_Ex02
{
    internal class MessageDisplayer
    {
        private const string k_EnterPlayer = "Please Enter Player Name: (no spaces, max 20 chars)";
        private const string k_ChooseOpponent = "Choose your oponnent:\n1.Human\n2.Computer";



        internal static string EnterPlayer
        {
            get
            {
                return k_EnterPlayer;
            }
        }
        
        internal static string ChooseOpponent
        {
            get
            {
                return k_ChooseOpponent;
            }
        }

        internal static void DisplayMessage(string i_Msg)
        {
            Console.WriteLine(i_Msg);
        }
    }
}
