using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Waves.Generator.instances
{
    public class Wave_003 : Assets.Waves.Generator.Base
    {
        public override double InternalFunction(double x)
        {
            return Math.Cos(x / 4);
        }
    }
}
