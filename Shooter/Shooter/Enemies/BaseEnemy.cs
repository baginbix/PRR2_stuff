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
        protected float hp;

        public float HP
        {
            get { return hp; }
        }

        public BaseEnemy(Vector2 pos)
        {
            position = pos;
            hp = 1;
            
        }

        public virtual void DealDamage(float damage)
        {
            hp -= damage;
            Remove = hp <= 0;
        }

    }
}
