using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODL3_GoldRush.domain
{
	public class Cart
	{
		public char symbol { get; set; }
		public Direction cartDirection { get; set; }
		public Tile tile { get; set; }

		public Cart()
		{
			symbol = '0';
			cartDirection = Direction.Right;
		}

		public void Unload()
		{
			symbol = 'O';
		}
	}
}
