using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODL3_GoldRush.domain
{
	public class BaseSwitch : Track
	{
		public BaseSwitch(Direction inDirection, Direction outDirection, char symbol) : base(inDirection, outDirection, symbol)
		{
		}

		public override int AcceptMovable(Track inputTrack)
		{
			if (movable == null)
			{
				if (inputTrack.movable.direction.Equals(SwitchDirection(_outDirection)))
				{
					Direction temp = _inDirection;
					_inDirection = SwitchDirection(_outDirection);
					_outDirection = SwitchDirection(temp);
				}
				if (inputTrack.movable.direction.Equals(_inDirection))
				{
					Movable temp = inputTrack.movable;
					inputTrack.movable = null;
					temp.tile = this;
					movable = temp;
					movable.direction = _outDirection;
					return 1;
				}
				return 1;
			}
			return -1;
		}
	}
}
