﻿using System;
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

		public List<Cart> cartList;
		public List<Tile> hangarList;
//		public List<Tile> switchList;

		public Tile _firstTile;
		public int _height;
		public int _width;

		public Map(int height, int width)
		{
			_height = height;
			_width = width;
			cartList = new List<Cart>();
			hangarList = new List<Tile>();
//			switchList = new List<Tile>();
		}

		public void CreateCart(int hangarIndex)
		{
			Cart newCart = new Cart();
			hangarList[hangarIndex]._cart = newCart;
			hangarList[hangarIndex].MoveCart();
			cartList.Add(newCart);
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
					newTile = new Track(Direction.Right, Direction.Left, symbol);
					return newTile;
				case 'A':
					newTile = new Hangar(Direction.Right, Direction.Left, symbol);
					hangarList.Add(newTile);
					return newTile;
				default:
					newTile = new SpaceTile(symbol);
					return newTile;
			}
		}
	}
}
