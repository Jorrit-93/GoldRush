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

		public override bool AcceptCart(Track prevTrack)
		{
			throw new NotImplementedException();
		}
		public override bool MoveCart()
		{
			throw new NotImplementedException();
		}

		public override void SwitchDirection(Direction d)
		{
			throw new NotImplementedException();
		}

		public new char drawSymbol()
		{
			return base.drawSymbol();
		}
	}
}
