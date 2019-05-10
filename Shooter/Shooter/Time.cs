using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shooter
{
    static class Time
    {
        /// <summary>
        /// 2 means the time is doubled, 0.5 means the time is halved
        /// </summary>
        public static float TimeScale { get; set; }
        /// <summary>
        /// Scaled time since last frame
        /// Can be used for cool slow motion effects
        /// </summary>
        public static float ScaledTime {
            get
            {
                return UnscaledTime * TimeScale;
            }
        }

        /// <summary>
        /// The actual time since last frame
        /// </summary>
        public static float UnscaledTime { get; private set; }

        public static void SetTime(GameTime gameTime)
        {
            UnscaledTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
        }


        
    }
}
