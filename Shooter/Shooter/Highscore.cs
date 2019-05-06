using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shooter
{
    static class Highscore
    {
        public static List<int> Highscores
        {
            get;
            set;
        }

        public static void LoadHighscores()
        {
            Highscores = new List<int>();
            Highscores.Add(123);
            Highscores.Add(1654);
            Highscores.Add(1234);
            Highscores.Add(133);
        }

        public static void SaveHighscores()
        {
            StreamWriter sw = new StreamWriter("Highscore.txt");

            foreach (int item in Highscores)
            {
                sw.WriteLine(item);
            }
            sw.Close();
        }
    }
}
