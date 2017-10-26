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
		public Movable movable	{ get; set; }

		public Tile(char symbol)
		{
			_symbol = symbol;
		}

		public abstract int AcceptMovable(Track inputTrack);

		public abstract int MoveMovable();

        public abstract void Switch();

		public abstract Direction SwitchDirection(Direction inputDirection);

		public abstract char drawSymbol();
	}
}
