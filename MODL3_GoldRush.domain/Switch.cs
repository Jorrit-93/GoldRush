using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODL3_GoldRush.domain
{
    public abstract class Switch : Track
    {
        private char symbol { get; set; }

        public Switch(Direction inDirection, Direction outDirection, char symbol) : base(inDirection, outDirection, symbol)
        {
            this.symbol = symbol;
            this._inDirection = inDirection;
            this._outDirection = outDirection;
        }
    }
}
