using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Shooter
{
    class Uzi : BaseWeapon
    {
        public Uzi() : base(20)
        {
            currentAmmo = MAX_AMMO;
            reloadTime = 0.8f;
            rateOfFire = 0.2f;
            this.shootingType = ShootingType.Full_auto;
        }
        public override void Reload()
        {
            currentAmmo = MAX_AMMO;
        }

        public override void Shoot(TriggerState state, Vector2 position, Vector2 direction)
        {
            if(state != TriggerState.Released && currentAmmo>0 && fireCooldown>=rateOfFire)
            {
                while (fireCooldown >= rateOfFire)
                {
                    fireCooldown -= rateOfFire;
                }
                direction = CreateSpread(direction, 0.1f);
                ObjectManager.AddObject(new BaseBullet(position, direction));
                currentAmmo--;
            }

        }

        public override void Update()
        {
            fireCooldown += (float)Game1.GameTime.ElapsedGameTime.TotalSeconds;
        }
    }
}
