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
			while (true)
			{
				char key = Console.ReadKey().KeyChar;
				switch (key)
				{
					case 'a':
					case 's':
					case 'd':
					case 'x':
					case 'c':
						return key;
					case 'q':
						Environment.Exit(0);
						break;
				}
			}
        }
    }
}
