using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Shooter
{
    class Sniper : BaseWeapon
    {

        public Sniper() : base(4)
        {
            this.currentAmmo = 4;
            this.fireCooldown = 0;
            this.reloadTime = 3;
            this.rateOfFire = 2f;
            this.shootingType = ShootingType.Semi_auto;
        }
        public override void Reload()
        {
            currentAmmo = MAX_AMMO;
        }

        public override void Shoot(TriggerState state, Vector2 position, Vector2 direction)
        {
            if(state == TriggerState.Pressing && currentAmmo > 0)
            {
                direction = CreateSpread(direction, 0.01f);

                ObjectManager.AddObject(new SniperBullet(position, direction, 5));
                currentAmmo--;
            }
        }
    }
}
