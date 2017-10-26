using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODL3_GoldRush.domain
{
    public class Ship
    {
        public List<Tile> _tiles;
        public int load { get; set; }
        public Direction shipDirection { get; set; }

        public Ship()
        {
            _tiles = new List<Tile>();
            load = 0;
            shipDirection = Direction.Right;
        }

        public void LeaveQuay()
        {
            
        }

        public void AddTile(Tile tile)
        {
            _tiles.Add(tile);
        }
    }
}
