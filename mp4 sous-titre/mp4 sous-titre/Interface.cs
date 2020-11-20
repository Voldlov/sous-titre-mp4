using System;
using System.Collections.Generic;
using System.Text;

namespace mp4_sous_titre
{
    class Interface
    {
        public string chemin;
        public void menu()
        {
            Console.WriteLine("Lecteur de sous-titre");
            Console.WriteLine("B2B Info 2020-2021");
            Console.WriteLine("Par GAIO DOS SANTOS Lucas");
            saisie();
        }
        private void saisie()
        {
            Console.WriteLine("Marquez le nom de votre fichier de sous-titre :");
            chemin = Console.ReadLine();
            //erreur d'origine inconue.
            soustitre.SubTitle(chemin);
        }
        public static string clock()
        { 
            //afficher heure, minute et seconde en format 10:20:15
            return( DateTime.Now.ToString("HH:mm:ss,fff"));
            //horloge sa mère
        }
        public static void end()
        {
            Console.WriteLine("Fin du film");
            Console.WriteLine("Merci d'avoir regardé");
        }
    }
}
