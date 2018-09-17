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
            Collision();
            RemoveObjects();
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

        public static T FindObject<T>() where T: BaseObject
        {

            return objects.First(x => x is T) as T;
        }
        private static void Collision()
        {
            for (int i = 0; i < objects.Count; i++)
            {
                BaseObject target = objects[i];
                
                for (int j = i+1; j < objects.Count; j++)
                {
                    BaseObject target2 = objects[j];
                    if (target2.Remove) continue;
                    if (target.CollisionBox.Intersects(target2.CollisionBox))
                    {
                        target.OnCollision(target2);
                        target2.OnCollision(target);
                    }
                }
            }
        }

        private static void RemoveObjects()
        {
            var temp = new List<BaseObject>();
            foreach (var item in objects)
            {
                if (!item.Remove)
                    temp.Add(item);
            }
            objects = temp;
        }
    }
}
