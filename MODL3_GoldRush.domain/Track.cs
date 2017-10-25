using System;

namespace MODL3_GoldRush.domain
{
	public class Track : Tile
	{
		protected Cart _cart = new Cart();
		protected Direction _inDirection;
		protected Direction _outDirection;

		public Track(Direction inDirection, Direction outDirection, char symbol) : base(symbol)
		{
			_inDirection = inDirection;
			_outDirection = outDirection;
		}

		public override bool AcceptCart(Track prevTrack)
		{
			if (prevTrack._outDirection.Equals(_outDirection))
			{
				Direction temp = _inDirection;
				_inDirection = _outDirection;
				_outDirection = temp;
			}
			if (prevTrack._outDirection.Equals(_inDirection) && _cart == null)
			{
				return true;
			}
			return false;
		}

		public override bool MoveCart()
		{
			switch (_outDirection)
			{
				case Direction.Left:
					return rightTile.AcceptCart(this);
				case Direction.Right:
					return leftTile.AcceptCart(this);
				case Direction.Up:
					return downTile.AcceptCart(this);
				case Direction.Down:
					return upTile.AcceptCart(this);
			}
			return false;
		}

		public override void SwitchDirection(Direction d)
		{
			switch (d)
			{
				case Direction.Left:
					d = Direction.Right;
					break;
				case Direction.Right:
					d = Direction.Left;
					break;
				case Direction.Up:
					d = Direction.Down;
					break;
				case Direction.Down:
					d = Direction.Up;
					break;
			}
		}

		public new char drawSymbol()
		{
			if(_cart != null)
			{
				return _cart.symbol;
			}
			return base.drawSymbol();
		}
	}
}