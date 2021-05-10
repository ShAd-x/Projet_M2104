using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Projet
{
    abstract class Carte
    {
        const int longueur = 10;
        const int largeur = 10;
        int counter = 0;
        int[,] carte = new int[longueur, largeur];
        public Carte(string[] donnees)
        {
            for(int i = 0; i < largeur; i++)
            {
                for (int y = 0; y < longueur; y++)
                {
                    this.carte[y, i] = Convert.ToInt32(donnees[counter]);
                    this.counter++;
                }
            }
            Affiche();
        }
        public void Affiche()
        {
            for (int i = 0; i < largeur; i++)
            {
                for (int y = 0; y < longueur; y++)
                {
                    //Console.Write((char)transi[y, i]);
                    Console.Write(carte[y, i] + " ");
                }
                Console.WriteLine("\n");
            }
        }
    }
}
