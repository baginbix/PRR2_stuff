using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shooter
{
    class EnemyFollowPlayer:BaseEnemy
    {
        Player target;
        public EnemyFollowPlayer(Vector2 pos, Player player):base(pos)
        {
            target = player;
            speed = 5;
            color = Color.Red;
        }

        public override void Update()
        {
            Vector2 direction = target.Position - position;
            direction.Normalize();
            position += direction * speed;
        }

        public override void OnCollision(BaseObject col)
        {
            if(col is BaseBullet)
            {
                Remove = true;
            }
        }
    }
}
