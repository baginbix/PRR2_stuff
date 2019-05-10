using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shooter
{
    class Pistol : BaseWeapon
    {
        public Pistol():base(10)
        {
            currentAmmo = MAX_AMMO;
            reloadTime = 0.7f;
            shootingType = ShootingType.Semi_auto;
        }

        public override void Shoot(TriggerState state, Vector2 position, Vector2 direction)
        {

            if (state == TriggerState.Pressing)
            {
                if( currentAmmo>0)
                {
                    float angle = (float)Math.Atan2(direction.Y, direction.X);
                    float spread = random.NextFloat(-0.04f, 0.04f);
                    
                    ObjectManager.AddObject(new BaseBullet(position,new Vector2((float)Math.Cos(angle+spread),(float)Math.Sin(angle+spread))));
                    currentAmmo--;
                }
            }
        }
    }
}
