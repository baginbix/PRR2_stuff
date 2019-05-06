using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shooter
{
    class EnemyFollowPlayer:BaseEnemy,ICollision
    {
        Player target;

        public Rectangle CollisionBox { get; set; }

        public EnemyFollowPlayer(Vector2 pos):base(pos)
        {
            target = ObjectManager.FindObject<Player>();
            speed = 2;
            color = Color.Red;
            CollisionBox = new Rectangle(pos.ToPoint(), new Point(10, 10));
            hp = 2;
        }

        public override void Update()
        {
            if (target != null)
            {
                Vector2 direction = target.Position - position;
                direction.Normalize();
                position += direction * speed;
                CollisionBox = new Rectangle(position.ToPoint(), new Point(10, 10));
            }
        }

        public void Collision(BaseObject col)
        {
            if(col is BaseBullet)
            {
                Remove = (hp -=(col as BaseBullet).Damage) <= 0;
                ObjectManager.AddParticleSystem(new ParticleSystem(position));
            }
        }
    }
}
