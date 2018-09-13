using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shooter
{
    static class Assets
    {
        public static Texture2D StandardTexture;
        public static Texture2D Player;

        public static void LoadContent(ContentManager content)
        {

        }

        public static void CreateStandartTexture(GraphicsDevice device)
        {
            int size = 10;
            Texture2D std = new Texture2D(device, size, size);
            Color[] data = new Color[size*size];
            for (int i = 0; i < size*size; i++)
            {
                data[i] = Color.White;
            }
            std.SetData(data);
            StandardTexture = std;
            Player = std;
        }
    }
}
