﻿using System;
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
        enum PlayerState
        {
            Normal,
            Dashing
        }
        float speed = 10f;
        Vector2 velocity = Vector2.Zero;
        KeyboardState keybord;
        float reloadTimer = 60;

        float dashDistance = 100f;
        float dashTime = 1f;

        BaseWeapon weapon;
        BaseWeapon[] weaponList = new BaseWeapon[5];
        TriggerState weaponState = TriggerState.Released;
        TriggerState prevWeaponState = TriggerState.Released;
        bool reloading = false;

        SpriteFont uiFont;
        delegate void PlayerAction();
        PlayerAction action = null;
        PlayerState playerState = PlayerState.Normal;
       

        public Rectangle CollisionBox { get; set; }

        public Player()
        {
            position = new Vector2(100,200);
            texture = Assets.Player;
            weaponList[0] = new Pistol();
            weaponList[1] = new Uzi();
            weaponList[2] = new Shotgun();
            weaponList[3] = new Sniper();
            weaponList[4] = new RocketLauncher();
            uiFont = Assets.UIFont;
            weapon = weaponList[0];
        }

        public override void Update()
        {
            keybord = Keyboard.GetState();
            Movement();
            WeaponActions();

            if (reloading)
                Reloading();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            DrawAmmo(spriteBatch);
        }

        private void Movement()
        {
            if (action == null)
            {
                velocity = Vector2.Zero;
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
                if (velocity != Vector2.Zero)
                    velocity.Normalize();
            }
            else
            {
                action.Invoke();
            }
            position += velocity *speed;
            if (keybord.IsKeyDown(Keys.Space))
                Dash();
            CollisionBox = new Rectangle(position.ToPoint(), new Point(10, 10));
            ObjectManager.PlayerPosition = position;
        }

        public void Collision(BaseObject col)
        {
            if(col is BaseEnemy)
            {
                Remove = true;
            }

        }

        private void Reloading()
        {
            if (reloadTimer >= weapon.ReloadTime)
            {
                weapon.Reload();
                reloading = false;
            }

            reloadTimer += (float)Game1.GameTime.ElapsedGameTime.TotalSeconds;
        }

        private void WeaponActions()
        {
            weaponState = TriggerState.Released;
            if (Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                weaponState = (prevWeaponState == TriggerState.Pressing || prevWeaponState == TriggerState.Holding) ? TriggerState.Holding : TriggerState.Pressing;
                Vector2 direction = Vector2.Zero;

                direction = Mouse.GetState().Position.ToVector2() - position;
                direction.Normalize();

                weapon.Shoot(weaponState, position, direction);
            }

            if (keybord.IsKeyDown(Keys.R))
            {
                reloadTimer = 0;
                reloading = true;
            }

            SwitchWeapon();
            prevWeaponState = weaponState;
            weapon.Update();
        }

        private void SwitchWeapon()
        {
            if (!reloading)
            {
                if (keybord.IsKeyDown(Keys.D1))
                    weapon = weaponList[0];
                else if (keybord.IsKeyDown(Keys.D2))
                    weapon = weaponList[1];
                else if (keybord.IsKeyDown(Keys.D3))
                    weapon = weaponList[2];
                else if (keybord.IsKeyDown(Keys.D4))
                    weapon = weaponList[4];
                else if (keybord.IsKeyDown(Keys.D5))
                    weapon = weaponList[3];
            }

        }

        private void DrawAmmo(SpriteBatch spriteBatch)
        {

            Vector2 pos = position;
            pos.Y -= 20;
            string text = "";
            if (!reloading)
                text = weapon.CurrentAmmo + "/" + weapon.MAX_AMMO;
            else
                text = "REALODING";
            Vector2 fontSize = uiFont.MeasureString(text);
            pos.X -= fontSize.X / 2.5f;
            spriteBatch.DrawString(uiFont, text, pos, Color.White);
        }

        private void Dash()
        {
            if (playerState == PlayerState.Dashing)
            {
                float damp = 0.01f;
                velocity *= damp;
                if (velocity.Length() < 8)
                {
                    action = null;
                    playerState = PlayerState.Normal;
                }
            }
            else
            {
                velocity *= 30f;
                playerState = PlayerState.Dashing;
                action = Dash;
            }
        }
    }
}
