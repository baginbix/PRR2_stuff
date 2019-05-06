using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shooter
{
    abstract class BaseWeapon
    {
        protected enum ShootingType
        {
            Semi_auto,
            Full_auto
        }
        protected ShootingType shootingType;
        protected float rateOfFire =0;
        protected float fireCooldown =0;
        protected float reloadTime = 1;
        public readonly int MAX_AMMO;
        protected int currentAmmo;
        protected static Random random = new Random();

        public BaseWeapon(int maxAmmo)
        {
            MAX_AMMO = maxAmmo;
        }
        public float ReloadTime
        {
            get { return reloadTime; }
        }
        public int CurrentAmmo
        {
            get { return currentAmmo; }
        }
        
        public abstract void Shoot(TriggerState state, Vector2 position, Vector2 direction);

        public abstract void Reload();

        public virtual void Update()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="direction"></param>
        /// <param name="amount">A value between 0 and PI</param>
        /// <returns></returns>
        protected static Vector2 CreateSpread(Vector2 direction, float amount)
        {
            float angle = (float)Math.Atan2(direction.Y, direction.X);
            float spread = random.NextFloat(-amount, amount);

            return new Vector2((float)Math.Cos(spread + angle), (float)Math.Sin(spread + angle)); ;
        }

    }
}
