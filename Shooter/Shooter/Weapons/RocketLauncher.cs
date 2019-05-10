using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Shooter
{
    class RocketLauncher : BaseWeapon
    {
        public RocketLauncher() : base(1)
        {
            this.currentAmmo = MAX_AMMO;
            this.rateOfFire = 2;
            this.reloadTime = 2;
            this.shootingType = ShootingType.Semi_auto;
        }

        public override void Shoot(TriggerState state, Vector2 position, Vector2 direction)
        {
            if(state != TriggerState.Released && currentAmmo>0)
            {
                ObjectManager.AddObject(new Rocket(position, direction));
                currentAmmo--;
            }
        }
    }
}
