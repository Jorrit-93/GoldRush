using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using MODL3_GoldRush.presentation;
using MODL3_GoldRush.domain;
using System.Timers;

namespace MODL3_GoldRush.process
{
	public class Controller
	{
		private InputView _inView;
		private OutputView _outView;
		private Map _map;
        private Timer _timer;

        public Controller()
		{
			_inView = new InputView();
			_outView = new OutputView();
			LoadMap(); //temp
			int millisec = 1000;
			CreateTimer(millisec); //temp
			Console.Read();
		}

        public void checkInput()
        {
            _inView.getSwitchInput();
            Console.WriteLine("testtesttesttesttest");

        }

		public void LoadMap()
		{
			string[] mapLines;
			int nr = 0; //temp
			mapLines = File.ReadAllLines(@Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + "\\Level" + nr + ".txt");
			_map = new Map(mapLines.Length, mapLines[0].Length);
			_map.CreateMap(mapLines);
			DrawMap();
		}

		public void CreateTimer(int millisec)
		{
			_timer = new Timer(millisec);
			_timer.Elapsed += new ElapsedEventHandler(AfterTimer);
			_timer.Enabled = true;
			_timer.AutoReset = true;
		}

		public void AfterTimer(Object sender, ElapsedEventArgs e)
		{
			_timer.Enabled = false;
			Random rnd = new Random(); //temp
			int cartSpawn = rnd.Next(1, 3);
			foreach (Cart c in _map.cartList)
			{
				c.tile.MoveCart();
			}
			if (cartSpawn == 1)
			{
				_map.CreateCart(0); //temp index
			}
			DrawMap();
			_timer.Enabled = true;
		}

		public void DrawMap()
		{
			Console.Clear();
			Tile firstRowTile = _map._firstTile;
			Tile secondRowTile = _map._firstTile.downTile;
			for (int i = 0; i <_map._height; i++)
			{
				for (int j = 0; j < _map._width; j++)
				{
					Console.Write(firstRowTile.drawSymbol());
					firstRowTile = firstRowTile.rightTile;
				}
				firstRowTile = secondRowTile;
				if (secondRowTile != null)
				{
					secondRowTile = firstRowTile.downTile;
				}
				Console.WriteLine();
			}
		}
    }
}
