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

		public override int AcceptCart(Track inputTrack)
		{
			if (_cart == null)
			{
				if (inputTrack._cart.cartDirection.Equals(SwitchDirection(_outDirection)))
				{
					Direction temp = _inDirection;
					_inDirection = SwitchDirection(_outDirection);
					_outDirection = SwitchDirection(temp);
				}
				if (inputTrack._cart.cartDirection.Equals(_inDirection))
				{
					Cart temp = inputTrack._cart;
					inputTrack._cart = null;
					temp.tile = this;
					_cart = temp;
					_cart.cartDirection = _outDirection;
					return 1;
				}
				return 1;
			}
			return -1;
		}
	}
}
