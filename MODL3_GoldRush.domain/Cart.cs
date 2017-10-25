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

		public Cart()
		{
			symbol = 'Û';
		}

		public void Unload()
		{
			symbol = 'U';
		}
	}
}
