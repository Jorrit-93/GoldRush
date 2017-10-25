using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODL3_GoldRush.domain
{
	public class Corner : Track
	{
		public Corner(Direction inDirection, Direction outDirection, char symbol) : base(inDirection, outDirection, symbol)
		{
		}

		public override bool AcceptCart(Track prevTrack)
		{
			return base.AcceptCart(prevTrack);
		}
	}
}
