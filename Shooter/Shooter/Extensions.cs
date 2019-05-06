using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shooter
{
    static class Extensions
    {
        public static float NextFloat(this Random rand, float minValue, float maxValue)
        {
            return (float)rand.NextDouble() * (maxValue - minValue) + minValue;
        }

        public static float GetAngle(this Vector2 direction)
        {
            return (float)Math.Atan2(direction.Y, direction.X);
        }
    }
}
