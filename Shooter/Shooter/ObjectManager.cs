using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shooter
{
    static class ObjectManager
    {
        private static List<BaseObject> objects = new List<BaseObject>();
        static bool updating = false;
        private static List<BaseObject> objectsToBeAdded = new List<BaseObject>();
        public static void Update()
        {
            updating = true;
            foreach (var item in objects)
            {
                item.Update();
            }
            updating = false;
            foreach (var item in objectsToBeAdded)
            {
                objects.Add(item);
            }
            objectsToBeAdded.Clear();
        }

        public static void Draw(SpriteBatch spriteBatch)
        {
            foreach (var item in objects)
            {
                item.Draw( spriteBatch);
            }
        }

        public static void AddObject(BaseObject obj)
        {
            if (!updating)
                objects.Add(obj);
            else
                objectsToBeAdded.Add(obj);
        }
    }
}
