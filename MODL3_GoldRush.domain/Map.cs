using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODL3_GoldRush.domain
{
	public class Map
	{
		public List<Cart> cartList;
		public List<Tile> hangarList;
		public List<Tile> switchList;
		public Ship[] shipArray;
		private int shipIndex;

		public Tile _firstTile;
		public int _height;
		public int _width;

		public int score { get; set; }
		public int time { get; set; }
		public int shipLoad { get; set; }

		public Map(int height, int width)
		{
			_height = height;
			_width = width;
			cartList = new List<Cart>();
			hangarList = new List<Tile>();
			switchList = new List<Tile>();
			shipArray = new Ship[5];
			shipIndex = 4;
			shipLoad = 0;
	}

		public void CreateCart(int hangarIndex)
		{
			Cart newCart = new Cart();
			newCart.tile = hangarList[hangarIndex];
			hangarList[hangarIndex].movable = newCart;
			cartList.Add(newCart);
		}

		public void CreateShip(char symbol, Tile newTile)
		{
			Ship newShip = new Ship(symbol);
			newShip.tile = newTile;
			newTile.movable = newShip;
			shipArray[shipIndex--] = newShip;
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
				case '~':
				case '─':
					newTile = new Track(Direction.Right, Direction.Right, symbol);
					return newTile;
				case '│':
					newTile = new Track(Direction.Up, Direction.Up, symbol);
					return newTile;
				case '┌':
					newTile = new Track(Direction.Up, Direction.Right, symbol);
					return newTile;
				case '└':
					newTile = new Track(Direction.Down, Direction.Right, symbol);
					return newTile;
				case '┘':
					newTile = new Track(Direction.Right, Direction.Up, symbol);
					return newTile;
				case '┐':
					newTile = new Track(Direction.Right, Direction.Down, symbol);
					return newTile;
				case 'K':
					newTile = new Quay(Direction.Right, Direction.Right, symbol);
					return newTile;
				case '═':
					newTile = new Holding(Direction.Right, Direction.Right, symbol);
					return newTile;
				case '╔':
					newTile = new InSwitch(Direction.Up, Direction.Right, symbol);
					switchList.Add(newTile);
					return newTile;
				case '╚':
                    newTile = new InSwitch(Direction.Down, Direction.Right, symbol);
                    switchList.Add(newTile);
                    return newTile;
                case '╝':
                    newTile = new OutSwitch(Direction.Right, Direction.Up, symbol);
					switchList.Add(newTile);
                    return newTile;
                case '╗':
                    newTile = new OutSwitch(Direction.Right, Direction.Down, symbol);
					switchList.Add(newTile);
					return newTile;
                case '<':
                case '(':
                case '░':
                case ')':
                case '>':
					newTile = new Track(Direction.Right, Direction.Right, '~');
					CreateShip(symbol, newTile);
                    return newTile;
				case 'A':
				case 'B':
				case 'C':
					newTile = new Hangar(Direction.Null, Direction.Right, symbol);
					hangarList.Add(newTile);
					return newTile;
				default:
					newTile = new SymbolTile(symbol);
					return newTile;
			}
		}
	}
}
