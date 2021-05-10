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
        int counter = 0;
        //string[,] carte = new string[longueur, largeur];
        int[,] transi = new int[longueur, largeur];
        public Carte(string[] donnees)
        {
            for(int i = 0; i < largeur; i++)
            {
                for (int y = 0; y < longueur; y++)
                {
                    transi[y, i] = Convert.ToInt32(donnees[counter]);
                    counter++;
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
                    Console.Write(transi[y, i] + " ");
                }
                Console.WriteLine("\n");
            }
        }
    }
}
