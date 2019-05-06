using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shooter
{
    class Rocket:BaseBullet
    {
        float explosionRange = 100;
        public Rocket(Vector2 position, Vector2 direction, float damage = 4):base(position,direction,damage)
        {
            speed = 6;
        }
        

        public override void Collision(BaseObject col)
        {
            if(col is BaseEnemy)
            {
                BaseEnemy[] enemies = ObjectManager.FindObjectsInRange<BaseEnemy>(position, explosionRange);
                foreach (var item in enemies)
                {
                    item.DealDamage(Damage);
                    Remove = true;
                }
            }
        }
    }
}
