using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODL3_GoldRush.domain
{
	public class Cart : Movable
	{
		public Cart() : base('0', Direction.Right)
		{
		}

		public override void Unload()
		{
			symbol = 'O';
		}
	}
}
