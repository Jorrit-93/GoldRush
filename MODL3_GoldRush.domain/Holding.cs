using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODL3_GoldRush.domain
{
	public class Holding : Track
	{
		public Holding(Direction inDirection, Direction outDirection, char symbol) : base(inDirection, outDirection, symbol)
		{
		}

		public override int AcceptMovable(Track inputTrack)
		{
			inputTrack.movable.Unload();
			return base.AcceptMovable(inputTrack);
		}

		public override int MoveMovable()
		{
			base.MoveMovable();
			return 1;
		}
	}
}
