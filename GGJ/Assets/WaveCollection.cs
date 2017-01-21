﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets
{
    public class WaveCollection
    {
        public float WaveFunction_001(float x)
        {
            return (float)(-System.Math.Cos(3 * x * System.Math.PI) * System.Math.Sin(x * System.Math.PI));
        }

        public float WaveFunction_002(float x)
        {
            return (float)(System.Math.Sin(System.Math.PI * x * 10) * System.Math.Sin(x * System.Math.PI) * System.Math.Sin(System.Math.PI * (x - 1.0)));
        }

        public float WaveFunction_003(float x)
        {
            return (float)(System.Math.Sin(x * System.Math.PI) / 7);
        }

        public float WaveFunction_004(float x)
        {
            return (float)(System.Math.Cos(2 * System.Math.PI * x));
        }


        public ICollection<Func<float, float>> Waves;
        public WaveCollection ()
        {
            Waves = new List<Func<float, float>>();

            Waves.Add(WaveFunction_001);
            Waves.Add(WaveFunction_002);
            Waves.Add(WaveFunction_003);
            Waves.Add(WaveFunction_004);
        }
    }
}
