using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODL3_GoldRush.domain
{
	public abstract class Tile
	{
		public char _symbol;

		public Tile leftTile	{ get; set; }
		public Tile rightTile	{ get; set; }
		public Tile upTile		{ get; set; }
		public Tile downTile	{ get; set; }
		public Cart _cart		{ get; set; }

		public Tile(char symbol)
		{
			_symbol = symbol;
		}

		public abstract int AcceptCart(Track inputTrack);

		public abstract int MoveCart();

        public abstract void Switch();

		public abstract Direction SwitchDirection(Direction inputDirection);

		public abstract char drawSymbol();
	}
}
