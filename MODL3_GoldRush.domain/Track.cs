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

		public override int AcceptMovable(Track inputTrack)
		{
			if (movable == null)
			{
				if (inputTrack.movable.direction.Equals(SwitchDirection(_outDirection)))
				{
					Direction temp = _inDirection;
					_inDirection = SwitchDirection(_outDirection);
					_outDirection = SwitchDirection(temp);
				}
				if (inputTrack.movable.direction.Equals(_inDirection))
				{
					Movable temp = inputTrack.movable;
					inputTrack.movable = null;
					temp.tile = this;
					movable = temp;
					movable.direction = _outDirection;
					return 1;
				}
				return 0;
			}
			return -1;
		}

		public override int MoveMovable()
		{
			Tile nextTile = null;
			switch (movable.direction)
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
				return nextTile.AcceptMovable(this);
			}
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

		public override void Switch()
		{
			throw new NotImplementedException();
		}

		public override char drawSymbol()
		{
			if(movable != null)
			{
				return movable.symbol;
			}
            return _symbol;
		}
	}
}