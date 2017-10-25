using System;

namespace MODL3_GoldRush.domain
{
	public class Track : Tile
	{
		protected Direction _inDirection;
		protected Direction _outDirection;

		public Track(Direction inDirection, Direction outDirection, char symbol) : base(symbol)
		{
			_inDirection = inDirection;
			_outDirection = outDirection;
		}

		public override int AcceptCart(Track prevTrack)
		{
			if (_cart == null)
			{
				if (prevTrack._cart.cartDirection.Equals(SwitchDirection(_outDirection)))
				{
					Direction temp = _inDirection;
					_inDirection = SwitchDirection(_outDirection);
					_outDirection = SwitchDirection(temp);
				}
				if (prevTrack._cart.cartDirection.Equals(_inDirection))
				{
					Cart temp = prevTrack._cart;
					prevTrack._cart = null;
					temp.tile = this;
					_cart = temp;
					_cart.cartDirection = _outDirection;
					return 1;
				}
				return 0;
			}
			return -1;
		}

		public override int MoveCart()
		{
			Tile nextTile = null;
			switch (_cart.cartDirection)
			{
				case Direction.Left:
					nextTile = leftTile;
					break;
				case Direction.Right:
					nextTile = rightTile;
					break;
				case Direction.Up:
					nextTile = upTile;
					break;
				case Direction.Down:
					nextTile = downTile;
					break;
			}
			if(nextTile != null)
			{
				return nextTile.AcceptCart(this);
			}
			_cart = null;
			return 0;
		}

		public override Direction SwitchDirection(Direction d)
		{
			switch (d)
			{
				case Direction.Left:
					return Direction.Right;
				case Direction.Right:
					return Direction.Left;
				case Direction.Up:
					return Direction.Down;
				case Direction.Down:
					return Direction.Up;
			}
			return Direction.Null;
		}

		public override char drawSymbol()
		{
			if(_cart != null)
			{
				return _cart.symbol;
			}
			return _symbol;
		}
	}
}