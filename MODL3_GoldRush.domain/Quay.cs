using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODL3_GoldRush.domain
{
	public class Quay : Track
	{
		public Quay(Direction inDirection, Direction outDirection, char symbol) : base(inDirection, outDirection, symbol)
		{
		}

		public override int AcceptCart(Track inputTrack)
		{
			inputTrack._cart.Unload();
			return base.AcceptCart(inputTrack);
		}
	}
}
