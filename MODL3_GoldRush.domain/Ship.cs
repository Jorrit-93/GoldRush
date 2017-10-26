using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODL3_GoldRush.domain
{
    public class Ship : Movable
    {
		private int shipLoad;

        public Ship(char symbol) : base(symbol, Direction.Right)
        {
			shipLoad = 1;
        }

		public override void Unload()
		{
			shipLoad++;
			switch (shipLoad)
			{
				case 1:
					symbol = '░';
					break;
				case 2:
					symbol = '▒';
					break;
				case 3:
					symbol = '▓';
					shipLoad = 0;
					break;
			}
		}
    }
}
