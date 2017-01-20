using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Waves.Generator.instances
{
    public class Wave_001 : Assets.Waves.Generator.Base
    {
        public override double InternalFunction(double x)
        {
            return -1.0*Math.Sin(8 * x) * Math.Sin(x - 1);
        }
    }
}
