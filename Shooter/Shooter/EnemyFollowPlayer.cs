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

        public EnemyFollowPlayer(Vector2 pos, Player player):base(pos)
        {
            target = player;
            speed = 5;
            color = Color.Red;
            CollisionBox = new Rectangle(pos.ToPoint(), new Point(10, 10));
        }

        public override void Update()
        {
            Vector2 direction = target.Position - position;
            direction.Normalize();
            position += direction * speed;
            CollisionBox = new Rectangle(position.ToPoint(), new Point(10, 10));
        }

        public void Collision(BaseObject col)
        {
            if(col is BaseBullet)
            {
                Remove = true;
            }
        }
    }
}
