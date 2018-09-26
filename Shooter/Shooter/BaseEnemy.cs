using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Shooter
{
    class BaseEnemy:BaseObject
    {
        protected float speed;

        public BaseEnemy(Vector2 pos)
        {
            position = pos;
            
        }

    }
}
