using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODL3_GoldRush.domain
{
    public class InSwitch : Switch
    {
        public InSwitch(Direction inDirection, Direction outDirection, char symbol) : base(inDirection, outDirection, symbol)
        {
            
        }

        public override void SwitchDirection()
        {
            switch (_inDirection)
            {
                case Direction.Left:
                    _inDirection = Direction.Right;
                    Console.WriteLine(_symbol);
                    break;
                case Direction.Right:
                    _inDirection = Direction.Left;
                    Console.WriteLine(_symbol);
                    break;
                case Direction.Up:
                    _inDirection = Direction.Down;
                    Console.WriteLine(_symbol);
                    break;
                case Direction.Down:
                    _inDirection = Direction.Up;
                    Console.WriteLine(_symbol);
                    break;
            }
        }
    }
}
