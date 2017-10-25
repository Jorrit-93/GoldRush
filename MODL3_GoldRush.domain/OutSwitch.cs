using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODL3_GoldRush.domain
{
    public class OutSwitch : BaseSwitch
    {
        public OutSwitch(Direction inDirection, Direction outDirection, char symbol) : base(inDirection, outDirection, symbol)
        {
        }

        public override void Switch()
		{
			_outDirection = SwitchDirection(_outDirection);
			switch (_symbol)
			{
				case '╝':
					_symbol = '╗';
					break;
				case '╗':
					_symbol = '╝';
					break;
			}
		}
    }
}
