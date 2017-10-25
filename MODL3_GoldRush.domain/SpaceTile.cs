using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODL3_GoldRush.domain
{
	public class SpaceTile : Tile
	{
		public SpaceTile(char symbol) : base(symbol)
		{
		}

		public override int AcceptCart(Track prevTrack)
		{
			return 0;
		}
		public override int MoveCart()
		{
			return 0;
		}

		public override Direction SwitchDirection(Direction d)
		{
			throw new NotImplementedException();
		}

		public override char drawSymbol()
		{
			return _symbol;
		}
	}
}
