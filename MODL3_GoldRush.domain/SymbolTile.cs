using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODL3_GoldRush.domain
{
	public class SymbolTile : Tile
	{
		public SymbolTile(char symbol) : base(symbol)
		{
		}

		public override int AcceptCart(Track inputTrack)
		{
			return 1;
		}

		public override int MoveCart()
		{
			throw new NotImplementedException();
		}

		public override void Switch()
		{
			throw new NotImplementedException();
		}

		public override Direction SwitchDirection(Direction inputDirection)
		{
			throw new NotImplementedException();
		}

		public override char drawSymbol()
		{
			return _symbol;
		}
    }
}
