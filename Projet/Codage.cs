using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Projet
{
    class Codage
    {
        const int longueur = 10;
        const int largeur = 10;
        int[] code = new int[100];

        char[,] recup = new char[largeur, longueur];
        public Codage(string cheminFichier)
        {
            try
            {
                int y = 0;
                string str;
                StreamReader sr = new StreamReader(cheminFichier);
                while ((str = sr.ReadLine()) != null)
                {
                    for(int i = 0; i < largeur ; i++)
                    {
                        recup[i, y] = str[i];
                    }
                    y++;
                }
                sr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return;
            }
            Affiche();
            int count = 0;
            for (int i = 0; i < longueur; i++)
            {
                for (int y = 0; y < largeur; y++)
                {
                    char Char = recup[y, i];

                    /* Error out of array (logique)
                     * char Nord = recup[y, i-1];
                    char Sud = recup[y, i+1];
                    char Ouest = recup[y-1, i];
                    char Est = recup[y+1, i];*/

                    // Nord + 1
                    // Ouest + 2
                    // Sud + 4
                    // Est + 8

                    code[count] = 0;

                    // Directions
                    // Nord
                    if (y != 0 && i != 0) {
                        if (recup[y, i - 1] != Char)
                            code[count] += 1;
                    }
                    // Sud
                    if (y != 9 && i != 9) {
                        if(recup[y, i + 1] != Char)
                            code[count] += 4;
                    }
                    // Ouest
                    if (y != 0 && i != 9) {
                        if(recup[y - 1, i] != Char)
                            code[count] += 2;
                    }
                    // Est
                    if (y != 9 && i != 0) {
                        if(recup[y + 1, i] != Char) 
                            code[count] += 8;
                    }

                    // Cas spéciaux
                    if (Char == 'M')
                    {
                        code[count] += 64;
                    }
                    if (Char == 'F')
                    {
                        code[count] += 32;
                    }

                    // Bordures
                    if (i == 0)
                    {
                        code[count] += 1;
                    }
                    if (i == 9)
                    {
                        code[count] += 4;
                    }
                    if (y == 0)
                    {
                        code[count] += 2;
                    }
                    if (y == 9)
                    {
                        code[count] += 8;
                    }
                    if(y != 9)
                    {
                        Console.Write(code[count] + ":");
                    } else
                    {
                        Console.Write(code[count] + "|");
                    }
                    count++;
                }
            }
        }
        public void Affiche()
        {
            for (int i = 0; i < longueur; i++)
            {
                for (int y = 0; y < largeur; y++)
                {
                    Console.Write(recup[y, i]);
                }
                Console.WriteLine("\n");
            }
        }
    }
}
