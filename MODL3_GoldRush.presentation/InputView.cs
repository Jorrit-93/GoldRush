using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODL3_GoldRush.presentation
{
	public class InputView
	{
        public char getSwitchInput()
        {
            char key = '9';
            char c = '?';
            while ((key != 'a' || key != 's' || key != 'd' || key != 'x' || key != 'c') && c != 'q')
            {
                Console.WriteLine("> Kies switch om aan te passen (A, S, D, X, C), q = stop");
                ConsoleKeyInfo consoleKeyInfo = Console.ReadKey();
                c = consoleKeyInfo.KeyChar;
                Console.WriteLine();
                if (c == 'a' || c == 's' || c == 'd' || c == 'x' || c == 'c')
                {
                    key = c;
                }
                else if (c != 's')
                {
                    Console.WriteLine("> ?");
                }
            }
            if (c == 'q')
            {
                Environment.Exit(0);
            }
            return key;
        }
    }
}
