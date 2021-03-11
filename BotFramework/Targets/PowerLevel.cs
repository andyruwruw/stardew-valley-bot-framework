using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotFramework.Targets
{
    class PowerLevel
    {
        private int _power;

        private List<Vector2> _reach;

        public PowerLevel(int power, List<Vector2> reach)
        {
            this._power = power;
            this._reach = reach;
        }

        public int GetPowerLevel()
        {
            return this._power;
        }

        public List<Vector2> GetReach()
        {
            return this._reach;
        }
    }
}
