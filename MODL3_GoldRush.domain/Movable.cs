using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODL3_GoldRush.domain
{
	public abstract class Movable
	{
		public char symbol { get; set; }
		public Direction direction { get; set; }
		public Tile tile { get; set; }

		public Movable(char symbol, Direction direction)
		{
			this.symbol = symbol;
			this.direction = direction;
		}

		public abstract void Unload();
	}
}
