using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Shooter
{
    class Player: BaseObject, ICollision
    {
        float speed = 5f;
        Vector2 velocity = Vector2.Zero;
        KeyboardState keybord;
        float shootTime = 60;
        float timer = 60;

        public Rectangle CollisionBox { get; set; }

        public Player()
        {
            position = new Vector2(100,200);
            texture = Assets.Player;
        }

        public override void Update()
        {
            keybord = Keyboard.GetState();
            velocity = Vector2.Zero;
            Movement();
            if(Mouse.GetState().LeftButton == ButtonState.Pressed && timer >=shootTime)
            {
                Shoot();
                timer = 0;
            }
            timer++;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }

        private void Movement()
        {
            if (keybord.IsKeyDown(Keys.W))
            {
                velocity.Y -= 1;
            }
            if (keybord.IsKeyDown(Keys.S))
            {
                velocity.Y += 1;
            }
            if (keybord.IsKeyDown(Keys.D))
            {
                velocity.X += 1;
            }
            if (keybord.IsKeyDown(Keys.A))
            {
                velocity.X -= 1;
            }
            if(velocity != Vector2.Zero)
                velocity.Normalize();
            position += velocity *speed;
            CollisionBox = new Rectangle(position.ToPoint(), new Point(10, 10));
        }

        private void Shoot()
        {
            Vector2 direction = Mouse.GetState().Position.ToVector2() - position;
            direction.Normalize();
            ObjectManager.AddObject(new BaseBullet(position, direction));
        }

        public void Collision(BaseObject col)
        {

        }

    }
}
