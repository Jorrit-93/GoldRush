using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODL3_GoldRush.domain
{
	public class Hangar : Track
	{
		public Hangar(Direction inDirection, Direction outDirection, char symbol) : base(inDirection, outDirection, symbol)
		{

		}

		public override bool MoveCart()
		{
			_cart = new Cart();
			return base.MoveCart();
		}
	}
}
