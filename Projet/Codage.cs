using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Projet
{
    class Codage
    {
        int[] code = new int[100];
        const int longueur = 10;
        const int largeur = 10;
        char[,] carte = new char[longueur, largeur];
        public Codage(string cheminFichier) {
            try
            {
                int y = 0;
                string str;
                StreamReader sr = new StreamReader(cheminFichier);
                while ((str = sr.ReadLine()) != null)
                {
                    for(int i = 0; i < largeur ; i++)
                    {
                        carte[i, y] = str[i];
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
            int count = 0;
            for (int i = 0; i < longueur; i++)
            {
                for (int y = 0; y < largeur; y++)
                {
                    char Char = carte[y, i];

                    /*Error out of array (logique)
                     * char Nord = recup[y, i-1];
                    char Sud = recup[y, i+1];
                    char Ouest = recup[y-1, i];
                    char Est = recup[y+1, i];*/

                    // i = lignes
                    // y = colonnes

                    // Nord + 1
                    // Ouest + 2
                    // Sud + 4
                    // Est + 8

                    code[count] = 0;

                    // Directions
                    // Nord
                    if (i != 0) {
                        if (carte[y, i - 1] != Char)
                            code[count] += 1;
                    }
                    // Sud
                    if (i != 9) {
                        if(carte[y, i + 1] != Char)
                            code[count] += 4;
                    }
                    // Ouest
                    if (y != 0) {
                        if(carte[y - 1, i] != Char)
                            code[count] += 2;
                    }
                    // Est
                    if (y != 9) {
                        if(carte[y + 1, i] != Char) 
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
            Console.WriteLine("\n");
            //PromptEcriture();
        }
        public void CountP()
        {
            int ascentier = 97;
            int count = 0;
            char asciilettre;            
            for (int k = ascentier; k < 123; k++)
            {                
                for (int i = 0; i < longueur; i++)
                {
                    for (int y = 0; y < largeur; y++)
                    {
                        if (carte[i, y] == k)
                        {
                            count++;
                            Console.Write("({0},{1}) ; ", i, y);
                        }                                                              
                    }
                }
                if (count != 0)
                {
                    asciilettre = Convert.ToChar(k);
                    Console.WriteLine("Il y a {0} unités {1}", count, asciilettre);
                }                
                count = 0;
            }
            Console.WriteLine("\n");
        }
        public void PromptEcriture() {
            Console.WriteLine("Voulez vous écrire cette carte ? => 'oui'");
            if (Console.ReadLine().Equals("oui")) {
                Console.WriteLine("Veuillez donner le nom de fichier pour écrire la carte codée");
                EcritureChiffre(Console.ReadLine());
            } else {
                Console.WriteLine("La carte n'a pas été écrite.");
            }
            Console.WriteLine("\n");
        }
        public void EcritureChiffre(string nomFichierEcriture) {
            try {
                StreamWriter sw = new StreamWriter("../../../../" + nomFichierEcriture + ".chiffre.test");
                int count = 0;
                for (int i = 0; i < largeur; i++) {
                    for (int y = 0; y < longueur; y++) {
                        if (y != 9) {
                            sw.Write(code[count] + ":");
                        } else {
                            sw.Write(code[count] + "|");
                        }
                        count++;
                    }
                }
                sw.Close();
            } catch (Exception e) {
                Console.WriteLine(e.Message);
                return;
            }
        }
        public void Affiche() {
            for (int x = 0; x < largeur; x++) {
                for (int j = 0; j < longueur; j++) {
                    if (carte[j, x] == 'M') {
                        Console.ForegroundColor = ConsoleColor.Blue;
                    } else if (carte[j, x] == 'F') {
                        Console.ForegroundColor = ConsoleColor.Green;
                    } else {
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    Console.Write(carte[j, x]);
                }
                Console.WriteLine("\n");
            }
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
