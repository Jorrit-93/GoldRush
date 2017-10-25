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
		private int timerInterval;
		private int spawnInterval;
        private Timer _timer;
        private bool isRunning;

        public Controller()
		{
			_inView = new InputView();
			_outView = new OutputView();
			LoadMap(); //
			timerInterval = 500;
			spawnInterval = 3;
			CreateTimer(); //temp
			Console.Read();
		}

        public int checkInput()
        {
            switch (_inView.getSwitchInput())
            {
                case 'a':
                    return 0;
                case 's':
                    return 1;
                case 'd':
                    return 2;
                case 'x':
                    return 3;
                case 'c':
                    return 4;
            }
            return 5;
        }

        public void Switch()
        {
            Console.WriteLine("test");
            _map.switchList[checkInput()].SwitchDirection();
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

		public void CreateTimer()
		{
			_timer = new Timer(timerInterval);
			_timer.Elapsed += new ElapsedEventHandler(AfterTimer);
			_timer.Enabled = true;
            isRunning = true;
			_timer.AutoReset = true;
		}

		public void AfterTimer(Object sender, ElapsedEventArgs e)
		{
			_timer.Enabled = false;
			SpawnCart(spawnInterval);
			Cart removeCart = null;
			foreach (Cart c in _map.cartList)
			{
				switch (c.tile.MoveCart())
				{
					case -1:
						//gameover
						break;
					case 0:
						removeCart = c;
						break;
				}
			}
			if(removeCart != null)
			{
				_map.cartList.Remove(removeCart);
			}
			DrawMap();
			_timer.Enabled = true;
            isRunning = true;
		}

		public void SpawnCart(int interval)
		{
			Random random = new Random();
			if (random.Next(0, interval) == 1)
			{
				_map.CreateCart(random.Next(0, _map.hangarList.Count));
			}
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
