using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shooter
{
    class BaseBullet:BaseObject, ICollision
    {
        protected float speed =10;
        protected Vector2 direction;
        protected float damage;

        public Rectangle CollisionBox
        {
            get;
            set;
        }

        public float Damage { get { return damage; } }

        public BaseBullet(Vector2 pos, Vector2 dir, float dmg =1 )
        {
            position = pos;
            direction = dir;
            texture = Assets.StandardTexture;
            color = Color.Black;
            damage = dmg;
            CollisionBox = new Rectangle(pos.ToPoint(), size.ToPoint());
        }
        public override void Update()
        {
            position += direction * speed;
            if (position.X > 900 || position.X < -100 || position.Y < -100 | position.Y > 500)
                Remove = true;
            CollisionBox = new Rectangle(position.ToPoint(), new Point(10, 10));
        }

        public virtual void Collision(BaseObject col)
        {
            if(col is BaseEnemy)
            {
                Remove = true;
            }
        }
    }
}
