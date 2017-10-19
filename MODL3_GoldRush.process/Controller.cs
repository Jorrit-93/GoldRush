using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
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
			LoadMaze(); //temp
		}

		public void LoadMaze()
		{
			string[] lines;
			int nr = 1; //temp
			lines = File.ReadAllLines(@Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + "\\Level" + nr + ".txt");
			foreach(string s in lines)
			{
				Console.WriteLine(s);
			}
			Console.Read();
		}
	}
}
