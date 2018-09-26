using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shooter
{
    //En klass som tar hand om alla våra objeket
    static class ObjectManager
    {
        //Listan håller ALLA våra objekt som vi lägger till
        private static List<BaseObject> objects = new List<BaseObject>();

        //Listan håller bara dom objekt som kan kollidera.
        //Vill vi inte att ett objekt ska kollidera, ska den inte ha ICollision
        private static List<ICollision> collidableObjects = new List<ICollision>();
        
        //Uppdateras objekten eller inte
        static bool updating = false;

        //Objekt som kommer till medans spelet uppdateras.
        private static List<BaseObject> objectsToBeAdded = new List<BaseObject>();

        public static void Update()
        {
            //Vi säger att spelet uppdateras
            updating = true;

            //Uppdatera varje objekt
            foreach (var item in objects)
            {
                item.Update();
            }
            //Säger att vi hasr slutat uppdatera
            updating = false;
            //Lägg till alla objekt som kom till medans spelet uppdaterades.
            foreach (var item in objectsToBeAdded)
            {
                AddObject(item);
            }

            //Kolla kollision på objekten
            Collision();

            //Ta bort objekt som ska tas bort
            RemoveObjects();

            //Alla objekt som tillkom under uppdateringen har lagts till,
            //vi kan nu rensa listan
            objectsToBeAdded.Clear();
        }

        public static void Draw(SpriteBatch spriteBatch)
        {
            foreach (var item in objects)
            {
                item.Draw( spriteBatch);
            }
        }

        //Lägg till objekt till vårt spel
        public static void AddObject(BaseObject obj)
        {
            //Om spelet inte uppdateras kan vi lägga till det direkt,
            //annars måste det läggas i en väntlista.
            //Det är för att undvika krashar och buggar.
            if (!updating)
            {
                //Vi lägger till det och kollar om objektet kan kollidera.
                //Isåfall läggs det till i kollisions listan
                objects.Add(obj);
                if (obj is ICollision)
                    collidableObjects.Add(obj as ICollision);
            }
            else
                objectsToBeAdded.Add(obj);
        }

        public static T FindObject<T>() where T: BaseObject
        {
            //Letar efter upp ett objekt och retunerar det
            return objects.First(x => x is T) as T;
        }

        //Kollar vilka objekt som kolliderar.
        //Om dom kolliderar säger vi till objekten vilket objekt dom kolliderar med
        private static void Collision()
        {
            for (int i = 0; i < collidableObjects.Count; i++)
            {
                ICollision colObj1 = collidableObjects[i];
                for (int j = i+1; j < collidableObjects.Count; j++)
                {
                    ICollision colObj2 = collidableObjects[j];
                    if(colObj1.CollisionBox.Intersects(colObj2.CollisionBox))
                    {
                        colObj1.Collision(colObj2 as BaseObject);
                        colObj2.Collision(colObj1 as BaseObject);
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
                {
                    temp.Add(item);
                }
                else
                    collidableObjects.Remove(item as ICollision);

            }
            objects = temp;
        }
    }
}
