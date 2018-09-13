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

        public virtual void Update()
        {

        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture,position,color);
        }
    }
}
