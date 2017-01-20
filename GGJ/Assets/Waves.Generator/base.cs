using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

namespace Assets.Waves.Generator
{
    public class Base {

        public Base() {
        }
        
        public double Function(double input)
        {
            return InternalFunction(input);
        }

        virtual public double InternalFunction(double x) { return x; }
    }

}

