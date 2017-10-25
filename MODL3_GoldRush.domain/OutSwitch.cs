using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODL3_GoldRush.domain
{
    public class OutSwitch : Switch
    {
        public OutSwitch(Direction inDirection, Direction outDirection, char symbol) : base(inDirection, outDirection, symbol)
        {

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
    }
}
