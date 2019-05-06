using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Shooter
{
    class Shotgun:BaseWeapon
    {
        int projectiles;
        public Shotgun():base(2)
        {
            currentAmmo = 2;
            rateOfFire = 0.5f;
            this.reloadTime = 1;
            this.shootingType = ShootingType.Semi_auto;
            projectiles = 8;
        }

        public override void Reload()
        {
            currentAmmo = MAX_AMMO;
        }

        public override void Shoot(TriggerState triggerState, Vector2 position, Vector2 direction)
        {
            if(triggerState == TriggerState.Pressing && currentAmmo>0)
            {
                for (int i = 0; i < projectiles; i++)
                {
                    float aimAngle = direction.GetAngle();

                    float spread = random.NextFloat(-0.4f,0.4f);
                    Vector2 newDirection = Utilities.FromPolar(aimAngle+spread);

                    BaseBullet bullet = new BaseBullet(position, newDirection, 2);
                    ObjectManager.AddObject(bullet);
                }
                currentAmmo--;
            }
        }
    }
}
