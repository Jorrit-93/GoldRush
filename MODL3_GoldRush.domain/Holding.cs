using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODL3_GoldRush.domain
{
	public class Holding : Track
	{
		public Holding(Direction inDirection, Direction outDirection, char symbol) : base(inDirection, outDirection, symbol)
		{
		}
	}
}
