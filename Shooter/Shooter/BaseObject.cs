using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shooter
{
    class BaseObject
    {
        protected Texture2D texture = Assets.StandardTexture;
        protected Vector2 position = new Vector2();
        protected Color color = Color.White;
        protected Vector2 collosionBox = new Vector2(10,10);

        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }
        public bool Remove
        {
            get;
            set;
        }

        public Rectangle CollisionBox
        {
            get { return new Rectangle(position.ToPoint(),collosionBox.ToPoint()); }
        }

        public virtual void Update()
        {

        }

        public void SetColliosionSize(Vector2 size)
        {
            collosionBox = size;
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture,position,color);
        }

        public virtual void OnCollision(BaseObject col)
        {

        }
    }
}
