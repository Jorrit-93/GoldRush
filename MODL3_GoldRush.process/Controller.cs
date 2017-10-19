using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MODL3_GoldRush.presentation;

namespace MODL3_GoldRush.process
{
	public class Controller
	{
		private InputView inView;
		private OutputView outView;

		public Controller()
		{
			inView = new InputView();
			outView = new OutputView();
		}
	}
}
