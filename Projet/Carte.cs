using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Projet
{
    class Carte
    {
        const int longueur = 10;
        const int largeur = 10;
         string[,] lacarte = new string[longueur, largeur];
        public Carte(string cheminfichier)
            
        {
            for (int i = 0; i < largeur; i++)
            {
                for (int x = 0; x < longueur; x++)
                {
                    Affiche();
                    lacarte[i,x] = Console.ReadLine();
                                  
                }
            }
            using (StreamWriter sw = new StreamWriter ("../../../../Phatt.clair.txt"))
            {
                for (int i = 0; i < largeur; i++)
                {
                    for (int x = 0; x < longueur; x++)
                    {
                        sw.WriteLine(lacarte[i, x]);
                    }
                }
            }
        }
        public void Affiche()
        {
            for (int i = 0; i < longueur; i++)
            {
                for (int y = 0; y < largeur; y++)
                {
                    Console.Write(lacarte[y, i]);
                }
                Console.WriteLine("\n");
            }
        }
    }
}