using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace MarioDebono.Attributes
{
    public class MinMaxAttribute : PropertyAttribute
    {
        public float MinLimit = 0;
        public float MaxLimit = 1;

        public MinMaxAttribute(int min, int max)
        {
            MinLimit = min;
            MaxLimit = max;
        }
    }

}
