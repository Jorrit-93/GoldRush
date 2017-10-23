namespace MODL3_GoldRush.domain
{
	public class Track : Tile
	{
		public Track(char symbol) : base(symbol)
		{
		}

		public bool AcceptCart()
		{
			return true;
		}
	}
}