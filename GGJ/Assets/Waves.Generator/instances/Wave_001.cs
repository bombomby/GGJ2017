using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Waves.Generator.instances
{
    public class Wave_001 : Assets.Waves.Generator.Base
    {
        public override float InternalFunction(float x)
        {
            return (float) (-1.0*Math.Sin(8.0f * x) * Math.Sin(x - 1.0));
        }
    }
}
