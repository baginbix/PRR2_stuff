using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shooter
{
    class BaseBullet:BaseObject
    {
        protected float speed =10;
        protected Vector2 direction;

        public BaseBullet(Vector2 pos, Vector2 dir)
        {
            position = pos;
            direction = dir;
            texture = Assets.StandardTexture;
            color = Color.Black;
        }
        public override void Update()
        {
            position += direction * speed;
        }
    }
}
