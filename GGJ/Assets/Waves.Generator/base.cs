using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

namespace Assets.Waves.Generator
{
    public class Base {

        public Base() {
        }
        
        public float Function(float input)
        {
            return InternalFunction(input);
        }

        virtual public float InternalFunction(float x) { return x; }
    }

}

