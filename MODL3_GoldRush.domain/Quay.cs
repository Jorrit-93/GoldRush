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

		public override int AcceptMovable(Track inputTrack)
		{
			if (upTile.leftTile.leftTile.movable != null && upTile.rightTile.rightTile.movable != null)
			{
				inputTrack.movable.Unload();
				base.AcceptMovable(inputTrack);
				return 2;
			}
			else
			{
				return base.AcceptMovable(inputTrack);
			}
		}
	}
}
