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
        private Timer timer;
        private bool isRunning;

        public Controller()
		{
			_inView = new InputView();
			_outView = new OutputView();
			LoadMap(); //temp
            timer = new Timer(10000);

            timer.Elapsed += new ElapsedEventHandler(AfterTimer);
            timer.Enabled = true;
            timer.AutoReset = true;
            DuringTimer();
        }

		public void LoadMap()
		{
			string[] mapLines;
			int nr = 0; //temp
			mapLines = File.ReadAllLines(@Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + "\\Level" + nr + ".txt");
			_map = new Map(mapLines.Length, mapLines[0].Length);
			_map.CreateMap(mapLines);
			DrawMap();
			Console.Read();
		}

		public void DrawMap()
		{
			//Console.Clear();
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

        public void DuringTimer()
        {
            timer.Start();
            isRunning = true;
            while (isRunning)
            {
                //swtiches aanpassen
            }
        }

        public void AfterTimer(Object sender, ElapsedEventArgs e)
        {
            Console.WriteLine("Alles wat er na timer moet gebeuren, zoals move cart/unload cart etc");
        }

    }
}
