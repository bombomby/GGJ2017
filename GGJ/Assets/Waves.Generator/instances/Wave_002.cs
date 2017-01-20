using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Waves.Generator.instances
{
    public class Wave_002 : Assets.Waves.Generator.Base
    {
        public override float InternalFunction(float x)
        {
            return (float)(Math.Sin(6 * x) * Math.Sin(x / 8));
        }
    }
}
