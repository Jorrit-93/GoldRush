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
		private int _shipMoving;
		private int _spawnInterval;

		private bool _getInput;

        private Timer _cartTimer;
		private int _cartTimerInterval;

		private Timer _shipTimer;
		private int _shipTimerInterval;

		private Timer _timeTimer;
		private int _timeTimerInterval;

		public Controller()
		{
			_inView = new InputView();
			_outView = new OutputView();
			LoadMap(); //temp
			_cartTimerInterval = 2000; //temp
			_shipTimerInterval = 500;
			_timeTimerInterval = 1000;

			_map.time = _cartTimerInterval / 1000;

			_getInput = true;

			_shipMoving = 0;
			_spawnInterval = 3; //temp

			CreateCartTimer(); //temp
			CreateShipTimer(); //temp
			CreateTimeTimer(); //temp

			_cartTimer.Enabled = true;
			_timeTimer.Enabled = true;

			while (_getInput) //temp
			{
				Switch();
			}
		}

		public void Switch()
		{
			int hangarIndex = CheckInput();
			if (_map.switchList[hangarIndex].movable == null)
			{
				_map.switchList[hangarIndex].Switch();
			}
			DrawMap();
		}

		public int CheckInput()
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
			return -1;
		}

		public void LoadMap()
		{
			string[] mapLines;
			int nr = 1; //temp
			mapLines = File.ReadAllLines(@Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + "\\Level" + nr + ".txt");
			_map = new Map(mapLines.Length, mapLines[0].Length);
			_map.CreateMap(mapLines);
		}

		public void CreateCartTimer()
		{
			_cartTimer = new Timer(_cartTimerInterval);
			_cartTimer.Elapsed += new ElapsedEventHandler(AfterCartTimer);
			_cartTimer.AutoReset = true;
		}

		public void CreateShipTimer()
		{
			_shipTimer = new Timer(_shipTimerInterval);
			_shipTimer.Elapsed += new ElapsedEventHandler(AfterShipTimer);
			_shipTimer.AutoReset = true;
		}

		public void CreateTimeTimer()
		{
			_timeTimer = new Timer(_timeTimerInterval);
			_timeTimer.Elapsed += new ElapsedEventHandler(AfterTimeTimer);
			_timeTimer.AutoReset = true;
		}

		public void GameOver()
		{
			_cartTimer.Enabled = false;
			_shipTimer.Enabled = false;
			_timeTimer.Enabled = false;
			_getInput = false;
			Console.Beep();
			Console.WriteLine();
			Console.WriteLine("GAME OVER");
		}

		public void AfterCartTimer(Object sender, ElapsedEventArgs e)
		{
			_cartTimer.Enabled = false;
			SpawnCart(_spawnInterval);
			Cart removeCart = null;
			bool gameOver = false;
			foreach (Cart c in _map.cartList)
			{
				switch (c.tile.MoveMovable())
				{
					case -1:
						gameOver = true;
						break;
					case 0:
						c.tile.movable = null;
						removeCart = c;
						break;
					case 2:
						_map.score++;
						_map.shipLoad++;
						switch (_map.shipLoad)
						{
							case 4:
								_map.shipArray[2].Unload();
								break;
							case 8:
								_map.shipArray[2].Unload();
								_map.score = _map.score + 10;
								_map.shipLoad = 0;
								_shipTimer.Enabled = true;
								if (_cartTimerInterval > 1000)
								{
									_cartTimerInterval = _cartTimerInterval / 2;
									_cartTimer.Interval = _cartTimerInterval;
								}
								break;
						}
						break;
				}
			}
			if(removeCart != null)
			{
				_map.cartList.Remove(removeCart);
			}
			DrawMap();
			_cartTimer.Enabled = true;
			if (gameOver)
			{
				GameOver();
			}
		}

		public void AfterShipTimer(Object sender, ElapsedEventArgs e)
		{
			_shipTimer.Enabled = false;
			for(int index = 0; index < _map.shipArray.Length; index++)
			{
				switch (_map.shipArray[index].tile.MoveMovable())
				{
					case 0:
						_map.shipArray[index].tile.movable = null;
						_map.shipArray[index].tile = _map._firstTile;
						_map._firstTile.movable = _map.shipArray[index];
						if(index == 2)
						{
							_map.shipArray[index].Unload();
						}
						break;
				}
			}
			DrawMap();
			_shipTimer.Enabled = true;
			_shipMoving++;
			if (_shipMoving == _map._width)
			{
				_shipMoving = 0;
				_shipTimer.Enabled = false;
			}
		}

		public void AfterTimeTimer(Object sender, ElapsedEventArgs e)
		{
			_map.time--;
			if(_map.time == 0)
			{
				_map.time = _cartTimerInterval / 1000;
			}
			DrawMap();
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
			string header = _map.time.ToString();
			for(int index = 0; index < (_map._width - _map.time.ToString().Length - _map.score.ToString().Length); index++)
			{
				header = string.Concat(header, " ");
			}
			header = string.Concat(header, _map.score);
			Console.WriteLine(header);
			Console.WriteLine();
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
			Console.WriteLine("> Kies switch om aan te passen (A, S, D, X, C), q = stop");
		}
    }
}
