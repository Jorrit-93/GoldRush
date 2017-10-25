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

		public override bool AcceptCart(Track prevTrack)
		{
			if (prevTrack._cart.cartDirection.Equals(SwitchDirection(_inDirection)) || prevTrack._cart.cartDirection.Equals(SwitchDirection(_outDirection)))
			{
				_inDirection = SwitchDirection(_inDirection);
				_outDirection = SwitchDirection(_inDirection);
			}
			if (prevTrack._cart.cartDirection.Equals(_inDirection) && _cart == null)
			{
				Cart temp = prevTrack._cart;
				prevTrack._cart = null;
				temp.tile = this;
				_cart = temp;
				_cart.cartDirection = _outDirection;
				return true;
			}
			return false;
		}

		public override bool MoveCart()
		{
			switch (_cart.cartDirection)
			{
				case Direction.Left:
					return leftTile.AcceptCart(this);
				case Direction.Right:
					return rightTile.AcceptCart(this);
				case Direction.Up:
					return upTile.AcceptCart(this);
				case Direction.Down:
					return downTile.AcceptCart(this);
//				case Direction.Null:
//					return true;
			}
			return false;
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