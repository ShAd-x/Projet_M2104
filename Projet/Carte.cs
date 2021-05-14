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
        char[,] lacarte = new char[longueur, largeur];
        public Carte(string cheminfichier)
            
        {
            for (int i = 0; i < largeur; i++)
            {
                for (int x = 0; x < longueur; x++)
                {
                    Console.WriteLine("Entrez une lettre en minuscule ou F (pour une foret) / M (pour une parcelle d'eau) aux coordonnée [ {0} , {1} ]", i, x);
                    Console.ForegroundColor = ConsoleColor.White;
                    string tempString = Console.ReadLine();
                    char tempChar = tempString[0];
                    if (char.IsLower(tempChar) || tempChar == 'F' || tempChar == 'M')
                    {
                        lacarte[i, x] = tempChar;
                        Affiche();
                    }
                    else
                    {
                        x--;
                        Console.WriteLine("Erreur: Le caractère entré ne peut être que une lettre entre a et z ou F ou M \n \n ");
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    
                }
            }
            StreamWriter sw = new StreamWriter("../../../../Phatt.clair.txt");
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
            Console.WriteLine("Voici la carte: \n");

            for (int x = 0; x < longueur; x++)
            {
                for (int j = 0; j < largeur; j++)
                {
                    if (lacarte[x, j] == 'M')
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                    }
                    else if (lacarte[x, j] == 'F')
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    Console.Write(lacarte[x, j]);

                }
                Console.WriteLine("\n ");
            }
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}