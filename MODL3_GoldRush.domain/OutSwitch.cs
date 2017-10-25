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

        public override void SwitchDirection()
        {
            switch (_outDirection)
            {
                case Direction.Left:
                    _outDirection = Direction.Right;
                    break;
                case Direction.Right:
                    _outDirection = Direction.Left;
                    break;
                case Direction.Up:
                    _outDirection = Direction.Down;
                    break;
                case Direction.Down:
                    _outDirection = Direction.Up;
                    break;
            }
        }
    }
}
