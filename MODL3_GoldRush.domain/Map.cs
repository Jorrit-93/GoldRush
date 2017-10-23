using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODL3_GoldRush.domain
{
	public class Map
	{
		private int _score;
		private int _time;
		public Tile _firstTile;

		public int _height;
		public int _width;

		public Map(int height, int width)
		{
			this._height = height;
			this._width = width;
		}

		public void CreateMap(string[] mapLines)
		{
			Tile lastTile = null;
			Tile firstRowTile = null;
			Tile secondRowTile = null;
			bool firstTile = false;
			foreach(string mapline in mapLines)
			{
				firstTile = true;
				foreach(char symbol in mapline)
				{
					Tile newTile = CreateTile(symbol);
					if (!firstTile)
					{
						lastTile.rightTile = newTile;
						newTile.leftTile = lastTile;
					}
					else
					{
						if (_firstTile == null)
						{
							_firstTile = newTile;
							firstRowTile = newTile;
						}
						else
						{
							secondRowTile = newTile;
						}
						firstTile = false;
					}
					lastTile = newTile;
				}
				if(secondRowTile != null)
				{
					Tile tempTile = secondRowTile;
					for (int index = 0; index < _width; index++)
					{
						firstRowTile.downTile = secondRowTile;
						secondRowTile.upTile = firstRowTile;
						firstRowTile = firstRowTile.rightTile;
						secondRowTile = secondRowTile.rightTile;
					}
					firstRowTile = tempTile;
				}
			}
		}

		public Tile CreateTile(char symbol)
		{
			Tile newTile;
			switch (symbol)
			{
				case '─':
					newTile = new Track(symbol);
					newTile.AcceptCart()
					return newTile;
				default:
					newTile = new SpaceTile(symbol);
					return newTile;
			}
		}
	}
}
