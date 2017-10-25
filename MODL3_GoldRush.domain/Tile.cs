using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODL3_GoldRush.domain
{
	public abstract class Tile
	{
		private char _symbol;

		public Tile leftTile	{ get; set; }
		public Tile rightTile	{ get; set; }
		public Tile upTile		{ get; set; }
		public Tile downTile	{ get; set; }

		public Tile(char symbol)
		{
			_symbol = symbol;
		}

		public abstract bool AcceptCart(Track prevTrack);

		public abstract bool MoveCart();

		public abstract void SwitchDirection(Direction d);

		public char drawSymbol()
		{
			return _symbol;
		}
	}
}
