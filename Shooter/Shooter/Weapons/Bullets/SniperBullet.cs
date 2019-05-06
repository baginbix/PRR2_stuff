using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Shooter
{
    class SniperBullet : BaseBullet
    {
        float hp;
        public SniperBullet(Vector2 pos, Vector2 dir, float dmg) : base(pos, dir, 0)
        {
            hp = dmg;
        }

        public override void Collision(BaseObject col)
        {
            if (col is BaseEnemy)
            {
                BaseEnemy enemy = col as BaseEnemy;
                float remainingHP = hp - enemy.HP;
                enemy.DealDamage(hp);
                hp = remainingHP;
            }
            if(hp<=0)
            {
                Remove = true;
            }
        }
    }
}
