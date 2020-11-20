using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
    

namespace mp4_sous_titre
{
    class soustitre
    {
        //les soutitre y sont contenue, le nombre du soutitre est position+1
        private List<string> subtitle = new List<string>();
        //Les temps de début y sont contenue p+1
        private List<string> TimeBegin = new List<string>();
        //Les temps de fin y sont contenue p+1
        private List<string> TimeEnd = new List<string>();
        //C'est la position actuelle, le sous-titre affiché.
        public int position = 0;
        public void SubTitle(string route)
        {
            //constructeur, pour fonctionner il est impératif d'avoir un fichier de sous-titre traité.
            using (StreamReader reader = new StreamReader(route))
            {
                string line;
                bool teste;
                int essaie = 0;
                while ((line = reader.ReadLine()) != null)
                {

                    if (line.Length < 3)
                    {
                        //passer à la suivant
                        essaie = 1;
                        continue;
                    }
                    else if (teste = line.Contains("-->") && essaie == 1)
                    {
                        string[] destroye;
                        line.Remove('-');
                        line.Remove('>');
                        destroye = line.Split(' ');
                        TimeBegin.Add(destroye[0]);
                        TimeEnd.Add(destroye[1]);
                        essaie = 2;
                    }
                    else
                    {
                        if (essaie == 2)
                        {
                            subtitle.Add(line);
                            essaie = 3;
                        }
                        else
                        {
                            subtitle.Add(subtitle[line.Length - 1] + "\n" + line);
                            essaie = 0;
                        }
                    }
                }
                afficher();
            }
            
        }
        public void afficher()
        {
            //récupérer le bon soustitre
            int i = 0;
            int placement = (Console.WindowHeight - subtitle[position].Length) / 2;
            while (i == 0)
            {
                if (TimeBegin[position] == Interface.clock())
                {
                    //écrire en blanc
                    Console.ForegroundColor = ConsoleColor.White;
                    //fond noir
                    Console.BackgroundColor = ConsoleColor.Black;
                    //Position du texte au millieu de l'écran, en haut.
                    Console.SetCursorPosition(placement, Console.CursorTop);
                    //afficher les sous-titres correspondant.
                    Console.WriteLine(subtitle[position]);
                    i = 1;
                    supprimer();
                }
            }

        }
        public void supprimer()
        {
            int i = 0;
            while (i == 0)
            {
                if (TimeEnd[position] == Interface.clock() )
                {
                    //efface la console.
                    Console.Clear();
                    i = 1;
                    //avancer dans les sous-titres.
                    position++;
                    if(subtitle.Count < position )
                    {
                        afficher();
                    }
                    Interface.end();
                }
            }

        }
    }
}
